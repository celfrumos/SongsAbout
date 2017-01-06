using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SongsAbout.Enums;
using SongsAbout.Entities;
using System.Data.Entity;

namespace SongsAbout.Classes.Database
{
    public partial class SongDatabase
    {
        public class ArtistCollection : EntityCollection<Artist>, IEntityIdAccessor<Artist>
        {
            private const string COLLECTION_NAME = "ArtistList";
            public override DbEntityType DbEntityType { get { return DbEntityType.Artist; } }
            public override bool HasIntId { get { return true; } }

            private static bool _initialized { get; set; }
            /// <summary>
            /// Initializes the connector to the ArtistList
            /// </summary>
            /// <exception cref="InvalidInitializedError"></exception>"
            public ArtistCollection() : base(COLLECTION_NAME)
            {
                if (_initialized)
                {
                    throw new InvalidInitializedError(COLLECTION_NAME);
                }
                _initialized = true;

            }

            /// <summary>
            /// Get the Artist of the given id if it exists, otherwise throws an exception
            /// </summary>
            /// <param name="id"></param>
            /// <exception cref="NullValueError"></exception>
            /// <exception cref="EntityNotFoundError"></exception>
            /// <exception cref="LoadError"></exception>"
            /// <exception cref="DbUpdateException"></exception>
            public Artist this[int id]
            {
                set { this.Add(value); }
                get
                {
                    if (id == 0)
                        throw new NullValueError();
                    try
                    {
                        var results = this.Items
                            .Where(a => a.ID == id);

                        if (results.Count() == 0)
                            return null;

                        return results.First();
                    }
                    catch (Exception ex)
                    {
                        throw new LoadError(DbEntityType, id, ex.Message);
                    }
                }
            }

            /// <summary>
            /// Verifies if an artist of the given id exists
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            /// /// <exception cref="NullValueError"></exception>
            public bool Contains(int id, bool checkCache = false)
            {
                if (id == 0)
                    throw new NullValueError();

                try
                {
                    return this[id] == null;
                }
                catch (Exception ex)
                {
                    throw new
                        DbException(DbEntityType, $"Error verifying if Database contains Artist with id {id}:\n{ex.Message}");
                }
            }

            /// <summary>
            /// Returns A list of all Existing Artists in the database
            /// </summary>            
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public override List<Artist> Items
            {
                get
                {
                    try
                    {

                        if (Program.Database.LargeQuery)
                        {
                            return this.CachedItems;
                        }
                        using (var db = new DataClassesContext())
                        {
                            base.CachedItems = db.Artists
                                                    .Where(a => a.ID != 0)                                              
                                                    .Include(a => a.Albums)
                                                    .Include(a=> a.Tracks)                                                          
                                                    .ToList();
                        }
                        return base.CachedItems;
                    }
                    catch (Exception ex)
                    {
                        throw new DbException($"Error loading All Artists from database: {ex.Message}");
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
            /// <exception cref="SaveError"></exception>"
            public override void Add(Artist a)
            {
                if (a.Name == null || a.Name == "")
                    throw new NullValueError("Artist name cannot be null.");

                try
                {
                    using (var context = new DataClassesContext())
                    {
                        context.UpdateInsert_Artist(a.ID, a.Name, a.Bio, a.Website, a.Uri, a.ProfilePicBytes);
                        context.SaveChanges();
                    }

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