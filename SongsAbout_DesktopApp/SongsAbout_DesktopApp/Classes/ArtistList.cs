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

namespace SongsAbout.Classes
{
    public partial class SongDatabase
    {
        public class ArtistList : IIntegralEntityContainer<Artist>
        {
            public DbEntityType EntityType { get { return DbEntityType.Artist; } }
            private static bool _initialized { get; set; }
            /// <summary>
            /// Initializes the connector to the ArtistList
            /// </summary>
            /// <exception cref="AlreadyInitializedError"></exception>"
            public ArtistList()
            {
                if (_initialized)
                {
                    throw new AlreadyInitializedError("ArtistList");
                }
                _initialized = true;

            }
            public int Count
            {
                get
                {
                    int count;
                    using (var db = new DataClassesContext())
                    {
                        count = (from a in db.Artists
                                 select true).Count();
                    }
                    return count;
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
                set { this.Save(value); }
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
                            throw new EntityNotFoundError(EntityType, id);
                        }
                    }
                    catch (EntityNotFoundError)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        throw new LoadError(EntityType, id, ex.Message);
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
                set { this.Save(value); }
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
                            throw new EntityNotFoundError(EntityType, name);
                        }
                    }
                    catch (EntityNotFoundError)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        throw new LoadError(EntityType, name, ex.Message);
                    }
                }
            }


            /// <summary>
            /// Verifies if an artist of the given id exists
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            /// <exception cref="DbException"
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
                        DbException(EntityType, $"Error verifying if Database contains Artist with id {id}:\n{ex.Message}");
                }
            }
            /// <summary>
            /// Verifies if an artist of the given name exists
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            /// <exception cref="DbException"
            public bool Contains(string name)
            {
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
                        DbException(EntityType, $"Error verifying if Database contains Artist with Name {name}{ex.Message}");
                }
            }
            /// <summary>
            /// Returns A list of all Existing Artists in the database
            /// </summary>            
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public List<Artist> All
            {
                get
                {
                    try
                    {
                        List<Artist> allArtists = new List<Artist>();
                        using (var db = new DataClassesContext())
                        {
                            allArtists.AddRange(from a in db.Artists
                                                select Artist.Load(a));
                        }
                        return allArtists;
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
            public List<string> AllNames
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
            /// <exception cref="UpdateError"></exception>"
            /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateException"></exception>
            /// <exception cref="DbException"></exception>"
            public void Save(Artist a)
            {
                try
                {
                    if (a.Name != null)
                    {
                        using (var context = new DataClassesContext())
                        {
                            context.UpdateInsert_Artist(a.ID, a.Name, a.Bio, a.Website, a.Uri, a.ProfilePicBytes);
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        throw new NullValueError("Artist name cannot be null.");
                    }
                }
                catch (EntityNotFoundError ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                    throw;
                }
                catch (UpdateError ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                    throw;
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                    throw new DbException(ex.Message);
                }
            }

        }

    }
}