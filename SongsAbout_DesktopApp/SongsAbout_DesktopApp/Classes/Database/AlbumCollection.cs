using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using SongsAbout;
using SongsAbout.Entities;
using SongsAbout.Enums;
using System.Collections;

namespace SongsAbout.Classes.Database
{
    public partial class SongDatabase
    {
        public class AlbumCollection : EntityCollection<Album>, IEntityNameAccessor<Album>
        {
            public override DbEntityType DbEntityType { get { return DbEntityType.Album; } }
            private const string COLLECTION_NAME = "AlbumList";
            private static bool _initialized { get; set; }

            /// <summary>
            /// Initializes the connector to the AlbumList
            /// </summary>
            /// <exception cref="InvalidInitializedError"></exception>"
            public AlbumCollection() : base(COLLECTION_NAME)
            {
                if (_initialized)
                {
                    throw new InvalidInitializedError(COLLECTION_NAME);
                }
                _initialized = true;

            }
            /// <summary>
            /// Get the Album of the given id if it exists, otherwise throws an exception
            /// </summary>
            /// <returns></returns>
            /// <param name="id"></param>
            /// <exception cref="LoadError"></exception>
            /// <exception cref="DbUpdateException"></exception>
            public Album this[int id]
            {
                set
                {
                    try { this.Add(value); }
                    catch (DbUpdateException)
                    { throw; }
                }
                get
                {
                    try
                    {
                        var results = this
                            .Items
                            .Where(a => a.ID == id);

                        if (results.Count() == 0)
                            return null;

                        return results.FirstOrDefault();

                    }
                    catch (Exception ex)
                    {
                        throw new LoadError(DbEntityType, id, ex.Message);
                    }
                }
            }


            /// <summary>
            /// Verifies if an Album of the given id exists
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public bool Contains(int id)
            {
                if (id == 0)
                    throw new NullValueError(DbEntityType, "name");

                try
                {
                    return this[id] != null;
                }
                catch (Exception ex)
                {
                    throw new
                        DbException(DbEntityType, $"Error verifying if Database contains Album with id {id}:\n{ex.Message}");
                }
            }

            /// <summary>
            /// Returns A list of all Existing Albums in the database
            /// </summary>            
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public override List<Album> Items
            {
                get
                {
                    try
                    {
                        _all = new List<Album>();
                        using (var db = new DataClassesContext())
                        {
                            _all.AddRange(from a in db.Albums
                                          where a.ID != 0
                                          select a);
                        }
                        return _all;
                    }
                    catch (Exception ex)
                    {
                        throw new DbException($"Error loading All Albums from database: {ex.Message}");
                    }
                }
            }


            /// <summary>
            /// Submit Changes to the Database
            /// </summary>
            /// <exception cref="NullValueError"></exception>
            /// <exception cref="DbUpdateException"></exception>
            /// <exception cref="SaveError"></exception>"
            public override void Add(Album a)
            {

                if (a.Name == null || a.Name == "")
                    throw new NullValueError(this.DbEntityType, "Name");

                try
                {
                    using (var context = new DataClassesContext())
                    {
                        context.UpdateInsert_Album(a.ID, a.ArtistId, a.Name, a.Year, a.Uri, a.CoverArtBytes);
                        context.SaveChanges();
                    }
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                    throw new SaveError(ex.Message);
                }
            }

        }
    }
}
