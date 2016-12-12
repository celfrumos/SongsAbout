
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
using Image = System.Drawing.Image;

namespace SongsAbout.Entities
{
    public partial class Album : DbEntity
    {
        public static readonly string Table = "Albums";
        public static readonly string TypeString = "Album";
        public static readonly string TitleColumn = "name";
        private SpotifyEntityType _spotifyType = SpotifyEntityType.FullAlbum | SpotifyEntityType.SimpleAlbum;

        private bool? _exists = null;
        public override SpotifyEntityType SpotifyType
        {
            get { return this._spotifyType; }
            set { this._spotifyType = value; }
        }

        public override string TableName
        {
            get { return Table; }
        }

        public override string Name { get { return this.name; } set { this.name = value; } }
        public string Year
        {
            get { return this.al_year; }
            set { this.al_year = value; }
        }
        public string Uri
        {
            get { return this.al_spotify_uri; }
            set { this.al_spotify_uri = value; }
        }
        public byte[] CoverArtBytes
        {
            get { return this.al_cover_art; }
            set { this.al_cover_art = value; }
        }
        public override string TypeName
        {
            get { return typeof(Artist).ToString(); }
        }
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

        public List<Track> Tracks
        {
            get
            {
                try
                {
                    if (this.privateTracks != null)
                        return (List<Track>)this.privateTracks;
                    else
                        return new List<Track>();
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine($" Error returning album artist for {this.Name}: {ex.Message}");
                    return this._loadTracks();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error returning album artist for {this.Name}: {ex.Message}");

                    return _loadTracks();

                }
            }
            set { this.privateTracks = value; }
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
                                        select a.privateGenres);
                }

                if (res.Count > 0)
                    return res;

                else
                    return new List<Genre>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error loading Tracks for albums for {this.Name}: {ex.Message}");

