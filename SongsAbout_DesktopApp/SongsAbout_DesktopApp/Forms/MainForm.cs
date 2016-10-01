using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;
using SongsAbout_DesktopApp.Forms;
using System.IO;

using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;


namespace SongsAbout_DesktopApp
{
    public partial class MainForm : Form
    {
        private SpotifyWebAPI _spotify;
        private PrivateProfile _profile;
        private List<FullTrack> _savedTracks;
        private List<SimplePlaylist> _playlists;
        private Image _profilePic;

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

        private void btnSpotify_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => RunAuthentication());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting desired Info");
            }
        }

        private static List<SimplePlaylist> GetPlaylists()
        {
            try
            {
                Paging<SimplePlaylist> playlists = _spotify.GetUserPlaylists(_profile.Id);
                List<SimplePlaylist> list = playlists.Items.ToList();

                while (playlists.Next != null)
                {
                    playlists = _spotify.GetUserPlaylists(_profile.Id, 20, playlists.Offset + playlists.Limit);
                    list.AddRange(playlists.Items);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => RunAuthentication());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting desired Info");
            }
        }

    }

}