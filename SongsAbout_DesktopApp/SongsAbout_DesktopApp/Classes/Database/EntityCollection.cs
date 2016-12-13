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
        public abstract class EntityCollection<T> : IEntityContainer<T>
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
            protected List<T> _all { get; set; }
            public abstract List<T> All { get; }
            public abstract List<string> AllNames { get; }

            public virtual int Count { get; }
            public abstract void Add(T entity);

            public abstract DbEntityType DbEntityType { get; }

            public virtual T Current
            {
                get
                {
                    if (_all == null)
                        return this.All.GetEnumerator().Current;
                    else
                        return this._all.GetEnumerator().Current;
                }
            }
            object IEnumerator.Current
            {
                get
                {
                    if (_all == null)
                        return this.All.GetEnumerator().Current;
                    else
                        return this._all.GetEnumerator().Current;
                }
            }


            public virtual IEnumerator<T> GetEnumerator()
            {
                if (_all != null)
                    return this._all.GetEnumerator();
                else
                    return this.All.GetEnumerator();
            }
            public virtual bool MoveNext()
            {
                return ((IEnumerator)_all).MoveNext();
            }
            public virtual void Reset()
            {
                ((IEnumerator)_all).Reset();
            }

            public virtual void Dispose()
            {
                ((IDisposable)_all).Dispose();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                if (_all != null)
                    return ((IEnumerable)this._all).GetEnumerator();
                else
                    return ((IEnumerable)this.All).GetEnumerator();
            }
        }
    }
}