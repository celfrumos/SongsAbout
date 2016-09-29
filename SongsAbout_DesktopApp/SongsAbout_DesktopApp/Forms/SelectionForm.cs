using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using SpotifyAPI.Local.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;



namespace SongsAbout_DesktopApp.Forms
{
    public partial class SelectionForm : Form
    {
        SpotifyWebAPI _spotify = new SpotifyWebAPI();
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
                    Scope.UserReadPrivate,          // Scope (permisisons)
                    TimeSpan.FromSeconds(20)        // Wait time
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
                MessageBox.Show(ex.Message);
            }


        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestAPI();
            try
            {
                PrivateProfile privateProfile = _spotify.GetPrivateProfile();
                label2.Text = privateProfile.DisplayName;
                string userId = privateProfile.Id;
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
            //      _spotify.GetUserPlaylists();            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
