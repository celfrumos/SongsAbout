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

using SongsAbout_DesktopApp.Properties;

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

        #region SpotifyCalls
        private async void TestAPI(Scope selectedScope)
        {
            WebAPIFactory webApiFactory = new WebAPIFactory(
                    "http://localhost",     // RedirectUri Domain
                    3646,                   // Listening port ///3646
                    Properties.Resources.SpotifyClientID,   // Client ID
                    selectedScope  //, Scope (permisisons)
            );

            try
            {
                //This will open the user's browser and returns once
                //the user is authorized.
                _spotify = await webApiFactory.GetWebApi();

                // MessageBox.Show("Access Token: " + _spotify.AccessToken, "Success");
            }
            catch (Exception ex)
            {
                throw new Exception("Error Getting Spotify API: " + ex.Message);
            }
        }

        private async void InitialSetup()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(InitialSetup));
                return;
            }

            //  authButton.Enabled = false;
            try
            {
                if (User.Default.PrivateProfile == null)
                {
                    _profile = _spotify.GetPrivateProfile();
                    User.Default.PrivateProfile = _profile;
                    User.Default.Save();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting profile");
            }

            try
            {
                _savedTracks = GetSavedTracks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting saved tracks");
            }
            //_savedTracks.ForEach(track => savedTracksListView.Items.Add(new ListViewItem()
            //{
            //    Text = track.Name,
            //    SubItems = { string.Join(",", track.Artists.Select(source => source.Name)), track.Album.Name }
            //}));
            try
            {
                _playlists = GetPlaylists();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting playlists");
            }

            // _playlists.ForEach(playlist => playlistsListBox.Items.Add(playlist.Name));

            //displayNameLabel.Text = _profile.DisplayName;
            //countryLabel.Text = _profile.Country;
            //emailLabel.Text = _profile.Email;
            //accountLabel.Text = _profile.Product;
            try
            {
                if (_profile.Images != null && _profile.Images.Count > 0)
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] imageBytes = await wc.DownloadDataTaskAsync(new Uri(_profile.Images[0].Url));
                        using (MemoryStream stream = new MemoryStream(imageBytes))
                        {
                            _profilePic = Image.FromStream(stream);
                            string profilePicFileName = "Pictures\\ProfilePic." + _profilePic.GetType();
                         //   _profilePic.Save(profilePicFileName);
                            pBoxProfilePic.Image = _profilePic;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting profile photo");
            }
        }

        private List<FullTrack> GetSavedTracks()
        {
            try
            {
                Paging<SavedTrack> savedTracks = _spotify.GetSavedTracks();
                List<FullTrack> list = savedTracks.Items.Select(track => track.Track).ToList();

                while (savedTracks.Next != null)
                {
                    savedTracks = _spotify.GetSavedTracks(20, savedTracks.Offset + savedTracks.Limit);
                    list.AddRange(savedTracks.Items.Select(track => track.Track));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void GetFollowedArtists()
        {
            TestAPI(Scope.UserFollowRead);
            // userId = GetUserId();
            FollowedArtists artists = _spotify.GetFollowedArtists(FollowType.Artist);
            foreach (var item in artists.Artists.Items)
            {
                string id = item.Id;
                string uri = item.Uri;
                string name = item.Name;
                var images = item.Images;
                string href = item.Href;
                List<string> genres = item.Genres;
            }

        }

        private void PutPlaylists()
        {

            Paging<SimplePlaylist> myPlaylists = _spotify.GetUserPlaylists(User.Default.UserId, 5, 0);
            foreach (SimplePlaylist item in myPlaylists.Items)
            {
                string playlistTrack = "";
                string uri = item.Uri;
                string playlistId = item.Id;

                Paging<PlaylistTrack> tracks = _spotify.GetPlaylistTracks(User.Default.UserId, playlistId);
                if (tracks.Error.Message == null)
                {
                    foreach (PlaylistTrack t in tracks.Items)
                    {
                        string name = t.Track.Name;
                        string alName = t.Track.Album.Name;
                        var artists = t.Track.Artists;
                        SimpleArtist firstArtist = artists[0];
                        string aName = firstArtist.Name;
                        playlistTrack += name + " " + alName + " " + aName;
                        MessageBox.Show(playlistTrack);
                    }
                }
                else
                {
                    throw new Exception(tracks.Error.Message);
                }
            }

        }

        private async void RunAuthentication()
        {
            WebAPIFactory webApiFactory = new WebAPIFactory(
                "http://localhost",
                8000,
               Properties.Resources.SpotifyClientID,
                Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead |
                Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead | Scope.PlaylistModifyPrivate | Scope.PlaylistModifyPublic);

            try
            {
                if (User.Default.SpotifyWebAPI == null)
                {
                    _spotify = await webApiFactory.GetWebApi();
                    User.Default.SpotifyWebAPI = _spotify;
                    User.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (_spotify == null)
                return;

            InitialSetup();
        }

        private List<SimplePlaylist> GetPlaylists()
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
        #endregion
    }

}