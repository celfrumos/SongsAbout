using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using SongsAbout_DesktopApp.Properties;

using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using System.Net.Sockets;
using SpotifyAPI.Local.Models;

using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;

namespace SongsAbout_DesktopApp.Classes
{
    public class UserSpotify
    {
        public static SpotifyWebAPI WebAPI
        {
            get { return User.Default.SpotifyWebAPI; }
            set { User.Default.SpotifyWebAPI = value; }
        }
        private const int PORT = 8000;
        private const string REDIRECT_URI = "http://localhost";

        public Image ProfilePic { get; set; }
        /// <summary>
        /// Initial Setup of USer Spotify Settings
        /// </summary>
        public async static void Authenticate()
        {
            SpotifyWebAPI _spotify = new SpotifyWebAPI();
            WebAPIFactory webApiFactory = new WebAPIFactory(
                REDIRECT_URI,
                PORT,
               Resources.SpotifyClientID,
                Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead |
                Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead | Scope.PlaylistModifyPrivate | Scope.PlaylistModifyPublic);

            try
            {
                if (User.Default.SpotifyWebAPI == null)
                {
                    User.Default.SpotifyWebAPI = await webApiFactory.GetWebApi();
                    User.Default.Save();
                }

                FetchProfile();
                FetchFollowedArtists();
                FetchProfilePic();
                User.Default.Save();
            }
            catch (Exception ex)
            {
                var e = new SpotifyAuthError(ex.Message);
                
                throw new SpotifyAuthError(ex.Message);
            }


        }

        private static ImplicitGrantAuth implicitAuth = new ImplicitGrantAuth();
        public async static void ImplicitConnectSpotify()
        {
            try
            {

                implicitAuth.StartHttpServer(PORT);
                implicitAuth.ClientId = Resources.SpotifyClientID;
                //UserSpotify.Authenticate
                implicitAuth.Scope = Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead |
                Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead | Scope.PlaylistModifyPrivate | Scope.PlaylistModifyPublic;
                implicitAuth.ShowDialog = true;
                implicitAuth.RedirectUri = REDIRECT_URI;
                implicitAuth.OnResponseReceivedEvent += ImplicitAuth_OnResponseReceivedEvent;
                var sre = implicitAuth.State;
                await Task.Run(() => implicitAuth.DoAuth());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Implicitly Authorizing Spotify: {ex.Message}");
                throw;
            }
        }

        private static void ImplicitAuth_OnResponseReceivedEvent(Token token, string state)
        {
            try
            {
                SpotifyWebAPI api = new SpotifyWebAPI();
                if (api.UseAuth)
                {
                    if (!token.IsExpired())
                    {
                        api.AccessToken = token.AccessToken;
                        User.Default.SpotifyWebAPI = api;
                    }
                }
                implicitAuth.StopHttpServer();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Implicitly setting spotify API: {ex.Message}");
            }
        }
        /// <summary>
        /// Gets profile info via WebAPI. Assigns user settings PrivateProfile, UserId, and PublicProfile
        /// </summary>
        public static void FetchProfile()
        {
            try
            {
                if (User.Default["PrivateProfile"] == null)
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
                throw new ProfileAssignmentError(ex.Message);
            }


        }

        /// <summary>
        /// Returns a list of User's saved tracks
        /// </summary>
        /// <returns></returns>
        public static List<FullTrack> GetSavedTracks()
        {
            Paging<SavedTrack> savedTracks = new Paging<SavedTrack>();
            List<FullTrack> list = new List<FullTrack>();
            try
            {
                savedTracks = User.Default.SpotifyWebAPI.GetSavedTracks();

                list = savedTracks.Items.Select(track => track.Track).ToList();

                while (savedTracks.Next != null)
                {
                    savedTracks = User.Default.SpotifyWebAPI.GetSavedTracks(20, savedTracks.Offset + savedTracks.Limit);
                    list.AddRange(savedTracks.Items.Select(track => track.Track));
                }

                return list;
            }
            catch (Exception ex)
            {
                SpotifyException exception = new SpotifyException(ex.Message);
                if (savedTracks.HasError())
                {
                    exception.Errors.Add(savedTracks.Error);
                }
                throw exception;
            }
        }

        public async static Task<Image> ImportImageFromSpotify(SpotifyAPI.Web.Models.Image SpotifyPic)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    Image returnImage;
                    byte[] imageBytes = await wc.DownloadDataTaskAsync(new Uri(SpotifyPic.Url));
                    using (MemoryStream stream = new MemoryStream(imageBytes))
                    {
                        returnImage = Image.FromStream(stream);
                        return returnImage;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Importing image from Spotify: {ex.Message}");
            }

        }

        /// <summary>
        /// Async method to get Profile image as a System.Drawing.Image
        /// </summary>
        /// <returns></returns>
        public async static Task<Image> GetProfilePic()
        {
            if (User.Default.PrivateProfile != null)
            {
                try
                {
                    if (User.Default.ProfilePic == null)
                    {
                        FetchProfilePic();
                    }

                    using (WebClient wc = new WebClient())
                    {
                        Image _profilePic;
                        byte[] imageBytes = await wc.DownloadDataTaskAsync(new Uri(User.Default.ProfilePic.Url));
                        using (MemoryStream stream = new MemoryStream(imageBytes))
                        {
                            _profilePic = Image.FromStream(stream);
                            //var picType = _profilePic.GetType();
                            //string extension = picType.Name;
                            //var format = System.Drawing.Imaging.ImageFormat.Bmp;

                            //_profilePic.Save(stream, format);
                            //   _profilePic.Save(profilePicFileName);
                            return _profilePic;
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception($"Error getting profile photo: {ex.Message}");
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
        public static void FetchProfilePic()
        {
            if (User.Default["PrivateProfile"] != null)
            {
                if (User.Default.PrivateProfile.Images.Count > 0)
                {
                    User.Default["ProfilePic"] = User.Default.PrivateProfile.Images[0];
                    User.Default.Save();
                }
                else
                {
                    throw new Exception("Error Fetch profile pic");
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
        public static void FetchFollowedArtists()
        {
            if (WebAPI != null)
            {
                User.Default["FollowedArtists"] = WebAPI.GetFollowedArtists(FollowType.Artist);
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

        internal static Paging<FullTrack> GetTopTracks()
        {
            if (User.Default.PrivateProfile != null)
            {
                try
                {
                    return WebAPI.GetUsersTopTracks();

                }
                catch (Exception ex)
                {
                    throw new Exception($"Error getting user's top tracks: {ex.Message}");
                }
            }
            else
            {
                string msg = "Failed to get user top tracks; Profile not yet defined.";
                Console.WriteLine(msg);
                throw new Exception(msg);
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

        public static List<SimplePlaylist> GetPlaylists()
        {
            try
            {
                if (User.Default.PrivateProfile != null)
                {

                    Paging<SimplePlaylist> playlists = User.Default.SpotifyWebAPI.GetUserPlaylists(User.Default.UserId);

                    return playlists.Items;

                }
                else
                {
                    throw new Exception("Spotify Profile hasn't been defined yet.");
                }
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
    }
}
