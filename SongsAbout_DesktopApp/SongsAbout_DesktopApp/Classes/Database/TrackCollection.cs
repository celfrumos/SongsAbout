using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SongsAbout.Enums;
using SongsAbout.Entities;

namespace SongsAbout.Classes.Database
{
    public partial class SongDatabase
    {
        public class TrackCollection : EntityCollection<Track>, IEntityIdAccessor<Track>
        {
            public override DbEntityType DbEntityType { get { return DbEntityType.Track; } }
         
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
            /// Get the Track of the given id if it exists, otherwise throws an exception
            /// </summary>
            /// <param name="id"></param>
            /// <exception cref="NullValueError"></exception>
            /// <exception cref="LoadError"></exception>"
            public Track this[int id]
            {
                set { this.Add(value); }
                get
                {
                    if (id == 0)
                        throw new NullValueError(this.DbEntityType, "name");

                    try
                    {
                        var results = this.Items.Where(t => t.ID == id);

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
            /// Verifies if an Track of the given id exists
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public bool Contains(int id)
            {
                try
                {
                    return this.Items
                           .Where(t => t.ID == id)
                           .Count() > 0;
                }
                catch (Exception ex)
                {
                    throw new
                        DbException(DbEntityType, $"Error verifying if Database contains Track with id {id}:\n{ex.Message}");
                }
            }

            /// <summary>
            /// Returns A list of all Existing Tracks in the database
            /// </summary>            
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public override List<Track> Items
            {
                get
                {
                    try
                    {
                        base._all = new List<Track>();
                        using (var db = new DataClassesContext())
                        {
                            base._all.AddRange(from a in db.Tracks
                                               where a.ID != 0
                                               select a);
                        }
                        return base._all;
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
                        return (from t in this.Items
                                select t.Name).ToList();
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                    throw new SaveError(ex.Message);
                }

            }

        }
    }

}
