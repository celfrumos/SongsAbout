using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SongsAbout.Entities;
using SongsAbout.Enums;

namespace SongsAbout.Classes.Database
{
    public partial class SongDatabase
    {
        public class PlaylistCollection : EntityCollection<Playlist>
        {
            public override bool HasIntId { get { return false; } }
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
                    using (var db = new DataClassesContext())
                    {
                        return GetItems(db.Playlists);
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
            public  void Add(Playlist playlist, bool checkFirst = true)
            {
                if (playlist.Name == "" || playlist.Name == null)
                    throw new NullValueError("Genre name cannot be null.");

                if (checkFirst && this.Contains(playlist.Name))
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
