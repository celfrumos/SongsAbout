using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout_DesktopApp.Forms;
using SongsAbout_DesktopApp.Classes;

using SongsAbout_DesktopApp.Properties;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;

namespace SongsAbout_DesktopApp
{
    public partial class MainForm : Form
    {
        //private SpotifyWebAPI _spotify;
        //private PrivateProfile _profile;
        //private List<FullTrack> _savedTracks;
        //private List<SimplePlaylist> _playlists;
        //private Image _profilePic;

        public MainForm()
        {
            InitializeComponent();
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

        private void btnSavedLists_Click(object sender, EventArgs e)
        {
            MyArtistsForm myLists = new MyArtistsForm();
            myLists.ShowDialog();
        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            try
            {
                AddTrackForm addTrack = new AddTrackForm();
                addTrack.ShowDialog();

                if (addTrack.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Successfully saved " + addTrack.NewTrack.track_name, "Success!");
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

        private void btnViewData_Click(object sender, EventArgs e)
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

        private async void btnSpotify_Click(object sender, EventArgs e)
        {
            try
            {
                if (User.Default.PrivateProfile == null)
                {
                    await Task.Run(() => UserSpotify.Authenticate());
                }
                else
                {
                    MessageBox.Show("Profile Already Defined.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting desired Info");
            }
        }

        private void btnImportArtists_Click(object sender, EventArgs e)
        {
            try
            {
                Importer.ImportSavedPlaylists();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Importing Artists from Spotify: " + ex.Message);
            }
        }

        private void btnImportSavedTracks_Click(object sender, EventArgs e)
        {
            try
            {
                Importer.ImportSavedTracks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Importing Artists from Spotify: " + ex.Message);
            }
        }
    }

}