using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region SpotifyAPIThings
using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using SpotifyAPI.Local.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
#endregion
using SongsAbout_DesktopApp.Properties;

namespace SongsAbout_DesktopApp.Forms
{
    public partial class SelectionForm : Form
    {
        SpotifyWebAPI _spotify = new SpotifyWebAPI();
        PrivateProfile privateProfile;
        string userId;
        public SelectionForm()
        {
            InitializeComponent();
        }

        private async void TestAPI()
        {
            WebAPIFactory webApiFactory = new WebAPIFactory(

                    "http://localhost",     // RedirectUri Domain
                    3646,                   // Listening port ///3646
                    Properties.Resources.SpotifyClientID,   // Client ID
                    Scope.UserLibraryRead//,          // Scope (permisisons)
                                         //TimeSpan.FromSeconds(20)        // Wait time
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                GetInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting desired Info");
            }
        }

        private void GetInfo()
        {
            TestAPI(Scope.UserFollowRead);
            // userId = GetUserId();
            FollowedArtists k = _spotify.GetFollowedArtists(FollowType.Artist);
            foreach (var item in k.Artists.Items)
            {
                string id = item.Id;
                string uri = item.Uri;
                string name = item.Name;
                var images = item.Images;                                
                string href = item.Href;
                List<string> genres = item.Genres;
            }
            /*
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
                */
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
            privateProfile = _spotify.GetPrivateProfile();
            //  label2.Text = privateProfile.DisplayName;
            if (Resources.UserId == null)
            {
                userId = privateProfile.Id;
            }
            else
            {
                userId = Resources.UserId;
            }
            return userId;
        }
    }
}
