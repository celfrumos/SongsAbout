using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SongsAbout.Enums;
using SongsAbout.Entities;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Data;
using SongsAbout.Enums;
using SongsAbout.Entities;
using System.Collections;
using System.Data.Entity;

namespace SongsAbout.Classes.Database
{
    public partial class SongDatabase
    {
        public abstract class EntityCollection : IEntityCollection
        {
            public abstract List<string> AllNames { get; }

            public abstract List<string> CachedNames { get; }

            public abstract int Count { get; }

            public abstract DbEntityType DbEntityType { get; }

            public abstract bool HasIntId { get; }
        }

        public abstract class EntityCollection<T> : EntityCollection, IEntityCollection<T>, IEntityNameAccessor<T>
            where T : DbEntity
        {
            public override bool HasIntId { get; }

            protected EntityCollection(string childname)
            {
                if (!SongDatabase.isInitialized)
                {
                    throw new
                        InvalidInitializedError(childname,
                        $"An attempt was made to initialize entity container {childname} when the program database had not been initialized");
                }
            }

            protected abstract T FindByName(string name);

            public virtual List<T> CachedItems { get; protected set; }

            public abstract List<T> Items { get; protected set; }
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
            /// <param name="name">The name of the intended entity</param>
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            /// <exception cref="NullValueError"></exception>
            /// <seealso cref="Contains(int id)"/>
            public virtual bool Contains(string name, bool checkCache = false)
            {
                if (name == null || name == "")
                    throw new NullValueError();

                try
                {
                    if ((Program.Database.LargeQuery || checkCache) && this.CachedNames != null && CachedNames.Count == 0)
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
            public override int Count { get { return this.Items.Count; } }
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