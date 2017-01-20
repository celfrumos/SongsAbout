
using System;
using SpotifyAPI.Web.Models;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using SongsAbout.Classes;
using SongsAbout.Enums;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using SongsAbout.Properties;
using SongsAbout.Classes.Database;
using System.Data.Entity;

namespace SongsAbout.Entities
{
    /// <summary>
    /// Al album from the database
    /// </summary>
    public partial class Album : DbEntity
    {
        public const string Table = "Albums";
        public const string TypeString = "Album";
        public const string TitleColumn = "name";
        private const SpotifyEntityType SPOTIFY_TYPE = SpotifyEntityType.FullAlbum | SpotifyEntityType.BaseAlbum;

        public override SpotifyEntityType SpotifyType
        {
            get { return SPOTIFY_TYPE; }
        }

        public override string TableName
        {
            get { return Table; }
        }

        public override string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }


        public DateTime? ReleaseDate
        {
            get { return this.al_release_date; }
            set { this.al_release_date = value; }
        }
        /// <summary>
        /// The Year the album was released
        /// </summary>
        public string Year
        {
            get { return this.al_release_date.Value.Year.ToString(); }
            set
            {
                var date = new DateTime();
                if (DateTime.TryParse(value, out date))
                {
                    this.al_release_date = date;
                }
            }
        }
        /// <summary>
        /// The Spotify URI for this album
        /// </summary>
        public string Uri
        {
            get { return this.al_spotify_uri; }
            set { this.al_spotify_uri = value; }
        }

        /// <summary>
        /// Returns the cover art of this album as a byte array
        /// </summary>
        /// <seealso cref="CoverArt"/>
        public byte[] CoverArtBytes
        {
            get { return this.al_cover_art; }
            set { this.al_cover_art = value; }
        }

        /// <summary>
        /// Load all of the tracks of this album directly from the database
        /// </summary>
        /// <returns></returns>
        private List<Track> _loadTracks()
        {
            try
            {
                List<Track> res;
                using (var db = new DataClassesContext())
                {
                    res = (from t in db.Tracks
                           where t.AlbumId == this.ID
                           select t).ToList();
                }
                if (res.Count > 0)
                    return res;

                else
                    return new List<Track>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error loading Tracks for albums for {this.Name}: {ex.Message}");

                return new List<Track>();
            }
        }

