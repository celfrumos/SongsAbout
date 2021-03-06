﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SongsAbout.Desktop.Entities;
using SongsAbout.Enums;

namespace SongsAbout.Desktop.Database
{
    public partial class SongDatabase
    {
        public class PlaylistCollection : EntityCollection<Playlist>
        {
            public override bool HasIntId { get { return false; } }
            public override DbEntityType DbEntityType { get { return DbEntityType.Playlist; } }
            private static bool _initialized { get; set; }
            private static bool _itemsHaveBeen { get; set; }

            private const string COLLECTION_NAME = "PlaylistCollection";


            protected override Playlist FindByName(string name)
            {
                Playlist result;
                if (SongDatabase.LargeQuery && this.CachedItems != null && this.CachedItems.Any(p => p.Name == name))
                {
                    result = this.CachedItems.Where(p => p.Name == name).FirstOrDefault();
                }
                else
                {
                    using (var db = new DbEntityContext())
                    {
                        result = db.Playlists.Find(name);
                    }
                }
                return result;
            }

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
                this.CachedItems = null;

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
                    if (SongDatabase.LargeQuery && this.CachedItems != null)
                    {
                        return this.CachedItems;
                    }
                    else
                    {
                        return this.CachedItems = Playlist.LoadAllFromDatabase();
                    }
                }
                protected set
                {
                    base.CachedItems = value;
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
                if (playlist.Name == null || playlist.Name == "")
                    throw new NullValueError("Genre name cannot be null.");

                if (!SongDatabase.LargeQuery && this.Contains(playlist.Name))
                    throw new ValueAlreadyPresentException(DbEntityType, playlist.Name);

                try
                {
                    if (playlist.Tracks == null)
                    {
                        playlist.Tracks = new List<Track>();
                    }
                    using (var db = new DbEntityContext())
                    {
                        db.Playlists.Add(playlist);
                        db.SaveChanges();
                    }
                    
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    Exception eFinal = ex;
                    Console.WriteLine(ex.Message);
                    var e = ex.InnerException;
                    while (e != null)
                    {
                        eFinal = e;
                        var type = e.GetType();
                        if (type.FullName == "System.Data.SqlClient.SqlException")
                        {
                            var sqlE = e as System.Data.SqlClient.SqlException;
                            Console.WriteLine(e.Message);
                            if (sqlE.Message.Contains($@"Violation of PRIMARY KEY constraint"))
                            {
                                Update(playlist);
                                return;
                            }

                        }
                        e = e.InnerException;

                    }
                    throw eFinal;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                    throw new DbException(ex.Message);
                }
            }

            private void Update(Playlist playlist)
            {
                try
                {
                    using (var db = new DbEntityContext())
                    {
                        var p = db.Playlists.Find(playlist.Name);
                        if (p == playlist)
                        {

                        }
                        p = playlist;
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
