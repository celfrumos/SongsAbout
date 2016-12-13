﻿
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
        private const SpotifyEntityType SPOTIFY_TYPE = SpotifyEntityType.FullAlbum | SpotifyEntityType.SimpleAlbum;
        
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
                string msg = $" Error loading Tracks for albums for {this.Name}: {ex.Message}";
                throw new LoadError(msg);
            }
        }
        public List<Genre> Genres
        {
            set
            {
                foreach (var genre in value)
                {
                    if (!this.privateGenres.Contains(genre))
                    {
                        this.privateGenres.Add(genre);
                    }

                }
            }
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
        }

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
                    return Program.Database.Artists[this.ArtistId];
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
        public int ArtistId
        {
            get { return this.artist_id; }
            set { this.artist_id = value; }
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
                Genre newGenre;
                if (!Program.Database.Genres.Contains(genre))
                {
                    Program.Database.Genres[genre] = new Genre(genre);
                }
                newGenre = Program.Database.Genres[genre];

                this.Genres.Add(newGenre);


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
                var e = new SaveError(this.DbEntityType, ex.Message + "\n" + ex.InnerException.Message);
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
                DbEntity.FormatName(ref name);
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
            try
            {
                Album result = new Album();
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
                throw new LoadError(DbEntityType.Album, al_title, ex.Message);
            }
        }

        public static Album Load(int album_id)
        {
            try
            {
                Album result = new Album();
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
                throw new LoadError(DbEntityType.Album, album_id, ex.Message);
            }
        }

        public void Update(FullAlbum album)
        {
            Update(new FAlbum(album));
        }
        public void Update(SAlbum album)
        {
            Update(new FAlbum(Converter.GetFullAlbum(album)));
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
                throw new UpdateFromSpotifyError(this.DbEntityType, SpotifyEntityType.FullAlbum, album.Name, ex.Message);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="artist"></param>
        /// <exception cref="UpdateFromSpotifyError"></exception>
        private void UpdateArtist(SArtist artist)
        {
            try
            {
                Artist newArtist;
                if (!Program.Database.Artists.Contains(artist.Name))
                {
                    Program.Database.Artists[artist.Name] = new Artist(artist);
                }

                newArtist = Program.Database.Artists[artist.Name];
                this.artist_id = newArtist.ID;
            }
            catch (Exception ex)
            {
                throw new
                    UpdateFromSpotifyError(DbEntityType.Artist, SpotifyEntityType.SimpleArtist, artist.Name,
                    $"For Album Artist on album '{artist.Name}':\n{ex.Message}");

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="genres"></param>
        public void SetGenres(List<Genre> genres)
        {
            try
            {
                using (var db = new DataClassesContext())
                {
                    foreach (var g in genres)
                    {
                        if (!this.Genres.Contains(g))
                        {
                            if (!db.Genres.Contains(g))
                            {
                                db.Genres.Add(g);
                            }
                            this.Genres.Add(g);

                        }
                    }
                    db.SaveChanges();
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
            try
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
            catch (Exception ex)
            {
                throw new
                    DbException(this.DbEntityType, $"Error Setting Album Genres for Album '{this.Name}\n{ex.Message}'");
            }
        }
        public void SetGenres(ISpotifyFullEntity entity)
        {
            try
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
            catch (Exception ex)
            {
                throw new
                    DbException(this.DbEntityType, $"Error Setting Album Genres for Album '{this.Name}\n{ex.Message}'");
            }
        }
        public Album(object SpotifyEntity, SpotifyEntityType spotifyType)
        {
            try
            {
                if (spotifyType == SpotifyEntityType.SimpleAlbum | spotifyType == SpotifyEntityType.FullAlbum)
                {
                    FullAlbum album;
                    if (spotifyType == SpotifyEntityType.SimpleAlbum)
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