                return new List<Genre>();
            }
        }
        public List<Genre> Genres
        {
            get
            {
                try
                {
                    if (this.privateGenres != null)
                        return (List<Genre>)this.privateGenres;
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
            set { this.privateGenres = value; }
        }

        public Artist Artist
        {
            get
            {
                try
                {
                    if (this.privateArtist != null)
                        return this.privateArtist;

                    else if (this.artist_id != 0)
                        return Artist.Load(this.ArtistId);

                    else
                        return new Artist();

                }
                catch (ObjectDisposedException ex)
                {
                    if (this.artist_id != 0)
                        return Artist.Load(this.ArtistId);

                    else
                        return new Artist();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error returning album artist for {this.Name}: {ex.Message}");

                    return new Artist();

                }
            }
            set
            {
                this.privateArtist = value;
                this.ArtistId = value.ID;
            }
        }
        public int ArtistId
        {
            get { return this.artist_id; }
            set
            {
                this.artist_id = value;

                this.Artist = Artist.Load(value);

            }
        }
        public Image CoverArt
        {
            get { return Converter.ImageFromBytes(this.al_cover_art); }
            set { this.al_cover_art = Converter.ImageToBytes(value); }
        }
        public List<string> GetGenres()
        {
            return (from a in this.Genres
                    select a.Name).ToList();

        }
        public void AddGenre(string genre)
        {
            if (!this.GetGenres().Contains(genre))
            {
                using (var db = new DataClassesContext())
                {
                    Genre newGenre;
                    var existingGenres = SongDatabase.ExistingGenres;
                    if (existingGenres.Contains(genre))
                    {
                        newGenre = (from g in db.Genres
                                    where g.Name == genre
                                    select g).First();
                    }
                    else
                    {
                        newGenre = new Genre(genre);
                        db.Genres.Add(newGenre);
                    }
                    this.Genres.Add(newGenre);
                    db.SaveChanges();
                }
            }
        }
        public override string TitleColumnName
        {
            get { return TitleColumn; }
        }
        public Album(FullAlbum album) : this(new FAlbum(album))
        {
        }
        public Album(FAlbum album)// : base("al_title", "Albums", "Album")
        {
            this.SpotifyType = SpotifyEntityType.FullAlbum;
            this.name = album.Name;
            this.al_spotify_uri = album.Uri;
            if (album.Artists.Count > 0)
            {
                this.UpdateArtist(album.Artists[0]);
            }
            this.al_year = null;
            // this.al_year = album.ReleaseDate;
            this.SetGenres(album.Genres);
            this.UpdateCoverArt(album);
        }
        public Album(SAlbum album) : this(new FAlbum(Converter.GetFullAlbum(album)))
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

        public override void Save()
        {
            try
            {
                if (this.name != null)
                {
                    using (var context = new DataClassesContext())
                    {
                        context.UpdateInsert_Album(this.ID, this.ArtistId, this.Name, this.Year, this.Uri, this.CoverArtBytes);
                        //     context.Albums.Add(this);
                        context.SaveChanges();
                    }

                }
                else
                {
                    Console.WriteLine($"Error saving album {this.name}, already exists");
                }
            }
            catch (Exception ex)
            {
                var e = new SaveError(this, ex.Message + "\n" + ex.InnerException.Message);
                Console.WriteLine(e.Message + e.StackTrace);
            }
        }

        /// <summary>
        /// Checks if an album with the given name exists or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Exists(string name)
        {
            int albums = 0;
            using (DataClassesContext context = new DataClassesContext())
            {
                DbEntity.formatName(ref name);
                albums = (
                   from ab in context.Albums
                   where ab.name == name
                   select ab).Count();
                // int n = base.Exists(name, context.Albums);
            }
            return albums > 0;
        }

        /// <summary>
        /// Checks if an album with the given id exists or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Exists(int id)
        {
            int albums = 0;
            using (DataClassesContext context = new DataClassesContext())
            {
                albums = (
                   from ab in context.Albums
                   where ab.ID == id
                   select ab).Count();
            }
            return albums > 0;
        }

        public static Album Load(Album album)
        {
            album.Tracks.ToList().ForEach(t => t = Track.Load(t));
            album.Tracks = album.Tracks;
            
            album.Genres = album.Genres;
            
            return album;
        }
        public static Album Load(string al_title)
        {
            Album result = new Album();
            try
            {
                using (DataClassesContext context = new DataClassesContext())
                {
                    result = (Album)(from Album ab in context.Albums
                                     where ab.name == al_title
                                     select ab).FirstOrDefault();

                    foreach (var track in result.Tracks)
                    {
                        track.Genres = track.Genres;
                        track.Artists = track.Artists;
                        track.Topics = track.Topics;
                        track.Playlists = track.Playlists;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new LoadError(result, al_title, ex.Message);
            }
        }

        public static Album Load(int album_id)
        {
            Album result = new Album();
            try
            {
                using (DataClassesContext context = new DataClassesContext())
                {
                    result = (Album)(from Album ab in context.Albums
                                     where ab.ID == album_id
                                     select ab).First();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new LoadError(result, album_id, ex.Message);
            }
        }

        public void Update(FullAlbum album)
        {
            Update(new FAlbum(album));
        }
        public void Update(SAlbum album)
        {
            try
            {
                FAlbum al = new FAlbum(User.Default.SpotifyWebAPI.GetAlbum(album.Id));
                this.Update(al);
            }
            catch (Exception ex)
            {
                throw new UpdateError(this, album.Name, ex.Message);
            }
        }

        public void Update(FAlbum album)
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
                throw new UpdateError(this, album.Name, ex.Message);
            }
        }
        private void UpdateCoverArt(FullAlbum album)
        {
            UpdateCoverArt(new FAlbum(album));
        }
        private void UpdateCoverArt(FAlbum album)
        {
            if (album.Images.Count > 0)
            {
                byte[] pic = Importer.ImportSpotifyImageBytes(album.Images[0]);
                this.al_cover_art = pic;
            }
        }
        private void UpdateArtist(SimpleArtist simpleArtist)
        {
            this.UpdateArtist(new SArtist(simpleArtist));
        }
        private void UpdateArtist(SArtist simpleArtist)
        {
            try
            {
                Artist a;
                if (!Artist.Exists(simpleArtist.Name))
                {
                    a = new Artist(simpleArtist);
                    a.Save();
                    Console.WriteLine($"Artist added: '{a.Name}'");
                }
                a = Artist.Load(simpleArtist.Name);
                this.artist_id = a.ID;
            }
            catch (Exception ex)
            {
                throw new UpdateError(this, typeof(SimpleArtist), this.name, ex.Message);

            }
        }
        public void SetGenres(List<Genre> genres)
        {
            using (var db = new DataClassesContext())
            {
                foreach (var g in genres)
                {
                    if (!this.Genres.Contains(g))
                    {
                        this.Genres.Add(g);
                        if (!db.Genres.Contains(g))
                        {
                            db.Genres.Add(g);
                        }
                    }
                }
                db.SaveChanges();
            }
        }
        public void SetGenres(List<string> genres)
        {
            using (var db = new DataClassesContext())
            {
                foreach (var g in genres)
                {
                    Genre newG = new Genre(g);
                    if (!this.Genres.Contains(newG))
                    {
                        if (!db.Genres.Contains(newG))
                        {
                            db.Genres.Add(newG);
                        }
                        this.Genres.Add(newG);
                    }
                }
                db.SaveChanges();
            }
        }
        public void SetGenres(ISpotifyFullEntity entity)
        {
            using (var db = new DataClassesContext())
            {
                foreach (string g in entity.Genres)
                {
                    Genre newG = new Genre(g);
                    if (!this.Genres.Contains(newG))
                    {
                        if (!db.Genres.Contains(newG))
                        {
                            db.Genres.Add(newG);
                        }
                        this.Genres.Add(newG);
                    }
                    db.Genres.Add(newG);
                }
                db.SaveChanges();
            }
        }
        public Album(object SpotifyEntity, SpotifyEntityType type)
        {
            try
            {
                if (type == SpotifyEntityType.SimpleAlbum | type == SpotifyEntityType.FullAlbum)
                {
                    FullAlbum album;
                    if (type == SpotifyEntityType.SimpleAlbum)
                        album = Converter.GetFullAlbum((SimpleAlbum)SpotifyEntity);
                    else
                        album = (FullAlbum)SpotifyEntity;

                    this.name = album.Name;
                    this.al_spotify_uri = album.Uri;
                    UpdateArtist(album.Artists[0]);
                    this.SetGenres(album.Genres);
                    this.UpdateCoverArt(album);
                }
                else
                {
                    throw new InitializationError(DbEntityType.Track, type, "");
                }
            }
            catch (InitializationError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InitializationError(DbEntityType.Artist, type, ex.Message);
            }
        }


    }
}
