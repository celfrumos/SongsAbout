using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SongsAbout.Enums;
using SongsAbout.Entities;

namespace SongsAbout.Classes.Database
{
    /// <summary>
    /// Wrapper class to interact with database easier
    /// </summary>
    /// <exc cref="InvalidInitializedError">Only </remarks>
    public partial class SongDatabase
    {
        static bool isInitialized = false;
        private AlbumCollection _albums;
        private ArtistCollection _artists;
        private TrackCollection _tracks;
        private GenreCollection _genres;
        private PlaylistCollection _playlists;
        private TagCollection _tags;
        public bool LargeQuery { get; set; }
        /// <summary>
        /// Single use Constructor at Program Start
        /// </summary>
        /// <exception cref="InvalidInitializedError"></exception>
        public SongDatabase()
        {
            if (isInitialized)
            {
                throw new
                    InvalidInitializedError("ArtistList", "Only one instance of the SongDatabase Class may be declared");
            }
            else
            {
                isInitialized = true;
                LargeQuery = false;

                _albums = new AlbumCollection();
                _artists = new ArtistCollection();
                _tracks = new TrackCollection();
                _genres = new GenreCollection();
                _playlists = new PlaylistCollection();
                _tags = new TagCollection();
            }
        }

        public GenreCollection Genres { get { return _genres; } }
        public TrackCollection Tracks { get { return _tracks; } }
        public AlbumCollection Albums { get { return _albums; } }
        public ArtistCollection Artists { get { return _artists; } }
        public PlaylistCollection Playlists { get { return _playlists; } }
        public TagCollection Tags { get { return _tags; } }

    }
}

