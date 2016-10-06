using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using SpotifyAPI.Web.Models;
using SongsAbout_DesktopApp.Properties;
using System.Windows.Forms;
using System.IO;
using SongsAbout_DesktopApp.Classes;

namespace SongsAbout_DesktopApp.Classes
{
    public partial class Track
    {

        public Track(FullTrack t)
        {
            this.track_name = t.Name;
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
                string msg = $"Error Updating track: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public Track(SimpleTrack track)
        {
            FullTrack t = UserSpotify.WebAPI.GetTrack(track.Id);
            this.track_name = t.Name;
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
                string msg = $"Error Updating track: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public void Save()
        {
            try
            {
                if (this.track_name != null && !Exists(this.track_name))
                {
                    //this.track_artist_id = this.Album.artist_id;
                    using (DataClassesDataContext context = new DataClassesDataContext())
                    {
                        Track t = this;
                        context.Tracks.InsertOnSubmit(t);
                        context.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error saving Track: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);

            }
        }

        public static bool Exists(string track_name)
        {
            try
            {
                int count = 0;
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    string aquery = $"SELECT * FROM Tracks WHERE track_name = '{track_name }'";
                    var tracks = db.ExecuteQuery<Track>(aquery);

                    foreach (var item in tracks)
                    {
                        count++;
                    }

                }
                return (count > 0);

            }
            catch (Exception ex)
            {
                string msg = $"Error verifying that track '{track_name}' exists: {ex.Message}";
                Console.WriteLine(msg);
                //   throw new Exception(msg);
                return true;
            }
        }

        public static bool Exists(int track_id)
        {
            try
            {
                int count = 0;
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    string aquery = $"SELECT * FROM Tracks WHERE track_id = {track_id}";
                    var tracks = db.ExecuteQuery<Track>(aquery);

                    foreach (var item in tracks)
                    {
                        count++;
                    }

                }
                return (count > 0);

            }
            catch (Exception ex)
            {
                string msg = $"Error verifying that track '{track_id}' exists: {ex.Message}";
                Console.WriteLine(msg);
                //   throw new Exception(msg);
                return true;
            }
        }

        public void SaveGenres(ref List<string> genres)
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    DataSet gen = new DataSet();

                    foreach (string g in genres)
                    {
                        TrackGenre tg = new TrackGenre();
                        tg.track_id = this.track_id;
                        tg.tg_genre = g;

                        context.TrackGenres.InsertOnSubmit(tg);
                    }

                    context.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                string msg = "Error Saving track genres: " + ex.Message;
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public void Update(FullTrack t)
        {
            try
            {
                this.track_name = t.Name;
                this.track_length_minutes = (double)(t.DurationMs) / 60000;
                this.track_spotify_uri = t.Uri;
                this.Save();
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

        public void Update(ref FullTrack t)
        {
            this.track_name = t.Name;
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
                string msg = $"Error Updating track: {ex.Message}";
                Console.WriteLine(msg);
                //throw new Exception(msg);
            }
        }

        public void UpdateArtist(SimpleArtist simpleArtist)
        {
            try
            {
                Artist a;
                TrackArtists ta = new TrackArtists();
                if (Artist.Exists(simpleArtist.Name))
                {
                    a = Artist.Load(simpleArtist.Name);
                }
                else
                {
                    a = new Artist();
                    a.Update(simpleArtist);
                    //   a.Save();
                }

                ta.Update(a.artist_id, this.track_id);
            }
            catch (Exception ex)
            {
                string msg = $"Error updating track artist: {this.track_name}: {ex.Message}";
                Console.WriteLine(msg);
                //  throw new Exception(msg);
            }
        }

        private void UpdateAlbum(SimpleAlbum album)
        {
            try
            {
                AlbumTracks at = new AlbumTracks();

                Album al;
                if (Album.Exists(album.Name))
                {
                    al = Album.Load(album.Name);
                }
                else
                {
                    al = new Album();
                    al.Update(album);
                    //al.Save();
                }
                at.Update(al.album_id, this.track_id);
                //at.Save();
            }
            catch (Exception ex)
            {
                string msg = $"Error updating track album for track: {this.track_name}: {ex.Message}";
                Console.WriteLine(msg);
                //    throw new Exception(msg);
            }
        }

        //private void UpdateAlbum(ref SimpleAlbum album)
        //{
        //    try
        //    {
        //        Album al;
        //        if (Artist.Exists(album.Name))
        //        {
        //            al = Album.Load(album.Name);
        //        }
        //        else
        //        {
        //            al = new Album();
        //            al.Update(album);
        //            al.Save();
        //        }

        //        this.album_id = al.album_id;
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = $"Error updating track album for track: {this.track_name}: {ex.Message}";
        //        Console.WriteLine(msg);
        //        //    throw new Exception(msg);
        //    }
        //}

    }
}
