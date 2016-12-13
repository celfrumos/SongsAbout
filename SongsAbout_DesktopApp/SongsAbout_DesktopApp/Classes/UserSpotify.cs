﻿using System;
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

namespace SongsAbout.Classes
{
    public class UserSpotify
    {
        public static SpotifyWebAPI WebAPI
        {
            get { return User.Default.SpotifyWebAPI; }
            set { User.Default.SpotifyWebAPI = value; }
        }

        public static string PrivateId
        {
            get { return User.Default.PrivateId; }
            set { User.Default.PrivateId = value; }
        }

        private const int PORT = 8000;
        private const string REDIRECT_URI = "http://localhost";

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
        public static  SearchItem Search(string query, SearchType searchType, int limit = 20, int offset = 0)
        {
            if (UserSpotify.WebAPI == null)
            {
                UserSpotify.Authenticate();
                while (UserSpotify.WebAPI == null)
                {
                    Thread.Sleep(1);
                }
            }

            var resultsList = UserSpotify.WebAPI.SearchItems(query, searchType, limit, offset);
            return resultsList;

        }
        /// <summary>
        /// Returns a list of User's saved tracks
        /// </summary>
        /// <returns></returns>
        public static List<FTrack> GetSavedTracks()
        {
            Paging<SavedTrack> savedTracks = new Paging<SavedTrack>();
            var list = new List<FTrack>();
            try
            {
                savedTracks = WebAPI.GetSavedTracks();

                list = savedTracks.Items.Select(track => (FTrack)track.Track).ToList();

                while (savedTracks.Next != null)
                {
                    savedTracks = User.Default.SpotifyWebAPI.GetSavedTracks(20, savedTracks.Offset + savedTracks.Limit);
                    list.AddRange(savedTracks.Items.Select(track => (FTrack)track.Track));
                }

                return list;
            }
            catch (Exception ex)
            {
                SpotifyException exception = new SpotifyException(ex.Message);

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
                throw new SpotifyImageImportError(ex.Message);
            }

        }

        /// <summary>
        /// Async method to get Profile image as a System.Drawing.Image
        /// </summary>
        /// <returns></returns>
        public async static Task<Image> ImportLocalProfilePic()
        {
            try
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
                                return _profilePic;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new SpotifyImageImportError($"Error importing profile pic from spotify image: {ex.Message}");
                    }
                }
                else
                {
                    throw new SpotifyUndefinedAPIError("Error importing profile pic from spotify image");
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
        /// Assign User Setting ProfilePic
        /// </summary>
        public static void FetchProfilePic()
        {
            try
            {
                if (User.Default.PrivateProfile != null)
                {
                    if (User.Default.PrivateProfile.Images.Count > 0)
                    {
                        User.Default["ProfilePic"] = User.Default.PrivateProfile.Images[0];
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

        public static List<FTrack> GetTopTracks()
        {
            try
            {
                if (User.Default.PrivateProfile != null)
                {
                    try
                    {
                        List<FTrack> trackList = new List<FTrack>();
                        var paging = WebAPI.GetUsersTopTracks();

                        paging.Items.ForEach(track => trackList.Add((FTrack)track));
                        return trackList;

                    }
                    catch (Exception ex)
                    {
                        throw new SpotifyImportError<Paging<FullTrack>>($"Error getting user's top tracks: {ex.Message}");
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

        private async static void PutPlaylists()
        {
            try
            {
                if (User.Default.PrivateProfile != null)
                {
                    var myPlaylists = await UserSpotify.WebAPI.GetUserPlaylistsAsync(User.Default.PrivateId, 5, 0);

                    foreach (SimplePlaylist playlist in myPlaylists.Items)
                    {
                        string playlistTrack = "";
                        string uri = playlist.Uri;
                        string playlistId = playlist.Id;

                        var tracks = User.Default.SpotifyWebAPI.GetPlaylistTracks(User.Default.PrivateId, playlistId);
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
                            throw new SpotifyImportError<Paging<SimplePlaylist>>(tracks.Error.Message);
                        }
                    }

                }
                else
                {
                    throw new SpotifyUndefinedProfileError();
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

        public static List<SPlaylist> GetPlaylists()
        {
            try
            {
                if (User.Default.PrivateProfile != null)
                {

                    Paging<SimplePlaylist> playlists = UserSpotify.WebAPI.GetUserPlaylists(User.Default.PrivateId);

                    List<SPlaylist> playlistList = new List<SPlaylist>();
                    playlists.Items.ForEach(ss => playlistList.Add((SPlaylist)ss));

                    return playlistList;

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
