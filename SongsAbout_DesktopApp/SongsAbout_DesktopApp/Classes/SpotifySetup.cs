using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using static System.Windows.Forms.Control;
using SongsAbout_DesktopApp.Forms;
using System.IO;
using System.Drawing;
using SongsAbout_DesktopApp.Properties;

using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;

namespace SongsAbout_DesktopApp.Classes
{
    public static class SpotifySetup
    {
        private async static void TestAPI(Scope selectedScope)
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
                User.Default.SpotifyWebAPI = await webApiFactory.GetWebApi();

                // MessageBox.Show("Access Token: " + _spotify.AccessToken, "Success");
            }
            catch (Exception ex)
            {
                throw new Exception("Error Getting Spotify API: " + ex.Message);
            }
        }

        private async static void InitialSetup()
        {
            //    if (InvokeRequired)
            //    {
            //        Invoke(new Action(InitialSetup));
            //        return;
            //    }

            //  authButton.Enabled = false;
            try
            {
                if (User.Default.PrivateProfile == null)
                {
                    User.Default.PrivateProfile = User.Default.SpotifyWebAPI.GetPrivateProfile();
                    //User.Default.PrivateProfile = _profile;
                    User.Default.Save();
                }
            }

            catch (Exception)
            {
                throw;
            }

            //_savedTracks.ForEach(track => savedTracksListView.Items.Add(new ListViewItem()
            //{
            //    Text = track.Name,
            //    SubItems = { string.Join(",", track.Artists.Select(source => source.Name)), track.Album.Name }
            //}));

            // _playlists.ForEach(playlist => playlistsListBox.Items.Add(playlist.Name));

            //displayNameLabel.Text = _profile.DisplayName;
            //countryLabel.Text = _profile.Country;
            //emailLabel.Text = _profile.Email;
            //accountLabel.Text = _profile.Product;

        }

        private static List<FullTrack> GetSavedTracks()
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

        private async static Task<Image> GetProfilePic()
        {
            Image _profilePic;
            try
            {
                if (User.Default.PrivateProfile.Images != null && User.Default.PrivateProfile.Images.Count > 0)
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] imageBytes = await wc.DownloadDataTaskAsync(new Uri(User.Default.PrivateProfile.Images[0].Url));
                        using (MemoryStream stream = new MemoryStream(imageBytes))
                        {
                            _profilePic = Image.FromStream(stream);
                            var picType = _profilePic.GetType();
                            string extension = picType.Name;
                            var format = System.Drawing.Imaging.ImageFormat.Bmp;
                            _profilePic.Save(stream, format);
                            //   _profilePic.Save(profilePicFileName);
                            return _profilePic;
                        }
                    }
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting profile photo " + ex.Message);//  MessageBox.Show(ex.Message, "Error getting profile photo");
            }
        }

        private static void GetFollowedArtists()
        {
            TestAPI(Scope.UserFollowRead);
            // userId = GetUserId();
            FollowedArtists artists = User.Default.SpotifyWebAPI.GetFollowedArtists(FollowType.Artist);
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

        private static void PutPlaylists()
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

        private async static void RunAuthentication()
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

    }
}
