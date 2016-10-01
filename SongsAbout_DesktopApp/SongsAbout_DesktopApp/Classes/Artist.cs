using System;
using System.Data;
using SpotifyAPI.Web.Models;
using System.Threading.Tasks;
using SongsAbout_DesktopApp.Classes;

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
            DataSet dataSet = new DataSet();
            DataTable artistTable = dataSet.Tables["Artists"];
            string query = "a_name = '" + this.a_name + "'";
            DataRow[] rows;
            rows = artistTable.Select(query);

            if (rows.Length == 0)
            {
                using (DataClasses1DataContext context = new DataClasses1DataContext())
                {
                    context.Artists.InsertOnSubmit(this);
                    context.SubmitChanges();
                }

            }
            else
            {
                throw new Exception("An artist with this name already exists. ");
            }
        }

        internal void Save(FullArtist artist)
        {
            this.a_name = artist.Name;
            this.a_spotify_uri = artist.Uri;
            var k = artist.Images[0];
            // fullar
        }
        public async void UpdataArtistInfo(FullArtist artist)
        {
            this.a_name = artist.Name;
            this.a_spotify_uri = artist.Uri;
            this.a_profile_pic = await UserSpotify.ConvertSpotifyImageToBytes(artist.Images[0]);
            this.a_website = artist.Href;
        }
    }
}
