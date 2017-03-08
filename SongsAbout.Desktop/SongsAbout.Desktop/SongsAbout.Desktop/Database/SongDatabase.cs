using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SongsAbout.Enums;
using SongsAbout.Desktop.Entities;

namespace SongsAbout.Desktop.Database
{
    /// <summary>
    /// Wrapper class to interact with database easier
    /// </summary>
    /// <exception cref="InvalidInitializedError">This class can only be initialized once</exception>
    /// <see cref="Initialize()"/>
    /// <see cref="SongDatabase.IsInitialized"/>
    public static partial class SongDatabase
    {
        private static bool _isInitialized = false;

        /// <summary>
        /// Represents if the SongDatabase has been initialized
        /// </summary>
        public static bool IsInitialized
        {
            get { return _isInitialized; }
            private set { _isInitialized = value; }
        }

        /// <summary>
        /// Set this to true if you want to not run a new query against the database;
        /// </summary>
        public static bool LargeQuery { get; set; }

        /// <summary>
        /// Single use Constructor do be used at Program Start
        /// </summary>
        /// <exception cref="InvalidInitializedError"></exception>
        public static void Initialize()
        {
            if (IsInitialized)
            {
                throw new
                    InvalidInitializedError("ArtistList", "Only one instance of the SongDatabase Class may be declared");
            }
            else
            {
                IsInitialized = true;
                LargeQuery = false;

                SongDatabase.Albums = new AlbumCollection();
                SongDatabase.Artists = new ArtistCollection();
                SongDatabase.Tracks = new TrackCollection();
                SongDatabase.Genres = new GenreCollection();
                SongDatabase.Playlists = new PlaylistCollection();
                SongDatabase.Tags = new TagCollection();
            }
        }

        /// <summary>
        /// Class to interact with the Genres table in the database
        /// </summary>
        public static GenreCollection Genres { get; private set; }

        /// <summary>
        /// Class to interact with the Tracks table in the database
        /// </summary>
        public static TrackCollection Tracks { get; private set; }

        /// <summary>
        /// Class to interact with the Albums table in the database
        /// </summary>
        public static AlbumCollection Albums { get; private set; }

        /// <summary>
        /// Class to interact with the Artists table in the database
        /// </summary>
        public static ArtistCollection Artists { get; private set; }

        /// <summary>
        /// Class to interact with the Playlists table in the database
        /// </summary>
        public static PlaylistCollection Playlists { get; private set; }

        /// <summary>
        /// Class to interact with the Tags table in the database
        /// </summary>
        public static TagCollection Tags { get; private set; }

    }
}

