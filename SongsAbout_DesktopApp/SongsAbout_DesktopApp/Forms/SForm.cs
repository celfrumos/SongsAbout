using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout.Forms;
using SongsAbout.Classes;

using SongsAbout.Properties;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;

namespace SongsAbout.Forms
{
    public partial class SForm : Form
    {
        protected SForm()
        {
            InitializeComponent();
            SetProfilePic();
        }

        protected static void msiSpotifySearch_Click(object sender, EventArgs e)
        {
            SpotifySearchForm spotifySearch = new SpotifySearchForm();
            spotifySearch.ShowDialog();
        }
        protected async void SetProfilePic()
        {
            try
            {
                if (User.Default.ProfilePic != null)
                {
                    pBoxProfilePic.Image = await Task.Run(() => User.Default.ProfilePic.Get());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Setting Profile Picture: {ex.Message}");
            }

        }

        protected static void msiAddTrack_Click(object sender, EventArgs e)
        {
            try
            {
                var addAlbum = new AddAlbumForm();
                try
                {
                    addAlbum.ShowDialog();
                }
                catch (System.ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Something went wrong.");
                }
                if (addAlbum.DialogResult == DialogResult.OK)
                    MessageBox.Show("Successfully saved ", "Success!");

                else
                    MessageBox.Show("Something stopped the track from saving.");

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.Message + ex.InnerException.Message, "Something went wrong.");

                else
                    MessageBox.Show(ex.Message, "Something went wrong.");
            }
        }

        protected static void msiViewData_Click(object sender, EventArgs e)
        {
            QueryForm queryForm = new QueryForm();
            try
            {
                queryForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong.");
            }
        }

        protected static void msiImportAll_Click(object sender, EventArgs e)
        {
            try
            {
                Importer.ImportAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Importing Artists from Spotify: " + ex.Message);
            }
        }

        protected static void msiImportFollowedArtists_Click(object sender, EventArgs e)
        {
            try
            {
                Importer.ImportFollowedArtists();

                Console.WriteLine("Finished importing saved tracks");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Importing Artists from Spotify: {ex.Message}");
            }
        }
        protected static void msiImportSavedTracks_Click(object sender, EventArgs e)
        {
            try
            {
                Importer.ImportSavedTracks();
                Console.WriteLine("Finished importing saved tracks");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Importing Saved Tracks from Spotify: {ex.StackTrace}");
            }
        }

        protected async static void msiConnectSpotify_Click(object sender, EventArgs e)
        {
            await Task.Run(() => UserSpotify.Authenticate());
        }


        protected static void msiDisconnect_Click(object sender, EventArgs e)
        {

        }

        protected static void tsmiFollowedPlaylists_Click(object sender, EventArgs e)
        {
            try
            {
                Importer.ImportSavedPlaylists();
                Console.WriteLine("Finished Importing Saved playlists");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Importing Saved playlists from Spotify: {ex.StackTrace}");
            }
        }
    }

}