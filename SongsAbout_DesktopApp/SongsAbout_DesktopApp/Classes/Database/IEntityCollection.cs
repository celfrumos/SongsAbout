using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsAbout.Entities;
using SongsAbout.Enums;

namespace SongsAbout.Classes.Database
{
    /// <summary>
    /// Provides simple functionality for interacting with Database tables
    /// </summary>
    interface IEntityCollection
    {
        DbEntityType DbEntityType { get; }
        List<string> AllNames { get; }
        /// <summary>
        /// The number of rows in the respective table
        /// </summary>
        int Count { get; }
    }

    /// <summary>
    /// Provides Functionality to interact with Database Tables using bracket notation for the Entity Id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IEntityIdAccessor<T>
        where T : DbEntity
    {
        bool Contains(int id);
        T this[int id] { get; set; }
    }

    /// <summary>
    /// Provides Functionality to interact with Database Tables using bracket notation for the Entity Name
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IEntityNameAccessor<T>
        where T : DbEntity
    {
        bool Contains(string name, bool checkCache);
        T this[string name] { get; set; }
    }

    interface IEntityCollection<T> : IEntityCollection, IEnumerable<T>
        where T : DbEntity
    {
        void Add(T entity);

        List<T> Items { get; }
    }
    /// <summary>
    /// Allows collection to be accessed by bracket notation for both name and id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IIntegralEntityCollection<T> : IEntityCollection<T>, IEntityIdAccessor<T>, IEntityNameAccessor<T>
        where T : DbEntity
    {

    }
}
