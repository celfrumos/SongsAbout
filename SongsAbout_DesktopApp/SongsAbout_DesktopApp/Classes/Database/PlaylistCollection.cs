﻿using System;
using System.Collections.Generic;
using System.Linq;
using SongsAbout.Entities;
using SongsAbout.Enums;

namespace SongsAbout.Classes.Database
{
    public partial class SongDatabase
    {
        public class PlaylistCollection : EntityCollection<Playlist>, IEntityNameAccessor<Playlist>
        {
            public override DbEntityType DbEntityType { get { return DbEntityType.Playlist; } }
            private static bool _initialized { get; set; }

            private const string COLLECTION_NAME = "PlaylistCollection";



            /// <summary>
            /// Initializes the connector to the GenreList
            /// </summary>
            /// <exception cref="InvalidInitializedError"></exception>"
            public PlaylistCollection() : base(COLLECTION_NAME)
            {
                if (_initialized)
                {
                    throw new InvalidInitializedError(COLLECTION_NAME);
                }
                _initialized = true;

            }

            /// <summary>
            /// Returns A list of all Existing Genres in the database
            /// </summary>            
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public override List<Playlist> Items
            {
                get
                {
                    try
                    {
                        base._all = new List<Playlist>();
                        using (var db = new DataClassesContext())
                        {
                            base._all.AddRange(from a in db.Playlists
                                               select a);
                        }
                        return base._all;
                    }
                    catch (Exception ex)
                    {
                        throw new DbException($"Error loading All Genres from database: {ex.Message}");
                    }
                }
            }

            /// <summary>
            /// Submit Changes to the Database
            /// </summary>
            /// <exception cref="NullValueError"></exception>
            /// <exception cref="ValueAlreadyPresentException"></exception>"
            /// <exception cref="DbException"></exception>"
            public override void Add(Playlist playlist)
            {
                if (playlist.Name == "" || playlist.Name == null)
                    throw new NullValueError("Genre name cannot be null.");

                if (this.Contains(playlist.Name))
                    throw new ValueAlreadyPresentException(DbEntityType, playlist.Name);

                try
                {
                    using (var db = new DataClassesContext())
                    {
                        db.Playlists.Add(playlist);
                        db.SaveChanges();
                    }
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
