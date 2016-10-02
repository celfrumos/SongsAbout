using System.Data;
using SpotifyAPI.Web.Models;
using SongsAbout_DesktopApp.Classes;
using System.Windows.Forms;
using System.Collections.Generic;
using SongsAbout_DesktopApp.Properties;
using System;

namespace SongsAbout_DesktopApp
{
    public partial class Album
    {
        public void Save()
        {
            try
            {
                if (!Exists(this.al_title))
                {
                    using (DataClasses1DataContext context = new DataClasses1DataContext())
                    {
                        context.Albums.InsertOnSubmit(this);
                        context.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Saving Artist: " + ex.Message);
            }
        }

        public bool Exists(string name)
        {
            BindingSource artistsBindingSource = new BindingSource();
            DataSetTableAdapters.ArtistsTableAdapter artistsTableAdapter = new DataSetTableAdapters.ArtistsTableAdapter();
            DataSet dataSet = new DataSet();

            // TODO: This line of code loads data into the 'dataSet.Artists' table. You can move, or remove it, as needed.
            artistsTableAdapter.Fill(dataSet.Artists);

            DataTable artistTable = dataSet.Artists;
            string query = "al_title = '" + this.al_title + "'";
            DataRow[] rows = artistTable.Select(query);

            return (rows.Length == 0);
        }

        internal void Update(SimpleAlbum album)
        {
            try
            {
                FullAlbum al = User.Default.SpotifyWebAPI.GetAlbum(album.Id);
                this.Update(al);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void Update(FullAlbum album)
        {
            try
            {
                this.al_title = album.Name;
                this.al_spotify_uri = album.Uri;
                this.Artist.Update(album.Artists[0]);
                this.SetGenres(album.Genres);

                if (album.Images.Count > 0)
                {
                    this.al_cover_art = await UserSpotify.ConvertSpotifyImageToBytes(album.Images[0]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Updating Album" + ex.Message);
            }
        }

        public void SetGenres(List<string> genres)
        {
            foreach (string g in genres)
            {
                AlbumGenre ag = new AlbumGenre();
                ag.album_id = this.album_id;
                ag.genre = g;
            }
        }

    }
}
