using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Models;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp
{
    public partial class Track
    {
        public void Save()
        {
            if (!Exists(this.track_name))
            {
                //this.track_artist_id = this.Album.artist_id;
                using (DataClasses1DataContext context = new DataClasses1DataContext())
                {
                    context.Tracks.InsertOnSubmit(this);
                    context.SubmitChanges();
                }
            }
        }

        private bool Exists(string track_name)
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
                throw new Exception("Error Saving track genres: " + ex.Message);
            }
        }

        internal void Update(FullTrack t)
        {
            try
            {
                this.Album.Update(t.Album);
                this.Artist.Update(t.Artists[0]);
                this.track_name = t.Name;
                this.track_length_minutes = t.DurationMs;
                this.track_spotify_uri = t.Uri;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Updating track: " + ex.Message);
            }
        }
    }
}
