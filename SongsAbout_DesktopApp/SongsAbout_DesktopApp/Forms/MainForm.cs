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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetProfilePic();

        }

        private async void SetProfilePic()
        {
            try
            {
                if (User.Default.ProfilePic != null)
                {
                    pBoxProfilePic.Image = await UserSpotify.ImportImageFromSpotify(User.Default.ProfilePic);
                    //pBoxProfilePic.Image = await UserSpotify.ImportImageFromSpotify(User.Default.ProfilePic);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Setting Profile Picture: {ex.Message}");
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string uri = "spotify:track:6C7RJEIUDqKkJRZVWdkfkH";
            //MakeRequest(uri).Wait();
            //GetResults();


        }

        private void GetResults()
        {
            string query = txtBoxQuery.Text;
            List<string> genres = new List<string>();
            for (int i = 0; i < lstBxGenres.SelectedItems.Count; i++)
            {
                genres.Add(lstBxGenres.SelectedItems[i].ToString());
            }
        }

        private void msiSpotifySearch_Click(object sender, EventArgs e)
        {
            SpotifySearchForm spotifySearch = new SpotifySearchForm();
            spotifySearch.ShowDialog();
        }

        private void msiAddTrack_Click(object sender, EventArgs e)
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
                {
                    MessageBox.Show("Successfully saved ", "Success!");
                }
                else {
                    MessageBox.Show("Something Happened");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show(ex.Message + ex.InnerException.Message, "Something went wrong.");
                }
                else
                {
                    MessageBox.Show(ex.Message, "Something went wrong.");

                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // ArtistDictionary = artists.Load();
        }

        private void msiViewData_Click(object sender, EventArgs e)
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


        private void msiImportAll_Click(object sender, EventArgs e)
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

        private void msiImportFollowedArtists_Click(object sender, EventArgs e)
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
        private void msiImportSavedTracks_Click(object sender, EventArgs e)
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

        private void msiConncectSpotify_Click(object sender, EventArgs e)
        {
            Task task = new Task(() => UserSpotify.Authenticate());

            task.Wait();
            if (task.IsCompleted)
            {
                SetProfilePic();

            }

        }

        private void msiDisconnect_Click(object sender, EventArgs e)
        {

        }

        private void tsmiFollowedPlaylists_Click(object sender, EventArgs e)
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