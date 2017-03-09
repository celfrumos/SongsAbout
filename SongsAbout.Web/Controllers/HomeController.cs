using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SongsAbout.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SpotifyAuth();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void SpotifyAuth()
        {
            Spotify.Authenticate();
            var playlist = Spotify.Api.GetPlaylist("rawdeg", "3rzuLmTVqB68cJR67jaaKh");
            var tracks = Spotify.Api.GetPlaylistTracks("rawdeg", playlist.Id);
            var builder = new StringBuilder();
            var existingArtists = new List<string>();
            var existingAlbums = new List<string>();
            var existingTracks = new List<string>();


            int i = 0;
            foreach (var pt in tracks.Items)
            {
                var track = pt.Track;
                var artist = track.Artists[0].GetFullVersion(Spotify.Api);

                if (!existingArtists.Contains(artist.Name))
                {
                    builder.Append("context.ProfilePics.Add(new ProfilePic{ ")
                        .Append("ProfilePicId = ").Append(i).Append(", ")
                        .Append("Url = ").Append(artist.Images[0].Url).Append(", ")
                        .Append("Width = ").Append(artist.Images[0].Width).Append(", ")
                        .Append("Heigth = ").Append(artist.Images[0].Height)
                        .AppendLine("};");

                    builder.Append("context.Artists.Add(new Artist{ ")
                        .Append("ArtistId = ").Append(i).Append(", ")
                        .Append("Name = ").Append(artist.Name).Append(", ")
                        .Append("SpotifyId = ").Append(artist.Id).Append(", ")
                        .Append("ProfilePicId = ").Append(i)
                        .AppendLine("};");

                    existingArtists.Add(artist.Name);
                }
                var album = track.Album.GetFullVersion(Spotify.Api);
                if (!existingAlbums.Contains(album.Name))
                {
                    builder.Append("context.AlbumCovers.Add(new AlbumCover{ ")
                        .Append("AlbumCoverId = ").Append(i).Append(", ")
                        .Append("Url = ").Append(album.Images[0].Url).Append(", ")
                        .Append("Width = ").Append(album.Images[0].Width).Append(", ")
                        .Append("Heigth = ").Append(album.Images[0].Height)
                        .AppendLine("};");

                    builder.Append("context.Albums.Add(new Album{ ")
                        .Append("ArtistId = ").Append(existingArtists.IndexOf(artist.Name)).Append(", ")
                        .Append("Name = ").Append(album.Name).Append(", ")
                        .Append("SpotifyId = ").Append(album.Id).Append(", ")
                        .Append("ReleaseDate = ").Append(album.ReleaseDate)
                        .Append("AlbumCoverId = ").Append(i)
                        .AppendLine("};");

                    existingAlbums.Add(album.Name);
                }

                if (!existingTracks.Contains(track.Name))
                {
                    builder.Append("context.Tracks.Add(new Track{ ")
                        .Append("TrackId = ").Append(i).Append(", ")
                        .Append("ArtistId = ").Append(existingArtists.IndexOf(artist.Id)).Append(", ")
                        .Append("AlbumId = ").Append(existingAlbums.IndexOf(album.Id)).Append(", ")
                        .Append("Name = ").Append(artist.Name).Append(", ")
                        .Append("SpotifyId = ").Append(artist.Id).Append(", ")
                        .Append("ReleaseDate = ").Append(album.ReleaseDate)
                        .Append("AlbumCoverId = ").Append(i)
                        .AppendLine("};");

                }
                using (var outFile = new StreamWriter("Seeds.txt"))
                {
                    outFile.Write(builder.ToString());
                }

            }
        }

        public static class Spotify
        {
            private const string REDIRECT_URI = "http://localhost";
            private const int PORT = 8000;
            public static SpotifyWebAPI Api { get; set; }
            /// <summary>
            /// Initial Setup of USer Spotify Settings
            /// </summary>
            public async static void AuthenticateAsync(string clientId = null)
            {
                try
                {
                    clientId = clientId == null ? Secrets.Spotify.ClientId : clientId;
                    WebAPIFactory webApiFactory = new WebAPIFactory(
                        REDIRECT_URI,
                        PORT,
                        clientId,
                        Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead |
                        Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead | Scope.PlaylistModifyPrivate | Scope.PlaylistModifyPublic);

                    if (Api == null)
                    {
                        Api = await webApiFactory.GetWebApi();
                    }

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

            /// <summary>
            /// Initial Setup of User Spotify Settings
            /// </summary>
            public static void Authenticate(string clientId = null)
            {
                try
                {
                    clientId = clientId == null ? Secrets.Spotify.ClientId : clientId;
                    WebAPIFactory webApiFactory = new WebAPIFactory(
                        REDIRECT_URI,
                        PORT,
                        clientId,
                        Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead |
                        Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead | Scope.PlaylistModifyPrivate | Scope.PlaylistModifyPublic);

                    if (Api == null)
                    {
                        var getter = webApiFactory.GetWebApi();
                        getter.Wait();
                        Api = getter.Result;
                    }
                }
                catch (SpotifyException ex)
                {
                    throw new SpotifyAuthError(inner: ex);
                }
                catch (System.Resources.MissingManifestResourceException ex)
                {
                    throw new SpotifyAuthError(inner: ex);
                }
                catch (Exception ex)
                {
                    var e = new SpotifyAuthError(ex.Message);
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
            }
        }


    }
}