using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SongsAbout.Enums;
using SongsAbout.Entities;

namespace SongsAbout.Classes
{
    /// <summary>
    /// Wrapper class to interact with database easier
    /// </summary>
    /// <exc cref="AlreadyInitializedError">Only </remarks>
    public partial class SongDatabase
    {
        private static bool isInitialized = false;
        /// <summary>
        /// Single use Constructor at Program Start
        /// </summary>
        /// <exception cref="AlreadyInitializedError"></exception>
        public SongDatabase()
        {
            if (isInitialized)
            {
                throw new
                    AlreadyInitializedError("ArtistList", "Only one instance of the SongDatabase Class may be declared");
            }
            isInitialized = true;
        }


        public List<string> ExistingGenres
        {
            get
            {
                try
                {
                    List<Genre> genres;
                    using (var db = new DataClassesContext())
                    {
                        genres = (from Genre g in db.Genres
                                  select g).ToList();
                    }
                    return new List<string>();
                }
                catch (Exception ex)
                {

                    throw new DbException($"Error Getting existing genres: {ex.Message}");
                }
            }
        }


        private AlbumList _albums = new AlbumList();
        private ArtistList _artists = new ArtistList();
        public AlbumList Albums
        {
            get { return _albums; }
        }

        public ArtistList Artists
        {
            get { return _artists; }
        }

    }
}

