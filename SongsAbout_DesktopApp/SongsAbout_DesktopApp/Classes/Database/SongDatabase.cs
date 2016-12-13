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


                _albums = new AlbumCollection();
                _artists = new ArtistCollection();
            }
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


        public AlbumCollection Albums
        {
            get { return _albums; }
            
        }
        public ArtistCollection Artists
        {
            get { return _artists; }
        }

    }
}

