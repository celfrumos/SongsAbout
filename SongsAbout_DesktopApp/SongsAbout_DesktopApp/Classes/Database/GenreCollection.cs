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
        public class GenreList : EntityCollection<Genre>, IEntityNameAccessor<Genre>
        {
            public override DbEntityType EntityType { get { return DbEntityType.Genre; } }
            private static bool _initialized { get; set; }
            public override int Count
            {
                get
                {
                    int count;
                    using (var db = new DataClassesContext())
                    {
                        count = db.Genres.Count();
                    }
                    return count;
                }
            }

            /// <summary>
            /// Get the Genre of the given name if it exists, otherwise throws an exception
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            /// <exception cref="EntityNotFoundError"></exception>
            public Genre this[string name]
            {
                set { this.Add(value); }
                get
                {
                    try
                    {
                        if (!this.Contains(name))
                        {
                            Genre result;
                            using (var db = new DataClassesContext())
                            {
                                result = (from Genre a in db.Genres
                                          where a.Name == name
                                          select a).First();
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
            /// Initializes the connector to the GenreList
            /// </summary>
            /// <exception cref="InvalidInitializedError"></exception>"
            public GenreList() : base("GenreList")
            {
                if (_initialized)
                {
                    throw new InvalidInitializedError("GenreList");
                }
                _initialized = true;

            }


            /// <summary>
            /// Verifies if an Genre of the given name exists
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
                        count = (from a in db.Genres
                                 where a.Name == name
                                 select a).Count();
                    };
                    return count > 0;
                }
                catch (Exception ex)
                {
                    throw new
                        DbException(EntityType, $"Error verifying if Database contains Genre with Name {name}{ex.Message}");
                }
            }

            /// <summary>
            /// Returns A list of all Existing Genres in the database
            /// </summary>            
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public override List<Genre> All
            {
                get
                {
                    try
                    {
                        _all = new List<Genre>();
                        using (var db = new DataClassesContext())
                        {
                            _all.AddRange(from a in db.Genres
                                          select a);
                        }
                        return _all;
                    }
                    catch (Exception ex)
                    {
                        throw new DbException($"Error loading All Genres from database: {ex.Message}");
                    }
                }
            }
            /// <summary>
            /// Loads the Names of the existing Genres to a List
            /// </summary>
            /// <exception cref="DbException"></exception>
            public override List<string> AllNames
            {
                get
                {
                    try
                    {
                        List<string> Genres;
                        using (var db = new DataClassesContext())
                        {
                            Genres = (from a in db.Genres
                                      select a.Name).ToList();
                        }
                        return Genres;
                    }
                    catch (Exception ex)
                    {
                        throw new DbException($"Error Loading existing Genre Names: {ex.Message}");
                    }
                }
            }

            /// <summary>
            /// Submit Changes to the Database
            /// </summary>
            /// <exception cref="NullValueError"></exception>
            /// <exception cref="UpdateFromSpotifyError"></exception>"
            /// <exception cref="DbUpdateException"></exception>
            /// <exception cref="DbException"></exception>"
            public override void Add(Genre a)
            {
                try
                {
                    if (a.Name != null)
                    {
                        using (var context = new DataClassesContext())
                        {
                            if ((from g in context.Genres where g.Name == a.Name select true).Count() == 0)
                            {
                                context.Genres.Add(a);
                                context.SaveChanges();
                            }
                            else
                            {
                                throw new ValueAlreadyPresentException(EntityType, a.Name);
                            }
                        }
                    }
                    else
                    {
                        throw new NullValueError("Genre name cannot be null.");
                    }
                }
                catch (EntityNotFoundError ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                    throw;
                }
                catch (UpdateFromSpotifyError ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                    throw;
                }
                catch (DbUpdateException ex)
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