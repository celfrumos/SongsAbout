using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using System.Net.Sockets;
using SpotifyAPI.Local.Models;

using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SongsAbout.Web.Startup))]
namespace SongsAbout.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}

namespace SongsAbout
{
    /// <summary>
    /// Class to hold Methods used for dealing with SpotifyAPI, specific to the user
    /// </summary>
    public static class UserSpotify
    {
        private const string REDIRECT_URI = "http://localhost";
        private const int PORT = 8000;
        private static SpotifyWebAPI _webApi { get; set; }
        /// <summary>
        /// Use this to Call the WebAPI for spotify
        /// </summary>
        public static SpotifyWebAPI WebAPI { get; set; }

        /// <summary>
        /// User's Spotify Profile Picture
        /// </summary>
        public static Image ProfilePic { get; set; }

        /// <summary>
        /// Get the User's Private Profile
        /// </summary>
        public static PrivateProfile PrivateProfile { get; private set; }

        /// <summary>
        /// Get the User's Followed Artists
        /// </summary>
        public static FollowedArtists FollowedArtists { get; private set; }
        public static string PrivateId { get; private set; }
        public static PublicProfile PublicProfile { get; private set; }


        /// <summary>
        /// Initial Setup of USer Spotify Settings
        /// </summary>
        public async static void AuthenticateAsync()
        {
            try
            {
                string clientId = Secrets.Spotify.ClientId;

                SpotifyWebAPI _spotify = new SpotifyWebAPI();
                WebAPIFactory webApiFactory = new WebAPIFactory(
                    REDIRECT_URI,
                    PORT,
                   clientId,
                    Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead |
                    Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead | Scope.PlaylistModifyPrivate | Scope.PlaylistModifyPublic);

                if (UserSpotify.WebAPI == null)
                {
                    UserSpotify.WebAPI = await webApiFactory.GetWebApi();
                }

                FetchProfile();
                FetchFollowedArtists();
                FetchProfilePic();
            }
            catch (SpotifyException ex)
            {
                throw new SpotifyAuthError(inner: ex);
            }
            catch (System.Resources.MissingManifestResourceException)
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
                if (UserSpotify.PrivateProfile == null)
                {
                    UserSpotify.PrivateProfile = WebAPI.GetPrivateProfile();
                    //User.Default.PrivateProfile = _profile;
                    UserSpotify.PrivateId = UserSpotify.PrivateProfile.Id;
                    UserSpotify.PublicProfile = WebAPI.GetPublicProfile(UserSpotify.PrivateId);

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
                    var authTask = Task.Run(() => UserSpotify.AuthenticateAsync());
                    authTask.Wait();
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
                    savedTracks = UserSpotify.WebAPI.GetSavedTracks(20, savedTracks.Offset + savedTracks.Limit);
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
                if (UserSpotify.PrivateProfile != null)
                {
                    if (UserSpotify.PrivateProfile.Images.Count > 0)
                    {
                        UserSpotify.ProfilePic = UserSpotify.PrivateProfile.Images[0];
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
                    UserSpotify.FollowedArtists = await UserSpotify.WebAPI.GetFollowedArtistsAsync(FollowType.Artist);
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
                if (UserSpotify.PrivateProfile != null)
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
                        throw new SpotifyImportError(SpotifyEntityType.Track, $"Error getting user's top tracks: {ex.Message}");
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
                if (UserSpotify.PrivateProfile != null)
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
