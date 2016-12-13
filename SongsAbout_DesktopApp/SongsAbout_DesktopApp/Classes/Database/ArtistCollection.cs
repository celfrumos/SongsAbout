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
        public class ArtistCollection : EntityCollection<Artist>, IEntityIdAccessor<Artist>, IEntityNameAccessor<Artist>
        {
            public override DbEntityType DbEntityType { get { return DbEntityType.Artist; } }
            private static List<Artist> _allArtists
            {
                get; set;
            }
            private static bool _initialized { get; set; }
            /// <summary>
            /// Initializes the connector to the ArtistList
            /// </summary>
            /// <exception cref="InvalidInitializedError"></exception>"
            public ArtistCollection() : base("ArtistList")
            {
                if (_initialized)
                {
                    throw new InvalidInitializedError("ArtistList");
                }
                _initialized = true;

            }

            /// <summary>
            /// Returns the number of rows in the Artist Table
            /// </summary>
            /// <exception cref="DbException"></exception>
            public override int Count
            {
                get
                {
                    try
                    {
                        int count;
                        using (var db = new DataClassesContext())
                        {
                            count = db.Artists.Count();
                        }
                        return count;
                    }
                    catch (Exception ex)
                    {
                        throw new DbException(this.DbEntityType, ex.Message);
                    }
                }
            }
            /// <summary>
            /// Get the Artist of the given id if it exists, otherwise throws an exception
            /// </summary>
            /// <param name="id"></param>
            /// <exception cref="EntityNotFoundError"></exception>
            /// <exception cref="LoadError"></exception>"
            /// <exception cref="DbUpdateException"></exception>
            public Artist this[int id]
            {
                set { this.Add(value); }
                get
                {
                    if (!this.Contains(id))
                        throw new EntityNotFoundError(DbEntityType, id);

                    try
                    {
                        Artist result;
                        using (var db = new DataClassesContext())
                        {
                            result = db.Artists.Where(a => a.ID == id).First();

                            foreach (var album in result.Albums)
                            {
                                album.Tracks = album.Tracks;
                                album.Genres = album.Genres;
                            }
                        }
                        return result;

                    }
                    catch (Exception ex)
                    {
                        throw new LoadError(DbEntityType, id, ex.Message);
                    }
                }
            }
            /// <summary>
            /// Get the Artist of the given name if it exists, otherwise throws an exception
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            /// <exception cref="EntityNotFoundError"></exception>
            public Artist this[string name]
            {
                set { this.Add(value); }
                get
                {
                    if (!this.Contains(name))
                        throw new EntityNotFoundError(DbEntityType, name);

                    try
                    {
                        Artist result;
                        using (var db = new DataClassesContext())
                        {
                            result = db.Artists.Where(a => a.Name == name).First();

                            foreach (var album in result.Albums)
                            {
                                album.Tracks = album.Tracks;
                                album.Genres = album.Genres;
                            }
                        }
                        return result;

                    }
                    catch (Exception ex)
                    {
                        throw new LoadError(DbEntityType, name, ex.Message);
                    }
                }
            }


            /// <summary>
            /// Verifies if an artist of the given id exists
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public bool Contains(int id)
            {
                try
                {
                    int count = this.Items
                        .Where(a => a.ID == id)
                        .Count();

                    return count > 0;
                }
                catch (Exception ex)
                {
                    throw new
                        DbException(DbEntityType, $"Error verifying if Database contains Artist with id {id}:\n{ex.Message}");
                }
            }

            /// <summary>
            /// Verifies if an artist of the given name exists
            /// </summary>
            /// <param name="name">The name of the intended Artist</param>
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            /// <seealso cref="Contains(int id)"/>
            public bool Contains(string name)
            {
                if (name == null || name == "")
                    throw new NullValueError();
                try
                {
                    int count = this.Items
                        .Where(a => a.Name == name)
                        .Count();

                    return count > 0;
                }
                catch (Exception ex)
                {
                    throw new
                        DbException(DbEntityType, $"Error verifying if Database contains Artist with Name {name}{ex.Message}");
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
                        _allArtists = new List<Artist>();
                        using (var db = new DataClassesContext())
                        {
                            _allArtists.AddRange(from a in db.Artists
                                                 where a.ID != 0
                                                 select a);
                        }
                        base._all = _allArtists;
                        return _allArtists;
                    }
                    catch (Exception ex)
                    {
                        throw new DbException($"Error loading All Artists from database: {ex.Message}");
                    }
                }
            }
            /// <summary>
            /// Loads the Names of the existing Artists to a List
            /// </summary>
            /// <exception cref="DbException"></exception>
            public override List<string> AllNames
            {
                get
                {
                    try
                    {
                        List<string> artists = (from a in this.Items
                                                select a.Name).ToList();

                        return artists;
                    }
                    catch (Exception ex)
                    {
                        throw new DbException($"Error Loading existing Artist Names: {ex.Message}");
                    }
                }
            }



            /// <summary>
            /// Submit Changes to the Database
            /// </summary>
            /// <exception cref="NullValueError"></exception>
            /// <exception cref="DbUpdateException"></exception>
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
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
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