        /// <summary>
        /// Load a list of All of the albums currently stored in the database
        /// </summary>
        /// <returns></returns>
        public static List<Album> LoadAllFromDatabase()
        {
            try
            {

                List<Album> result;
                using (var db = new DataClassesContext())
                {
                    result = db.Albums
                                    .Where(a => a.ID != 0)
                                    .Include(a => a.Tracks)
                                    .Include(a => a.Genres)
                                    .ToList();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new LoadError(DbEntityType.Album, ex.Message);
            }
        }

        /// <summary>
        /// Returns the tracks for this album as a list
        /// </summary>
        public List<Track> TrackList
        {
            get { return this.Tracks.ToList(); }
            set { this.Tracks = value; }
        }

        private List<Genre> _loadGenres()
        {
            try
            {
                List<Genre> res;
                using (var db = new DataClassesContext())
                {
                    res = (List<Genre>)(from a in db.Albums
                                        where a.ID == this.ID
                                        select a.Genres);
                }

                if (res.Count > 0)
                    return res;

                else
                    return new List<Genre>();
            }
            catch (Exception ex)
            {
                string msg = $" Error loading Tracks for albums for {this.Name}: {ex.Message}";
                throw new LoadError(msg);
            }
        }

        /// <summary>
        /// Returns the genres for this Album as a list
        /// </summary>
        public List<Genre> GenreList
        {
            set
            {
                foreach (var genre in value)
                {
                    if (!this.Genres.Contains(genre))
                    {
                        this.Genres.Add(genre);
                    }

                }
            }
            get
            {
                try
                {
                    if (this.Genres != null)
                        return (List<Genre>)this.Genres;
                    else
                        return new List<Genre>();
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine($" Error returning album artist for {this.Name}: {ex.Message}");
                    return this._loadGenres();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error returning album artist for {this.Name}: {ex.Message}");

                    return _loadGenres();

                }
            }
        }


        /// <summary>
        /// Returns the Main Artist of this Album
        /// </summary>
        public Artist Artist
        {
            set
            {
                this.privateArtist = value;
                this.ArtistId = value.ID;
            }
            get
            {
                try
                {
                    return SongDatabase.Artists[this.ArtistId];
                }
                catch (ObjectDisposedException ex)
                {
                    throw new LoadError(DbEntityType.Artist, this.ArtistId, ex.Message);
                }
                catch (Exception ex)
                {
                    string msg = $" Error returning album artist for {this.Name}: {ex.Message}";

                    throw new LoadError(DbEntityType.Artist, this.ArtistId, msg);

                }
            }
        }

        /// <summary>
        /// Get the id of the main Artist for this Album
        /// </summary>
        public int ArtistId
        {
            get { return this.artist_id; }
            set { this.artist_id = value; }
        }
        private Image _coverArtImage;

        /// <summary>
        /// Returns a Bitmap of this Albums Cover Art
        /// </summary>
        public Image CoverArt
        {
            get
            {
                return this._coverArtImage ?? Converter.ImageFromBytes(al_cover_art);
            }
            set
            {
                _coverArtImage = value;
                this.al_cover_art = Converter.ImageToBytes(_coverArtImage);
            }
        }

        /// <summary>
        /// Returns a list of this Album's Genres as strings
        /// </summary>
        /// <returns></returns>
        public List<string> GetGenres()
        {
            return (from a in this.GenreList
                    select a.Name).ToList();

        }

        /// <summary>
        /// Add's a Genre to the Album, and to the Database if it doesn't already exist
        /// </summary>
        /// <param name="genre"></param>
        public void AddGenre(string genre)
        {
            if (!this.GetGenres().Contains(genre))
            {
                if (!SongDatabase.Genres.Contains(genre))
                {
                    SongDatabase.Genres.Add(genre);
                }
                this.GenreList.Add(genre);


            }
        }

        public override string TitleColumnName
        {
            get { return TitleColumn; }
        }
        public Album(SpotifyFullAlbum album)// : this(new SpotifyAlbum(album))
        {
            this.Name = album.Name;
            this.Uri = album.Uri;
            if (album.Artists.Count > 0)
            {
                this.UpdateArtist(album.Artists[0]);
            }
            // var s = DateTime.Parse( album.ReleaseDate).Date;
            // this.Year = null;
            this.ReleaseDate = album.ReleaseDate;
            this.SetGenres(album.Genres);
            this.UpdateCoverArt(album);
        }

        public Album(SpotifyAlbum album) : this(
            album.SpotifyEntityType == SpotifyEntityType.FullAlbum
            ? (SpotifyFullAlbum)album
            : album.GetFullVersion(UserSpotify.WebAPI))// : base("al_title", "Albums", "Album")
        {
        }

        public Album(int id, int artist_id, string name, string year, string uri, Image coverArt)
        {
            this.ID = id;
            this.ArtistId = artist_id;
            this.Name = name;
            this.Year = year;
            this.Uri = uri;
            this.CoverArtBytes = Converter.ImageToBytes(coverArt);
        }

        /// <summary>
        /// Save the Album to the Database
        /// </summary>
        /// <exception cref="NullValueError"></exception>
        /// <exception cref="SaveError"></exception>
        public override void Save()
        {
            try
            {
                SongDatabase.Albums.Add(this);
            }
            catch (NullValueError)
            {
                throw;
            }
            catch (SaveError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SaveError(DbEntityType.Album, this.name, ex.Message);
            }
        }

        /// <summary>
        /// Checks if an album with the given name exists or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NullValueError"></exception>
        public static bool Exists(string name)
        {
            if (name == "" || name == null)
                throw new NullValueError(DbEntityType.Album, "name");
            return SongDatabase.Albums[name] != null;
        }

        /// <summary>
        /// Checks if an album with the given id exists or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// /// <exception cref="NullValueError"></exception>
        public static bool Exists(int id)
        {
            if (id == 0)
                throw new NullValueError(DbEntityType.Album, "id");

            return SongDatabase.Albums[id] != null;
        }

        public static Album Load(Album album)
        {
            return Album.Load(album.name);
        }
        /// <summary>
        /// Load an Artist From the database. Throws an error if it returns  null from the database
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        /// <exception cref="NullValueError"></exception>
        /// <exception cref="EntityNotFoundError"></exception>
        /// <exception cref="LoadError"></exception>
        public static Album Load(string title)
        {
            if (title == "" || title == null)
                throw new NullValueError(DbEntityType.Album, "name");

            try
            {
                var result = SongDatabase.Albums[title];

                if (result == null)
                    throw new EntityNotFoundError(DbEntityType.Album, title);

                return result;
            }
            catch (Exception ex)
            {
                throw new LoadError(DbEntityType.Album, title, ex.Message);
            }
        }

        /// <summary>
        /// Load an Artist From the database. Throws an error if it returns  null from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NullValueError"></exception>
        /// <exception cref="EntityNotFoundError"></exception>
        /// <exception cref="LoadError"></exception>
        internal static Album Load(int id)
        {
            if (id == 0 || id == null)
                throw new NullValueError(DbEntityType.Album, "name");

            try
            {

                var results = SongDatabase.Albums
                    .Items
                    .Where(a => a.ID == id);

                if (results.Count() == 0)
                    return null;

                return results.FirstOrDefault();

                var result = SongDatabase.Albums[id];

                if (result == null)
                    throw new EntityNotFoundError(DbEntityType.Album, id);

                return result;
            }
            catch (Exception ex)
            {
                throw new LoadError(DbEntityType.Album, id, ex.Message);
            }
        }

        public void Update(SpotifyFullAlbum album)
        {
            try
            {
                this.name = album.Name;
                this.al_spotify_uri = album.Uri;
                UpdateArtist(album.Artists[0]);
                this.SetGenres(album.Genres);
                this.UpdateCoverArt(album);

                this.Save();
                Console.WriteLine($"Album updated: '{album.Name}'");
            }
            catch (Exception ex)
            {
                throw new UpdateFromSpotifyError(this.DbEntityType, SpotifyEntityType.FullAlbum, album.Name, ex.Message);
            }
        }
        //public void Update(FAlbum album)
        //{
        //    Update(new FAlbum(Converter.GetFullAlbum(album)));
        //}

        public void Update(SpotifyAlbum album)
        {
            if (album.SpotifyEntityType == SpotifyEntityType.FullAlbum)
            {
                Update((SpotifyFullAlbum)album);
            }
            else
            {
                Update(album.GetFullVersion(UserSpotify.WebAPI));
            }

        }

        private void UpdateCoverArt(SpotifyAlbum album)
        {
            try
            {
                if (album.Images.Count > 0)
                {
                    UpdateCoverArt(album.Images[0]);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Updating Cover Art: {ex.Message}");
            }

        }

        private void UpdateCoverArt(SpotifyImage spotifyImage)
        {
            this.CoverArt = spotifyImage;
        }

        public static implicit operator Album(SpotifyAlbum a)
        {
            return new Album(a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="artist"></param>
        /// <exception cref="UpdateFromSpotifyError"></exception>
        private void UpdateArtist(SpotifyArtist artist)
        {
            try
            {
                Artist newArtist = SongDatabase.Artists[artist.Name];
                if (newArtist == null)
                {
                    SongDatabase.Artists[artist.Name] = new Artist(artist);
                }

                newArtist = SongDatabase.Artists[artist.Name];
                this.Artist = newArtist;
                //  this.ArtistId = newArtist.ID;
            }
            catch (Exception ex)
            {
                throw new
                    UpdateFromSpotifyError(DbEntityType.Artist, SpotifyEntityType.BaseArtist, artist.Name,
                    $"For Album Artist on album '{artist.Name}':\n{ex.Message}");

            }
        }
        /// <summary>
        /// Sets the genres for this album from the passed in list
        /// </summary>
        /// <param name="genres"></param>
        public void SetGenres(List<Genre> genres)
        {
            try
            {
                var existingGenres = SongDatabase.Genres.Items;
                foreach (var g in genres)
                {
                    if (!this.GenreList.Contains(g))
                    {
                        if (!existingGenres.Contains(g))
                        {
                            SongDatabase.Genres.Add(g);
                        }
                        this.GenreList.Add(g);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new
                    DbException(this.DbEntityType, $"Error Setting Album Genres for Album '{this.Name}\n{ex.Message}'");
            }
        }
        public void SetGenres(List<string> genres)
        {
            if (genres != null && genres.Count > 0)
            {
                try
                {
                    var existingGenres = SongDatabase.Genres.AllNames;
                    foreach (var genre in genres)
                    {
                        if (!this.GenreList.Contains(genre))
                        {
                            if (!existingGenres.Contains(genre))
                            {
                                SongDatabase.Genres.Add(genre);
                            }
                            this.GenreList.Add(genre);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new
                        DbException(this.DbEntityType, $"Error Setting Album Genres for Album '{this.Name}\n{ex.Message}'");
                }
            }
        }
        public Album(SpotifyAlbum spotifyAlbum, SpotifyEntityType spotifyType)
        {
            try
            {
                if (spotifyType == SpotifyEntityType.BaseAlbum | spotifyType == SpotifyEntityType.FullAlbum)
                {
                    SpotifyFullAlbum album;
                    if (spotifyType == SpotifyEntityType.BaseAlbum)
                        album = spotifyAlbum.GetFullVersion(UserSpotify.WebAPI);
                    else
                        album = (SpotifyFullAlbum)spotifyAlbum;

                    this.name = album.Name;
                    this.al_spotify_uri = album.Uri;
                    UpdateArtist(album.Artists[0]);
                    this.SetGenres(album.Genres);
                    this.UpdateCoverArt(album);
                }
                else
                {
                    throw new DbInitFromSpotifyError(this.DbEntityType, spotifyType);
                }
            }
            catch (DbInitFromSpotifyError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DbInitFromSpotifyError(this.DbEntityType, spotifyType, ex.Message);
            }
        }


    }
}
