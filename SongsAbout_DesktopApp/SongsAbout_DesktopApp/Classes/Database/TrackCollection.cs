using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        class TrackCollection : EntityCollection<Track>, IEntityIdAccessor<Track>, IEntityNameAccessor<Track>
        {
            public override DbEntityType DbEntityType { get { return DbEntityType.Track; } }
            private static List<Track> _allTracks
            {
                get; set;
            }
            private static bool _initialized { get; set; }
            /// <summary>
            /// Initializes the connector to the TrackList
            /// </summary>
            /// <exception cref="InvalidInitializedError"></exception>"
            public TrackCollection() : base("TrackList")
            {
                if (_initialized)
                {
                    throw new InvalidInitializedError("TrackList");
                }
                _initialized = true;

            }

            /// <summary>
            /// Returns the number of rows in the Track Table
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
                            count = db.Tracks.Count();
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
            /// Get the Track of the given id if it exists, otherwise throws an exception
            /// </summary>
            /// <param name="id"></param>
            /// <exception cref="EntityNotFoundError"></exception>
            /// <exception cref="LoadError"></exception>"
            /// <exception cref="DbUpdateException"></exception>
            public Track this[int id]
            {
                set { this.Add(value); }
                get
                {
                    try
                    {
                        if (!this.Contains(id))
                        {
                            Track result;
                            using (var db = new DataClassesContext())
                            {
                                result = (from Track a in db.Tracks
                                          where a.ID == id
                                          select a).First();


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
            /// Get the Track of the given name if it exists, otherwise throws an exception
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            /// <exception cref="EntityNotFoundError"></exception>
            public Track this[string name]
            {
                set { this.Add(value); }
                get
                {
                    try
                    {
                        if (!this.Contains(name))
                        {
                            Track result;
                            using (var db = new DataClassesContext())
                            {
                                result = (from Track a in db.Tracks
                                          where a.Name == name
                                          select a).First();


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
            /// Verifies if an Track of the given id exists
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
                        count = (from a in db.Tracks
                                 where a.ID == id
                                 select a).Count();
                    };
                    return count > 0;
                }
                catch (Exception ex)
                {
                    throw new
                        DbException(DbEntityType, $"Error verifying if Database contains Track with id {id}:\n{ex.Message}");
                }
            }

            /// <summary>
            /// Verifies if an Track of the given name exists
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
                        count = (from a in db.Tracks
                                 where a.Name == name
                                 select a).Count();
                    };
                    return count > 0;
                }
                catch (Exception ex)
                {
                    throw new
                        DbException(DbEntityType, $"Error verifying if Database contains Track with Name {name}{ex.Message}");
                }
            }

            /// <summary>
            /// Returns A list of all Existing Tracks in the database
            /// </summary>            
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public override List<Track> All
            {
                get
                {
                    try
                    {
                        _allTracks = new List<Track>();
                        using (var db = new DataClassesContext())
                        {
                            _allTracks.AddRange(from a in db.Tracks
                                                select a);
                        }
                        base._all = _allTracks;
                        return _allTracks;
                    }
                    catch (Exception ex)
                    {
                        throw new DbException($"Error loading All Tracks from database: {ex.Message}");
                    }
                }
            }
            /// <summary>
            /// Loads the Names of the existing Tracks to a List
            /// </summary>
            /// <exception cref="DbException"></exception>
            public override List<string> AllNames
            {
                get
                {
                    try
                    {
                        List<string> Tracks;
                        using (var db = new DataClassesContext())
                        {
                            Tracks = (from a in db.Tracks
                                      select a.Name).ToList();
                        }
                        return Tracks;
                    }
                    catch (Exception ex)
                    {
                        throw new DbException($"Error Loading existing Track Names: {ex.Message}");
                    }
                }
            }



            /// <summary>
            /// Submit Changes to the Database
            /// </summary>
            /// <exception cref="NullValueError"></exception>
            /// <exception cref="DbUpdateException"></exception>
            /// <exception cref="SaveError"></exception>"
            public override void Add(Track track)
            {
                if (track.Name == null || track.Name == "")
                    throw new NullValueError("Track name cannot be null.");

                try
                {
                    using (var context = new DataClassesContext())
                    {
                        context.UpdateInsert_Track(track.ID, track.Name, track.Uri, track.Length, track.ArtistId, track.CanPlayString, track.AlbumId);
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
