using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using SpotifyAPI.Web.Models;
using System.Windows.Forms;
using System.IO;
using SongsAbout.Properties;
using SongsAbout.Enums;
using SongsAbout.Classes;

namespace SongsAbout.Entities
{
    public partial class Track : DbEntity //: DbEntity<Track>
    {

        public static string Table = "Tracks";
        public static string TypeString = "Track";
        public static string TitleColumn = "name";
        Type a = typeof(Track);

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
        public Track(FullTrack t)
        {

            this.name = t.Name;
            this.track_length_minutes = (double)(t.DurationMs) / 60000;
            this.track_spotify_uri = t.Uri;

            try
            {
                SimpleArtist tArtist = t.Artists[0];
                UpdateArtist(tArtist);
                UpdateAlbum(t.Album);
            }
            catch (Exception ex)
            {
                throw new UpdateError(this, t.Name, ex.Message);
            }
        }

        public Track(SimpleTrack track)
        {
            FullTrack t = UserSpotify.WebAPI.GetTrack(track.Id);
            this.name = t.Name;
            this.track_length_minutes = (double)(t.DurationMs) / 60000;
            this.track_spotify_uri = t.Uri;
            try
            {
                UpdateAlbum(t.Album);
                SimpleArtist tArtist = t.Artists[0];
                UpdateArtist(tArtist);
            }
            catch (Exception ex)
            {
                throw new UpdateError(this, track.Name, ex.Message);
            }
        }

        public override void Save()
        {
            try
            {
                if (this.name != null)
                {
                    using (var db = new DataClassesContext())
                    {
                        // db.Tracks.Add(this);
                        db.UpdateInsert_Track(this.ID, this.name, this.track_spotify_uri, this.track_length_minutes, this.track_artist_id, this.can_play, this.track_album_id);
                        db.SaveChanges();
                        Console.WriteLine($"Successfully saved track '{name}'");
                    }
                }
                else
                {
                    throw new Exception("Track name can't be null");
                }
            }
            catch (Exception ex)
            {
                throw new SaveError(this, this.Name, ex.Message);

            }
        }

        public static bool Exists(string name)
        {
            int tracks = 0;
            using (DataClassesContext context = new DataClassesContext())
            {
                formatName(ref name);
                tracks = (
                   from t in context.Tracks
                   where t.name == name
                   select t).Count();
            }
            return tracks > 0;
        }

        public static bool Exists(int a)
        {
            int tracks = 0;
            using (DataClassesContext context = new DataClassesContext())
            {
                tracks = (
                   from ab in context.Tracks
                   where ab.ID == a
                   select ab).Count();
            }
            return tracks > 0;

        }

        public void Update(FullTrack t)
        {
            try
            {
                this.name = t.Name;
                this.track_length_minutes = (double)(t.DurationMs) / 60000;
                this.track_spotify_uri = t.Uri;
                UpdateAlbum(t.Album);
                UpdateArtist(t.Artists[0]);
            }
            catch (Exception ex)
            {
                string msg = $"Error Updating track: {ex.Message}";
                Console.WriteLine(msg);
                //throw new Exception(msg);
            }
        }

        public void UpdateArtist(SimpleArtist artist)
        {
            try
            {
                Artist a;
                if (!Artist.Exists(artist.Name))
                {
                    a = new Artist(artist);
                    a.Save();
                }
                a = Artist.Load(artist.Name);

                this.track_artist_id = a.ID;

            }
            catch (Exception ex)
            {
                string msg = $"Error updating track artist: {this.name}: {ex.Message}";
                Console.WriteLine(msg);
                //  throw new Exception(msg);
            }
        }
        public void UpdateArtist(FullArtist artist)
        {
            try
            {
                Artist a;
                if (Artist.Exists(artist.Name))
                {
                    a = Artist.Load(artist.Name);
                }
                else
                {
                    a = new Artist(artist);
                    a.Save();
                    //al.Save();
                }
                this.track_artist_id = a.ID;

                //ta.Update(a.artist_id, this.track_id);
            }
            catch (Exception ex)
            {
                string msg = $"Error updating track artist: {this.name}: {ex.Message}";
                Console.WriteLine(msg);
                //  throw new Exception(msg);
            }
        }

        private void UpdateAlbum(SimpleAlbum album)
        {
            try
            {
                Album al;
                if (!Album.Exists(album.Name))
                {
                    al = new Album(album);
                    al.Save();
                }

                al = Album.Load(album.Name);
                this.track_album_id = al.ID;
            }
            catch (Exception ex)
            {
                string msg = $"Error updating track album for track: {this.name}: {ex.Message}";
                Console.WriteLine(msg);
            }
        }
        private void UpdateAlbum(FullAlbum album)
        {
            try
            {
                Album al;
                if (Album.Exists(album.Name))
                {
                    al = new Album(album);
                    al.Save();
                }

                al = Album.Load(album.Name);
                this.track_album_id = al.ID;
            }
            catch (SaveError ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (LoadError ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                string msg = $"Error updating track album for track: {this.name}: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }
        
        public Track(object SpotifyEntity, SpotifyEntityType type)
        {
            try
            {
                if (type == SpotifyEntityType.SimpleTrack || type == SpotifyEntityType.FullTrack)
                {
                    FullTrack t;
                    if (type == SpotifyEntityType.SimpleArtist)
                        t = Converter.GetFullTrack((SimpleTrack)SpotifyEntity);
                    else
                        t = (FullTrack)SpotifyEntity;

                    this.name = t.Name;
                    this.track_length_minutes = (double)(t.DurationMs) / 60000;
                    this.track_spotify_uri = t.Uri;
                    UpdateAlbum(t.Album);
                    UpdateArtist(t.Artists[0]);
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
