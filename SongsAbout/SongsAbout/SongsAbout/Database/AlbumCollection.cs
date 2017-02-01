using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using SongsAbout;
using SongsAbout;
using SongsAbout.Entities;
using SongsAbout.Enums;
using System.Collections;
using System.Data.Entity;

namespace SongsAbout.Database
{
    public partial class SongDatabase
    {
        public class AlbumCollection : EntityCollection<Album>, IEntityIdAccessor<Album>
        {
            public override DbEntityType DbEntityType { get { return DbEntityType.Album; } }
            private const string COLLECTION_NAME = "AlbumList";

            public override bool HasIntId { get { return true; } }
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
                        var r = Album.Load(id);
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
            public bool Contains(int id, bool checkCache = false)
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
            protected override Album FindByName(string name)
            {
                Album result;
                using (var db = new DbEntityContext())
                {
                    result = db.Albums
                                    .Where(a => a.Name == name)
                                    .FirstOrDefault();
                }
                return result;

            }

            private Album FindById(int id)
            {
                Album result;
                using (var db = new DbEntityContext())
                {
                    result = db.Albums.Find(id);
                }
                return result;

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
                        if (this.CachedItems != null && SongDatabase.LargeQuery)
                        {
                            return this.CachedItems;
                        }
                        else
                        {
                            using (var db = new DbEntityContext())
                            {
                                this.CachedItems = db.Albums
                                    .Where(a => a.ID != 0)
                                    .Include(a => a.Tracks)
                                    .Include(a=> a.Genres)
                                    .ToList();

                                return this.CachedItems;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var inner = ex.InnerException;
                        throw new DbException($"Error loading All Albums from database: {ex.Message}");
                    }
                }
                protected set
                {
                    this.CachedItems = value;
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
                    using (var context = new DbEntityContext())
                    {
                        context.UpdateInsert_Album(a.ID, a.ArtistId, a.Name, a.ReleaseDate, a.Uri, a.CoverArtBytes);
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
