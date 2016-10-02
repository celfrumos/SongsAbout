using System;
using System.Data;
using SpotifyAPI.Web.Models;
using SongsAbout_DesktopApp.Classes;
using System.Windows.Forms;
using SongsAbout_DesktopApp.Properties;
namespace SongsAbout_DesktopApp
{

    /// <summary>
    /// Partial Class to hold Artist Functions
    /// </summary>
    public partial class Artist
    {
        /// <summary>
        /// Submit Changes to the Database
        /// </summary>
        public void Save()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                if (this.a_name != null && !Exists(this.a_name))
                {
                    try
                    {
                        context.Artists.InsertOnSubmit(this);
                        context.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error Saving Artist" + ex.Message);
                    }
                }
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
            string query = "a_name = '" + this.a_name + "'";
            DataRow[] rows = artistTable.Select(query);

            return (rows.Length == 0);
        }

        internal void Update(SimpleArtist simpleArtist)
        {
            try
            {
                FullArtist ar = User.Default.SpotifyWebAPI.GetArtist(simpleArtist.Id);
                this.Update(ar);
            }
            catch (Exception)
            {
                throw new Exception("Error updating artist: " + simpleArtist.Name);
            }
        }

        public async void Update(FullArtist artist)
        {
            try
            {
                this.a_name = artist.Name;
                this.a_spotify_uri = artist.Uri;
                this.a_website = artist.Href;
                if (artist.Images.Count > 0)
                {
                    byte[] pic = await UserSpotify.ConvertSpotifyImageToBytes(artist.Images[0]);
                    this.a_profile_pic = pic;//await UserSpotify.ConvertSpotifyImageToBytes(artist.Images[0]);
                }
                this.a_website = artist.Href;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Updating artist: " + ex.Message);
            }
        }


        public void Load()
        {
            try
            {
                BindingSource artistsBindingSource = new BindingSource();
                DataSetTableAdapters.ArtistsTableAdapter artistsTableAdapter = new DataSetTableAdapters.ArtistsTableAdapter();
                DataSet dataSet = new DataSet();

                // TODO: This line of code loads data into the 'dataSet.Artists' table. You can move, or remove it, as needed.
                artistsTableAdapter.Fill(dataSet.Artists);

                DataTable artistTable = dataSet.Artists;
                string query = "a_name = '" + this.a_name + "'";
                DataRow[] rows = artistTable.Select(query);

                if (rows.Length > 0)
                {
                    this.a_name = rows[0]["a_name"].ToString();
                    this.a_spotify_uri = rows[0]["a_spotify_uri"].ToString();
                    this.a_website = rows[0]["a_website"].ToString();
                    this._a_profile_pic = (byte[])rows[0]["_a_profile_pic"];
                    this.a_bio = rows[0]["a_bio"].ToString();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Loading Artist: " + ex.Message);
            }
        }
    }
}
