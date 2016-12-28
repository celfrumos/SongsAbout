using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Data;
using SongsAbout.Enums;
using SongsAbout.Entities;
using System.Collections;

namespace SongsAbout.Classes.Database
{
    public partial class SongDatabase
    {
        public abstract class EntityCollection<T> : IEntityCollection<T>, IEntityNameAccessor<T>
            where T : DbEntity
        {
            protected EntityCollection(string childname)
            {
                if (!SongDatabase.isInitialized)
                {
                    throw new
                        InvalidInitializedError(childname,
                        $"An attempt was made to initialize entity container {childname} when the program database had not been initialized");
                }
            }
            public List<T> CachedItems { get; set; }
            public abstract List<T> Items { get; }
            public virtual List<string> AllCachedNames
            {
                get
                {
                    return (from a in this.CachedItems
                            select a.Name).ToList();
                }
            }
            public virtual List<string> AllNames
            {
                get
                {
                    return (from a in this.Items
                            select a.Name).ToList();
                }
            }
            public abstract DbEntityType DbEntityType { get; }
            /// <summary>
            /// Get the Artist of the given name if it exists, otherwise throws an exception
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
                        var results =
                            this.Items
                            .Where(a => a.Name == name);

                        if (results.Count() == 0)
                            return null;

                        return results.First();

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
            /// <param name="name">The name of the intended entity</param>
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            /// <exception cref="NullValueError"></exception>
            /// <seealso cref="Contains(int id)"/>
            public virtual bool Contains(string name)
            {
                if (name == null || name == "")
                    throw new NullValueError();

                try
                {
                    return this[name] != null;
                }
                catch (Exception ex)
                {
                    throw new
                        DbException(DbEntityType, $"Error verifying if Database contains {typeof(T)} with Name {name}{ex.Message}");
                }
            }
            public virtual int Count { get { return this.Items.Count; } }
            public abstract void Add(T entity);

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

            //object IEnumerator.Current
            //{
            //    get
            //    {
            //        if (_all == null)
            //            return this.All.GetEnumerator().Current;
            //        else
            //            return this._all.GetEnumerator().Current;
            //    }
            //}


            public virtual bool MoveNext()
            {
                return ((IEnumerator)CachedItems).MoveNext();
            }
            public virtual void Reset()
            {
                ((IEnumerator)CachedItems).Reset();
            }

            public virtual void Dispose()
            {
                ((IDisposable)CachedItems).Dispose();
            }

            public virtual IEnumerator<T> GetEnumerator()
            {
                return this.Items.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this.Items).GetEnumerator();
            }
        }
    }
}