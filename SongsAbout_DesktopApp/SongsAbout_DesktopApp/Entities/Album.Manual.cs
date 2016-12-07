
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
        Type a = typeof(Artist);

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
        public byte[] CoverArt
        {
            get { return this.al_cover_art; }
            set { this.al_cover_art = value; }
        }
        public override string TypeName
        {
            get { return typeof(Artist).ToString(); }
        }
        public int ArtistId
        {
            get { return this.artist_id; }
            set { this.artist_id = value; }
        }
        public Image Image
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

        public override void Save()
        {
            try
            {
                if (this.name != null)
                {
                    using (var context = new DataClassesContext())
                    {
                        context.UpdateInsert_Album(this.ID, this.artist_id, this.name, this.al_year, this.al_spotify_uri, this.al_cover_art);
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

        public static Album Load(string al_title)
        {
            Album result = new Album();
            try
            {
                using (DataClassesContext context = new DataClassesContext())
                {
                    result = (Album)(from Album ab in context.Albums
                                     where ab.name == al_title
                                     select ab).First();
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
