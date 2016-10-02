using System;
using System.Data;
using SpotifyAPI.Web.Models;
using System.Threading.Tasks;
using SongsAbout_DesktopApp.Classes;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                    catch (Exception)
                    {
                        throw;
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

        public async void UpdataArtistInfo(FullArtist artist)
        {
            this.a_name = artist.Name;
            this.a_spotify_uri = artist.Uri;
            this.a_website = artist.Href;
            if (artist.Images.Count > 0)
            {
                this.a_profile_pic = await UserSpotify.ConvertSpotifyImageToBytes(artist.Images[0]);
            }
            this.a_website = artist.Href;
        }


        public void Load()
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
    }
}
