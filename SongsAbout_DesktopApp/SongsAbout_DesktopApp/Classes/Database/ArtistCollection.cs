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
                    try
                    {
                        if (!this.Contains(id))
                        {
                            Artist result;
                            using (var db = new DataClassesContext())
                            {
                                result = (from Artist a in db.Artists
                                          where a.ID == id
                                          select a).First();

                                foreach (var album in result.Albums)
                                {
                                    album.Tracks = album.Tracks;
                                    album.Genres = album.Genres;
                                }
                            }
                            return result;
                        }
                        else
                        {
                            throw new EntityNotFoundError(DbEntityType, id);
                        }
                    }
                    catch (EntityNotFoundError)
                    {
                        throw;
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
                    try
                    {
                        if (!this.Contains(name))
                        {
                            Artist result;
                            using (var db = new DataClassesContext())
                            {
                                result = (from Artist a in db.Artists
                                          where a.Name == name
                                          select a).First();

                                foreach (var album in result.Albums)
                                {
                                    album.Tracks = album.Tracks;
                                    album.Genres = album.Genres;
                                }
                            }
                            return result;
                        }
                        else
                        {
                            throw new EntityNotFoundError(DbEntityType, name);
                        }
                    }
                    catch (EntityNotFoundError)
                    {
                        throw;
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
                    int count = 0;
                    using (var db = new DataClassesContext())
                    {
                        count = (from a in db.Artists
                                 where a.ID == id
                                 select a).Count();
                    };
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
            /// <param name="id"></param>
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public bool Contains(string name)
            {
                if (name == null || name == "")
                    throw new NullValueError();
                try
                {
                    int count = 0;
                    using (var db = new DataClassesContext())
                    {
                        count = (from a in db.Artists
                                 where a.Name == name
                                 select a).Count();
                    };
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
            public override List<Artist> All
            {
                get
                {
                    try
                    {
                        _allArtists = new List<Artist>();
                        using (var db = new DataClassesContext())
                        {
                            _allArtists.AddRange(from a in db.Artists
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
                        List<string> artists;
                        using (var db = new DataClassesContext())
                        {
                            artists = (from a in db.Artists
                                       select a.Name).ToList();
                        }
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