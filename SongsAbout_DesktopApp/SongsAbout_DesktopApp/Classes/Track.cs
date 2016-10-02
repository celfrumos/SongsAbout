﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Models;
using System.Windows.Forms;
using System.IO;

namespace SongsAbout_DesktopApp
{
    public partial class Track
    {
        public void Save()
        {
            try
            {
                if (this.track_name != null && !Exists(this.track_name))
                {
                    //this.track_artist_id = this.Album.artist_id;
                    using (DataClasses1DataContext context = new DataClasses1DataContext())
                    {
                        context.Tracks.InsertOnSubmit(this);
                        context.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "Error saving Track:" + ex.Message;
                Console.WriteLine(msg);
                //throw new Exception("Error saving Track:" + ex.Message);

            }
        }

        private bool Exists(string track_name)
        {
            try
            {
                int count = 0;
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    string aquery = "SELECT * FROM Tracks WHERE track_name = '" + this.track_name + "'";
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
                string msg = "Error verifying that track: " + track_name + ": " + ex.Message;
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public void SaveGenres(ref List<string> genres)
        {
            try
            {
                using (DataClasses1DataContext context = new DataClasses1DataContext())
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
                this.track_length_minutes = t.DurationMs / 60000;
                this.track_spotify_uri = t.Uri;
                UpdateAlbum(t.Album);
                var tArtist = t.Artists[0];
                UpdateArtist(tArtist);
            }
            catch (Exception ex)
            {
                string msg = "Error Updating track: " + ex.Message;
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        private void UpdateArtist(SimpleArtist simpleArtist)
        {
            try
            {
                Artist a = new Artist();
                a.Update(simpleArtist);
                a.Save();
                this.track_artist_id = a.artist_id;
            }
            catch (Exception ex)
            {
                string msg = "Error updating track artist: " + this.track_name + ", " + this.Artist.a_name + ": " + ex.Message;
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        private void UpdateAlbum(SimpleAlbum album)
        {
            try
            {
                if (Album.Exists(album.Name))
                {
                    Artist a = Artist.Load(album.name));
                    this.album_id = a.
                }
                Album al = new Album();
                al.Update(album);
                al.Save();
                this.album_id = al.album_id;
            }
            catch (Exception ex)
            {
                string msg = "Error updating track artist: " + this.track_name + ": " + ex.Message;
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }
    }
}
