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
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
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
        public Album(SpotifyFullAlbum album) : this(new SpotifyAlbum(album))
        {
        }
        public Album(SpotifyAlbum album)// : base("al_title", "Albums", "Album")
        {
            this.Name = album.Name;
            this.Uri = album.Uri;
            if (album.Artists.Count > 0)
            {
                this.UpdateArtist(album.Artists[0]);
            }
            this.Year = null;
            // this.al_year = album.ReleaseDate;
            this.SetGenres(album.Genres);
            this.UpdateCoverArt(album);
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
                Program.Database.Albums.Add(this);
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
            return Program.Database.Albums[name] != null;
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

            return Program.Database.Albums[id] != null;
        }

        public static Album Load(Album album)
        {
            //    album.Tracks.ToList().ForEach(t => t = Track.Load(t));
            //    album.Tracks = album.Tracks;

            //    album.Genres = album.Genres;

            return album;
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
                var result = Program.Database.Albums[title];

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
        public static Album Load(int id)
        {
            if (id == 0 || id == null)
                throw new NullValueError(DbEntityType.Album, "name");

            try
            {
                var result = Program.Database.Albums[id];

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
            Update(new SpotifyAlbum(album));
        }
        //public void Update(FAlbum album)
        //{
        //    Update(new FAlbum(Converter.GetFullAlbum(album)));
        //}

        public void Update(SpotifyAlbum album)
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
        private void UpdateCoverArt(SpotifyFullAlbum album)
        {
            UpdateCoverArt(new SpotifyAlbum(album));
        }
        private void UpdateCoverArt(SpotifyAlbum album)
        {
            try
            {
                if (album.Images.Count > 0)
                {
                    byte[] pic = Importer.ImportSpotifyImageBytes(album.Images[0]);
                    this.al_cover_art = pic;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Updating Cover Art: {ex.Message}");
            }
        }
        private void UpdateArtist(SpotifyArtist simpleArtist)
        {
            this.UpdateArtist(new SpotifyArtist(simpleArtist));
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
                Artist newArtist;
                if (!Program.Database.Artists.Contains(artist.Name))
                {
                    Program.Database.Artists[artist.Name] = new Artist(artist);
                }

                newArtist = Program.Database.Artists[artist.Name];
                this.privateArtist = newArtist;
                this.ArtistId = newArtist.ID;
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
                var existingGenres = Program.Database.Genres.Items;
                foreach (var g in genres)
                {
                    if (!this.Genres.Contains(g))
                    {
                        if (!existingGenres.Contains(g))
                        {
                            Program.Database.Genres.Add(g);
                        }
                        this.Genres.Add(g);
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
                    var existingGenres = Program.Database.Genres.AllNames;
                    foreach (var g in genres)
                    {
                        if (!this.Genres.Any(gen => gen.Name == g))
                        {
                            Genre newG = new Genre(g);
                            if (!existingGenres.Contains(g))
                            {
                                Program.Database.Genres.Add(newG);
                            }
                            this.Genres.Add(newG);
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
        public void SetGenres(ISpotifyFullEntity entity)
        {
            try
            {
                var existingGenres = Program.Database.Genres.AllNames;
                foreach (var g in entity.Genres)
                {
                    if (!this.Genres.Any(gen => gen.Name == g))
                    {
                        Genre newG = new Genre(g);
                        if (!existingGenres.Contains(g))
                        {
                            Program.Database.Genres.Add(newG);
                        }
                        this.Genres.Add(newG);
                    }
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
                if (spotifyType == SpotifyEntityType.BaseAlbum | spotifyType == SpotifyEntityType.FullAlbum)
                {
                    SpotifyFullAlbum album;
                    if (spotifyType == SpotifyEntityType.BaseAlbum)
                        album = Converter.GetFullAlbum((SpotifyAlbum)SpotifyEntity);
                    else
                        album = (SpotifyFullAlbum)SpotifyEntity;

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
