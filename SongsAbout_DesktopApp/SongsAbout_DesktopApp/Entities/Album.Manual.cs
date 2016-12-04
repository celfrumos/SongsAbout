
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

        public override string Name { get; set; }

        public override string TypeName
        {
            get { return typeof(Artist).ToString(); }
        }
        public Image Image { get { return Converter.ImageFromBytes(this.al_cover_art); } }
        public override string TitleColumnName
        {
            get { return TitleColumn; }
        }
        public Album(FullAlbum album)// : base("al_title", "Albums", "Album")
        {
            this.SpotifyType = SpotifyEntityType.FullAlbum;
            this.name = album.Name;
            this.al_spotify_uri = album.Uri;
            if (album.Artists.Count > 0)
            {
                this.UpdateArtist(album.Artists[0]);
            }
            this.SetGenres(album.Genres);
            this.UpdateCoverArt(album);
        }
        public Album(SimpleAlbum album) : this(Converter.GetFullAlbum(album))
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

        public void Update(SimpleAlbum album)
        {
            try
            {
                FullAlbum al = User.Default.SpotifyWebAPI.GetAlbum(album.Id);
                this.Update(al);
            }
            catch (Exception ex)
            {
                throw new UpdateError(this, album.Name, ex.Message);
            }
        }

        public void Update(FullAlbum album)
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

        public void Update(ref FullAlbum album)
        {
            try
            {
                this.name = album.Name;
                this.al_spotify_uri = album.Uri;
                this.UpdateArtist(album.Artists[0]);
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
            if (album.Images.Count > 0)
            {
                byte[] pic = Importer.ImportSpotifyImageBytes(album.Images[0]);
                this.al_cover_art = pic;
            }
        }

        //private void ImportAlbumTracks(Paging<SimpleTrack> tracks)
        //{
        //    foreach (SimpleTrack track in tracks.Items)
        //    {
        //        try
        //        {
        //            Importer.ImportTrack(track);
        //            Console.WriteLine($"Imported track '{track.Name}'");
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //}

        private void UpdateArtist(SimpleArtist simpleArtist)
        {
            try
            {
                Artist a;
                if (Artist.Exists(simpleArtist.Name))
                {
                    a = Artist.Load(simpleArtist.Name);
                }
                else
                {
                    a = new Artist(simpleArtist);
                    a.Save();
                    Console.WriteLine($"Artist added: '{a.name}'");
                }
                this.artist_id = a.ID;
            }
            catch (Exception ex)
            {
                throw new UpdateError(this, typeof(SimpleArtist), this.name, ex.Message);

            }
        }

        public void SetGenres(List<string> genres)
        {
            //foreach (string g in genres)
            //{
            //    AlbumGenre ag = new AlbumGenre();
            //    ag.album_id = this.album_id;
            //    ag.genre = g;

            //}
        }

    }
}
