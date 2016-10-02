using System;
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
//                string msg = "Error saving Track:" + ex.Message;
  //              Console.WriteLine(msg);
                throw new Exception("Error saving Track:" + ex.Message);

            }
        }

        private bool Exists(string track_name)
        {
            try
            {
                BindingSource tracksBindingSource = new BindingSource();
                DataSetTableAdapters.TracksTableAdapter tracksTableAdapter = new DataSetTableAdapters.TracksTableAdapter();
                DataSet dataSet = new DataSet();

                // TODO: This line of code loads data into the 'dataSet.Artists' table. You can move, or remove it, as needed.
                tracksTableAdapter.Fill(dataSet.Tracks);

                DataTable tracksTable = dataSet.Artists;
                string query = "track_name = '" + this.track_name + "' ";
                DataRow[] rows = tracksTable.Select(query);

                return (rows.Length == 0);
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

        internal void Update(FullTrack t)
        {
            try
            {
                this.track_name = t.Name;
                this.track_length_minutes = t.DurationMs / 60000;
                this.track_spotify_uri = t.Uri;
                UpdateAlbum(t.Album);
                UpdateArtist(t.Artists[0]);
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
                this.Artist = new Artist();
                this.Artist.Update(simpleArtist);
                this.Artist.Save();
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
                this.Album = new Album();
                this.Album.Update(album);
                this.Album.Save();
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
