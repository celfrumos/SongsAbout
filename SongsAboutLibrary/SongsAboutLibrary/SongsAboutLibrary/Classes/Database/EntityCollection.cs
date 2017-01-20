using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SongsAbout.Enums;
using SongsAbout.Entities;
using System.Collections;

namespace SongsAbout.Classes.Database
{
    public partial class SongDatabase
    {
        /// <summary>
        /// Base clas
        /// </summary>
        public abstract class EntityCollection : IEntityCollection
        {
            /// <summary>
            /// A List of the names of the items in the database
            /// </summary>
            public abstract List<string> AllNames { get; }

            /// <summary>
            /// A List of the c names of the items in the database
            /// </summary>
            public abstract List<string> CachedNames { get; }

            /// <summary>
            /// The number of rows in the table
            /// </summary>
            public abstract int Count { get; }

            /// <summary>
            /// The type of entity mapped to this collection
            /// </summary>
            public abstract DbEntityType DbEntityType { get; }

            /// <summary>
            /// True if the table has an int ID column
            /// </summary>
            public abstract bool HasIntId { get; }
        }

        /// <summary>
        /// Generic Class to access the items in the collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract class EntityCollection<T> : EntityCollection, IEntityCollection<T>, IEntityNameAccessor<T>
            where T : DbEntity
        {
            /// <summary>
            /// Construct the base class, can only be called once.
            /// </summary>
            /// <param name="childname"></param>
            protected EntityCollection(string childname)
            {
                if (!SongDatabase.IsInitialized)
                {
                    throw new
                        InvalidInitializedError(childname,
                        $"An attempt was made to initialize entity container {childname} when the program database had not been initialized");
                }
            }

            /// <summary>
            /// Find the intended item by name lookup
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            protected abstract T FindByName(string name);

            /// <summary>
            /// Returns the last returned list of items
            /// </summary>
            public virtual List<T> CachedItems { get; protected set; }

            /// <summary>
            /// Queries the database and returns a list of all the items
            /// </summary>
            public abstract List<T> Items { get; protected set; }

            /// <summary>
            /// Returns the last returned list of names
            /// </summary>
            public override List<string> CachedNames
            {
                get
                {
                    if (this.CachedItems == null)
                        return (from a in this.Items
                                select a.Name).ToList();

                    return (from a in this.CachedItems
                            select a.Name).ToList();

                }
            }

            /// <summary>
            /// Queries the database and returns a list of all the items
            /// </summary>
            public override List<string> AllNames
            {
                get
                {
                    return (from a in this.Items
                            select a.Name).ToList();
                }
            }

            /// <summary>
            /// Get the Entity of the given name if it exists, otherwise throws an exception
            /// </summary>
            /// <param name="name"></param>
            /// <exception cref="NullValueError"></exception>
            /// <exception cref="LoadError"></exception>"
            public virtual T this[string name]
            {
                set { this.Add(value); }
                get
                {
                    if (name == null || name == "")
                        throw new NullValueError();

                    try
                    {
                        return this.FindByName(name);

                    }
                    catch (Exception ex)
                    {
                        throw new LoadError(DbEntityType, name, ex.Message);
                    }
                }
            }
            /// <summary>
            /// Verifies if an entity of the given name exists
            /// </summary>
            /// <param name="name">he name of the intended entity</param>
            /// <param name="checkCache">Set to true if you don't want to run a new query against the database.</param>
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            /// <exception cref="NullValueError"></exception>
            public virtual bool Contains(string name, bool checkCache = false)
            {
                if (name == null || name == "")
                    throw new NullValueError();

                try
                {
                    if ((Library.Database.LargeQuery || checkCache) && this.CachedNames != null && CachedNames.Count == 0)
                        return this.CachedNames.Contains(name);

                    else
                        return this.FindByName(name) != null;

                }
                catch (Exception ex)
                {
                    throw new
                        DbException(DbEntityType, $"Error verifying if Database contains {typeof(T)} with Name {name}{ex.Message}");
                }
            }

            /// <summary>
            /// Returns the number of items in the collection
            /// </summary>
            public override int Count { get { return this.Items.Count; } }

            /// <summary>
            /// Ads a new item to the Collection, and to the corresponding database table
            /// </summary>
            /// <param name="entity"></param>
            public abstract void Add(T entity);

            /// <summary>
            /// Gets the element at the current position of the enumerator.
            /// </summary>
            public virtual T Current
            {
                get
                {
                    if (CachedItems == null)
                        return this.Items.GetEnumerator().Current;
                    else
                        return this.CachedItems.GetEnumerator().Current;
                }
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; 
            /// false if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="System.InvalidOperationException">   The collection was modified after the enumerator was created.
            /// </exception>
            public virtual bool MoveNext()
            {
                return ((IEnumerator)CachedItems).MoveNext();
            }
            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>  
            /// /// <exception cref="System.InvalidOperationException">   The collection was modified after the enumerator was created.
            /// </exception>
            public virtual void Reset()
            {
                ((IEnumerator)CachedItems).Reset();
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public virtual void Dispose()
            {
                ((IDisposable)CachedItems).Dispose();
            }
            /// <summary>
            /// Returns an enumerator that iterates through the Collection
            /// </summary>
            /// <returns></returns>
            public virtual IEnumerator<T> GetEnumerator()
            {
                return this.Items.GetEnumerator();
            }

            /// <summary>
            /// Returns an enumerator that iterates through the Collection
            /// </summary>
            /// <returns></returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this.Items).GetEnumerator();
            }
        }
    }
}