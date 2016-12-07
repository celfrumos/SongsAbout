using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using SpotifyAPI.Web.Models;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using SongsAbout.Classes;
using SongsAbout.Enums;
using SongsAbout.Properties;
using SongsAbout.Controls;
using System.Windows;
using SongsAbout;
using SongsAbout.Classes;
using SongsAbout.Entities;
using SongsAbout.Properties;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;

namespace SongsAbout.Classes
{
    public static class SongDatabase
    {
        public static List<string> ExistingGenres
        {
            get
            {
                List<string> genres;
                using (var db = new DataClassesContext())
                {
                    genres = (from Genre g in db.Genres
                              select g.Name).ToList();
                }
                return genres;
            }
        }

        public static bool EditAlbum(Album album)
        {
            try
            {
                using (var db = new DataClassesContext())
                {
                    db.UpdateInsert_Album(album.ID, album.Artist.ID, album.Name, album., album.al_spotify_uri, album.al_cover_art);
                    db.SaveChanges();

                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Editing Album: {ex.Message}");
                return false;
            }

        }

        public static bool EditArtist(Artist artist)
        {
            try
            {
                using (var db = new DataClassesContext())
                {
                    db.UpdateInsert_Artist(artist.ID, artist.name, artist.a_bio, artist.a_website, artist.a_spotify_uri, artist.a_profile_pic);
                    db.SaveChanges();

                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Editing Artist: {ex.Message}");
                return false;
            }
        }

        public static List<Artist> ExistingArtists
        {
            get
            {
                List<Artist> artists;
                using (var db = new DataClassesContext())
                {
                    artists = (from a in db.Artists
                               select a).ToList();
                }
                return artists;
            }
        }

        public static List<string> ExistingArtistNames
        {
            get
            {
                List<string> artists;
                using (var db = new DataClassesContext())
                {
                    artists = (from a in db.Artists
                               select a.Name).ToList();
                }
                return artists;
            }
        }

        public static List<Album> ExistingAlbums
        {
            get
            {
                List<Album> albums;
                using (var db = new DataClassesContext())
                {
                    albums = (from a in db.Albums
                              select a).ToList();
                }
                return albums;
            }
        }

        public static List<string> ExistingAlbumNames
        {
            get
            {
                List<string> albums;
                using (var db = new DataClassesContext())
                {
                    albums = (from a in db.Albums
                              select a.Name).ToList();
                }
                return albums;
            }
        }
    }
}
