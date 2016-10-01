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
        /// <summary>
        /// Initial Setup of USer Spotify Settings
        /// </summary>
        public async static void RunAuthentication()
        {
            SpotifyWebAPI _spotify = new SpotifyWebAPI();
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

                    User.Default.SpotifyWebAPI = await webApiFactory.GetWebApi();
                    User.Default.Save();
                }

                AssignProfile();
                AssignFollowedArtists();
                AssignProfile();
                AssignProfilePic();
                User.Default.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error running authentication: " + ex.Message);
            }

            if (_spotify == null)
                return;

        }

        /// <summary>
        /// Gets profile info via WebAPI. Assigns user settings PrivateProfile, UserId, and PublicProfile
        /// </summary>
        private static void AssignProfile()
        {
            try
            {
                if (User.Default.PrivateProfile == null)
                {
                    User.Default.PrivateProfile = User.Default.SpotifyWebAPI.GetPrivateProfile();
                    //User.Default.PrivateProfile = _profile;
                    User.Default.UserId = User.Default.PrivateProfile.Id;
                    User.Default.PublicProfile = User.Default.SpotifyWebAPI.GetPublicProfile(User.Default.UserId);
                    User.Default.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Assigning Profile" + ex.Message);
            }

            //    if (InvokeRequired)
            //    {
            //        Invoke(new Action(InitialSetup));
            //        return;
            //    }

            //  authButton.Enabled = false;
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

        /// <summary>
        /// Returns a list of User's saved tracks
        /// </summary>
        /// <returns></returns>
        private static List<FullTrack> GetSavedTracks()
        {
            try
            {
                Paging<SavedTrack> savedTracks = User.Default.SpotifyWebAPI.GetSavedTracks();
                List<FullTrack> list = savedTracks.Items.Select(track => track.Track).ToList();

                while (savedTracks.Next != null)
                {
                    savedTracks = User.Default.SpotifyWebAPI.GetSavedTracks(20, savedTracks.Offset + savedTracks.Limit);
                    list.AddRange(savedTracks.Items.Select(track => track.Track));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Async method to get Profile image as a System.Drawing.Image
        /// </summary>
        /// <returns></returns>
        private async static Task<Image> GetProfilePic()
        {
            if (User.Default.PrivateProfile != null)
            {
                try
                {
                    if (User.Default.ProfilePic == null)
                    {
                        AssignProfilePic();
                    }

                    using (WebClient wc = new WebClient())
                    {
                        Image _profilePic;
                        byte[] imageBytes = await wc.DownloadDataTaskAsync(new Uri(User.Default.ProfilePic.Url));
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
                catch (Exception ex)
                {
                    throw new Exception("Error getting profile photo " + ex.Message);
                }
            }
            else
            {
                throw new Exception("User WebAPI undefined");
            }
        }

        /// <summary>
        /// Assign User Setting ProfilePic
        /// </summary>
        private static void AssignProfilePic()
        {
            if (User.Default.PrivateProfile != null)
            {
                if (User.Default.PrivateProfile.Images.Count > 0)
                {
                    User.Default.ProfilePic = User.Default.PrivateProfile.Images[0];
                    User.Default.Save();
                }
                else
                {
                    throw new Exception("Error Assigning profile pic");
                }
            }
            else
            {
                throw new Exception("User WebAPI undefined");
            }
        }

        /// <summary>
        /// Assign User Setting for FollowedArtists
        /// </summary>
        private static void AssignFollowedArtists()
        {
            if (User.Default.SpotifyWebAPI != null)
            {
                User.Default.FollowedArtists = User.Default.SpotifyWebAPI.GetFollowedArtists(FollowType.Artist);
                User.Default.Save();
                //foreach (var a in artists.Artists.Items)
                //{
                //    string id = a.Id;
                //    string uri = a.Uri;
                //    string name = a.Name;
                //    var images = a.Images;
                //    string href = a.Href;
                //    List<string> genres = a.Genres;
                //}                
            }
            else
            {
                throw new Exception("User WebAPI undefined");
            }
        }

        private static void PutPlaylists()
        {

            if (User.Default.PrivateProfile != null)
            {
                Paging<SimplePlaylist> myPlaylists = User.Default.SpotifyWebAPI.GetUserPlaylists(User.Default.UserId, 5, 0);
                foreach (SimplePlaylist item in myPlaylists.Items)
                {
                    string playlistTrack = "";
                    string uri = item.Uri;
                    string playlistId = item.Id;

                    Paging<PlaylistTrack> tracks = User.Default.SpotifyWebAPI.GetPlaylistTracks(User.Default.UserId, playlistId);
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
                            //  MessageBox.Show(playlistTrack);
                        }
                    }
                    else
                    {
                        throw new Exception(tracks.Error.Message);
                    }
                }

            }

        }

    }
}
