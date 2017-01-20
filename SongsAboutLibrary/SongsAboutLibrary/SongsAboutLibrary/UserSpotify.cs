using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using SongsAbout.Properties;

using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using System.Net.Sockets;
using SpotifyAPI.Local.Models;

using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SongsAbout.Entities;
using Image = System.Drawing.Image;

namespace SongsAbout
{
    /// <summary>
    /// Class to hold Methods used for dealing with SpotifyAPI, specific to the user
    /// </summary>
    public class UserSpotify
    {
        /// <summary>
        /// 
        /// </summary>
        public static SpotifyWebAPI WebAPI
        {
            get { return User.Default.SpotifyWebAPI; }
            set { User.Default.SpotifyWebAPI = value; }
        }

        /// <summary>
        /// User's private Spotify Id
        /// </summary>
        internal static string PrivateId
        {
            get { return User.Default.PrivateId; }
            set { User.Default.PrivateId = value; }
        }

        private const int PORT = 8000;
        private const string REDIRECT_URI = "http://localhost";
        
        /// <summary>
        /// User's Spotify Profile Picture
        /// </summary>
        public Image ProfilePic { get; set; }

        /// <summary>
        /// Initial Setup of USer Spotify Settings
        /// </summary>
        public async static void Authenticate()
        {
            try
            {
                string clientId = Settings.Default.ClientId;
                SpotifyWebAPI _spotify = new SpotifyWebAPI();
                WebAPIFactory webApiFactory = new WebAPIFactory(
                    REDIRECT_URI,
                    PORT,
                   clientId,
                    Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead |
                    Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead | Scope.PlaylistModifyPrivate | Scope.PlaylistModifyPublic);

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
            catch (SpotifyException)
            {
                throw;
            }
            catch (System.Resources.MissingManifestResourceException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                var e = new SpotifyAuthError(ex.Message);
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }

        private static ImplicitGrantAuth implicitAuth = new ImplicitGrantAuth();

        /// <summary>
        /// Implicitly connect spotify. Not yet effective
        /// </summary>        
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
                throw new SpotifyAuthError(ex.Message);
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
                        WebAPI = api;
                    }
                }
                implicitAuth.StopHttpServer();
            }
            catch (Exception ex)
            {
                throw new SpotifyAuthError(ex.Message);
            }
        }
        /// <summary>
        /// Gets profile info via WebAPI. Assigns user settings PrivateProfile, PrivateId, and PublicProfile
        /// </summary>
        public static void FetchProfile()
        {
            try
            {
                if (User.Default["PrivateProfile"] == null)
                {
                    User.Default.PrivateProfile = WebAPI.GetPrivateProfile();
                    //User.Default.PrivateProfile = _profile;
                    PrivateId = User.Default.PrivateProfile.Id;
                    User.Default.PublicProfile = WebAPI.GetPublicProfile(User.Default.PrivateId);
                    User.Default.Save();
                }
            }
            catch (Exception ex)
            {
                throw new ProfileAssignmentError(ex.Message);
            }


        }

        /// <summary>
        /// Search an from Spotify
        /// </summary>
        /// <param name="query"></param>
        /// <param name="searchType"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="retryCount"></param>
        /// <returns></returns>
        public static SearchItem Search(string query, SearchType searchType, int limit = 20, int offset = 0, int retryCount = 5)
        {
            limit = limit < 1 ? 1 : limit;
            retryCount = retryCount < 1 ? 1 : retryCount;
            try
            {
                if (UserSpotify.WebAPI == null)
                {
                    Authenticate();
                    while (UserSpotify.WebAPI == null)
                    {
                        Thread.Sleep(1);
                    }
                }
                Thread.Sleep(5);
                bool succeeded = false;
                SearchItem resultsList = new SearchItem();
                int attempts = 0;
                do
                {
                    try
                    {
                        resultsList = UserSpotify.WebAPI.SearchItems(query, searchType, limit, offset);

                        succeeded = !resultsList.HasError();

                    }
                    catch (Exception)
                    {
                        succeeded = false;
                    }
                    finally
                    {
                        attempts++;
                    }

                } while (!succeeded && attempts < retryCount);

                Console.WriteLine($"Search Attempted {attempts} times. Succeeded = {succeeded}");
                return resultsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching from spotify:{ex.Message}");
                return new SearchItem() { Error = new Error() { Message = ex.Message } };
            }

        }
        /// <summary>
        /// Returns a list of User's saved tracks
        /// </summary>
        /// <returns></returns>
        public static List<SpotifyTrack> GetSavedTracks()
        {
            Paging<SavedTrack> savedTracks = new Paging<SavedTrack>();
            var list = new List<SpotifyTrack>();
            try
            {
                savedTracks = WebAPI.GetSavedTracks();

                list = savedTracks.Items.Select(track => (SpotifyTrack)track.Track).ToList();

                while (savedTracks.Next != null)
                {
                    savedTracks = User.Default.SpotifyWebAPI.GetSavedTracks(20, savedTracks.Offset + savedTracks.Limit);
                    list.AddRange(savedTracks.Items.Select(track => (SpotifyTrack)track.Track));
                }

                return list;
            }
            catch (Exception ex)
            {
                SpotifyException exception = new SpotifyException(ex.Message);

                throw exception;
            }
        }
            
        /// <summary>
        /// Assign User Setting ProfilePic
        /// </summary>
        /// <exception cref="SpotifyException"></exception>
        /// <exception cref="SpotifyUndefinedAPIError"></exception>
        /// <exception cref="SpotifyImageImportError"></exception>
        public static void FetchProfilePic()
        {
            try
            {
                if (User.Default.PrivateProfile != null)
                {
                    if (User.Default.PrivateProfile.Images.Count > 0)
                    {
                        User.Default.ProfilePic = User.Default.PrivateProfile.Images[0];
                    }
                    else
                    {
                        throw new SpotifyImageImportError("Error importing profile pic");
                    }
                }
                else
                {
                    throw new SpotifyUndefinedAPIError();
                }
            }
            catch (SpotifyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SpotifyException(ex.Message);
            }
        }

        /// <summary>
        /// Assign User Setting for FollowedArtists
        /// </summary>
        public async static void FetchFollowedArtists()
        {
            try
            {
                if (WebAPI != null)
                {
                    User.Default.FollowedArtists = await WebAPI.GetFollowedArtistsAsync(FollowType.Artist);
                }
                else
                {
                    throw new SpotifyUndefinedAPIError("Error Fetching Followed Artists");
                }
            }
            catch (SpotifyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SpotifyException(ex.Message);
            }
        }

        /// <summary>
        /// Get the User's top tracks
        /// </summary>
        /// <returns></returns>
        public static List<SpotifyTrack> GetTopTracks()
        {
            try
            {
                if (User.Default.PrivateProfile != null)
                {
                    try
                    {
                        List<SpotifyTrack> trackList = new List<SpotifyTrack>();
                        var paging = WebAPI.GetUsersTopTracks();

                        paging.Items.ForEach(track => trackList.Add(track));
                        return trackList;

                    }
                    catch (Exception ex)
                    {
                        throw new SpotifyImportError(SpotifyEntityType.Track,$"Error getting user's top tracks: {ex.Message}");
                    }
                }
                else
                {
                    throw new SpotifyUndefinedProfileError("Failed to get user top tracks");
                }
            }
            catch (SpotifyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SpotifyException(ex.Message);
            }
        }

        /// <summary>
        /// Returns the User's Playlists
        /// </summary>
        /// <returns></returns>
        public static List<SpotifyPlaylist> GetPlaylists()
        {
            try
            {
                if (User.Default.PrivateProfile != null)
                {

                    Paging<SpotifyPlaylist> playlists = UserSpotify.WebAPI.GetUserPlaylists(UserSpotify.PrivateId);

                    return playlists.Items;

                }
                else
                {
                    throw new SpotifyUndefinedProfileError("Spotify Profile hasn't been defined yet.");
                }
            }
            catch (SpotifyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SpotifyException(ex.Message);
            }
        }
    }
}
