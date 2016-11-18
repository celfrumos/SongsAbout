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

namespace SongsAbout.Entities
{
    public partial class Album : DbEntity
    {
        public static string Table = "Albums";
        public static string TypeString = "Album";
        public static string TitleColumn = "name";
        private SpotifyEntityType _spotifyType = SpotifyEntityType.FullAlbum | SpotifyEntityType.SimpleAlbum;

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
                    using (var context = new DataClassContext())
                    {
                        context.Albums.Add(this);
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

        public static bool Exists(string a)
        {
            int albums = 0;
            using (DataClassContext context = new DataClassContext())
            {
                DbEntity.formatName(ref a);
                albums = (
                   from ab in context.Albums
                   where ab.name == a
                   select ab).Count();
            }
            return albums > 0;
        }
        public static bool Exists(int a)
        {
            int albums = 0;
            using (DataClassContext context = new DataClassContext())
            {
                albums = (
                   from ab in context.Albums
                   where ab.ID == a
                   select ab).Count();
            }
            return albums > 0;
        }



        public static Album Load(string al_title)
        {
            throw new NotImplementedException();
            // return Load(al_title);
        }

        public static Album Load(int album_id)
        {
            throw new NotImplementedException();
            //return Load(album_id);
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
