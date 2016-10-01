using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;


using SongsAbout_DesktopApp.Properties;

namespace SongsAbout_DesktopApp.Forms
{
    public partial class SelectionForm : Form
    {
        private SpotifyWebAPI _spotify;
        private PrivateProfile _profile;
        private List<FullTrack> _savedTracks;
        private List<SimplePlaylist> _playlists;
        private string _userId;
        private Image _profilePic;

        public Image ProfilePic { get { return _profilePic; } }
        public SpotifyWebAPI Spotify { get { return _spotify; } }

        public PrivateProfile Profile { get { return _profile; } }
        public List<FullTrack> SavedTracks { get { return _savedTracks; } }
        public List<SimplePlaylist> Playlists { get { return _playlists; } }
        public string userId { get { return _userId; } }

        public SelectionForm()
        {
            InitializeComponent();
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

            Paging<SimplePlaylist> myPlaylists = _spotify.GetUserPlaylists(userId, 5, 0);
            foreach (SimplePlaylist item in myPlaylists.Items)
            {
                string playlistTrack = "";
                string uri = item.Uri;
                string playlistId = item.Id;

                Paging<PlaylistTrack> tracks = _spotify.GetPlaylistTracks(userId, playlistId);
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

        private string GetUserId()
        {
            _profile = _spotify.GetPrivateProfile();
            //  label2.Text = privateProfile.DisplayName;
            if (Resources.UserId == null)
            {
                _userId = _profile.Id;
            }
            else
            {
                _userId = Resources.UserId;
            }
            return userId;
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
                _spotify = await webApiFactory.GetWebApi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (_spotify == null)
                return;

            InitialSetup();
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
                _profile = _spotify.GetPrivateProfile();
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
            // savedTracksCountLabel.Text = _savedTracks.Count.ToString();
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
            // playlistsCountLabel.Text = _playlists.Count.ToString();
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
                            pictureBox1.Image = _profilePic;
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
    }

}
