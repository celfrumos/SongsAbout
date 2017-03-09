using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SongsAbout.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                //  Runthing().Wait();
                //await Task.Run(() => SpotifyAuth());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        private async Task Runthing()
        {
            await SpotifyAuthAsync();
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
            var artistBuilder = new StringBuilder();
            var albumBuilder = new StringBuilder();
            var trackBuilder = new StringBuilder();

            var profilePicBuilder = new StringBuilder();
            var albumCoverBuilder = new StringBuilder();

            var existingArtists = new Dictionary<string, int>();
            var existingAlbums = new Dictionary<string, int>();
            var existingTracks = new Dictionary<string, int>();
            try
            {
                PlaylistTrack pt;
                SpotifyTrack track;
                SpotifyFullArtist artist;
                SpotifyFullAlbum album;
                for (int i = 0; i < tracks.Items.Count; i++)
                {
                    try
                    {
                        pt = tracks.Items[i];

                        track = pt.Track;
                        artist = track.Artists[0].GetFullVersion(Spotify.Api);
                        album = track.Album.GetFullVersion(Spotify.Api);

                        if (!existingArtists.ContainsKey(artist.Name))
                        {
                            profilePicBuilder.Append("context.ProfilePics.Add(new ProfilePic{ ")
                                .Append("ProfilePicId = ").Append(i).Append(", ")
                                .Append("Url = \"").Append(artist.Images[0].Url).Append("\", ")
                                .Append("AltText = \"img-").Append(artist.Name).Append("\", ")
                                .Append("Width = ").Append(artist.Images[0].Width).Append(", ")
                                .Append("Height = ").Append(artist.Images[0].Height)
                                .AppendLine("});");

                            artistBuilder.Append("context.Artists.Add(new Artist{ ")
                                .Append("ArtistId = ").Append(i).Append(", ")
                                .Append("Name = \"").Append(artist.Name).Append("\", ")
                                .Append("SpotifyId = \"").Append(artist.Id).Append("\", ")
                                .Append("ProfilePicId = ").Append(i)
                                .AppendLine("});");

                            existingArtists[artist.Name] = i;
                        }
                        if (!existingAlbums.ContainsKey(track.Album.Name) && track.Artists != null && existingArtists.ContainsKey(artist.Name))
                        {
                            albumCoverBuilder.Append("context.AlbumCovers.Add(new AlbumCover{ ")
                                .Append("AlbumCoverId = ").Append(i).Append(", ")
                                .Append("Url = \"").Append(album.Images[0].Url).Append("\", ")
                                .Append("AltText = \"img-").Append(album.Name).Append("\", ")
                                .Append("Width = ").Append(album.Images[0].Width).Append(", ")
                                .Append("Height = ").Append(album.Images[0].Height)
                                .AppendLine("});");

                            albumBuilder.Append("context.Albums.Add(new Album{ ")
                                .Append("AlbumId = ").Append(i).Append(", ")
                                .Append("ArtistId = ").Append(existingArtists[artist.Name]).Append(", ")
                                .Append("Name = \"").Append(album.Name).Append("\", ")
                                .Append("SpotifyId =\" ").Append(album.Id).Append("\", ")
                                .Append("ReleaseDate = Convert.ToDateTime( \"").Append(album.ReleaseDate).Append("\"),")
                                .Append("AlbumCoverId = ").Append(i)
                                .AppendLine("});");

                            existingAlbums[album.Name] = i;
                        }

                        if (!existingTracks.ContainsKey(track.Name) && track.Artists != null && existingArtists.ContainsKey(artist.Name) && track.Album != null && existingArtists.ContainsKey(artist.Name))
                        {
                            trackBuilder.Append("context.Tracks.Add(new Track{ ")
                                .Append("TrackId = ").Append(i).Append(", ")
                                .Append("ArtistId = ").Append(existingArtists[artist.Name]).Append(", ")
                                .Append("AlbumId = ").Append(existingAlbums[album.Name]).Append(", ")
                                .Append("Name = \"").Append(track.Name).Append("\", ")
                                .Append("SpotifyId = \"").Append(artist.Id).Append("\" ")
                                .AppendLine("});");
                            existingTracks[track.Name] = i;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } // end loop

                using (var outFile = new StreamWriter(@"C:\Users\jdegr_000\Desktop\Seeds.txt"))
                {
                    outFile.WriteLine("\n// Profile Pics\n");
                    outFile.Write(profilePicBuilder.ToString());

                    outFile.WriteLine("\n// Arists\n");
                    outFile.Write(artistBuilder.ToString());

                    outFile.WriteLine("\n// Album Covers\n");
                    outFile.Write(albumCoverBuilder.ToString());

                    outFile.WriteLine("\n// Albums\n");
                    outFile.Write(albumBuilder.ToString());

                    outFile.WriteLine("\n// Tracks\n");
                    outFile.Write(trackBuilder.ToString());

                } // end using block
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task SpotifyAuthAsync()
        {
            Spotify.Authenticate();
            var playlist = Spotify.Api.GetPlaylist("rawdeg", "3rzuLmTVqB68cJR67jaaKh");
            var tracks = await Spotify.Api.GetPlaylistTracksAsync("rawdeg", playlist.Id);
            var builder = new StringBuilder();
            var existingArtists = new List<string>();
            var existingAlbums = new List<string>();
            var existingTracks = new List<string>();

            using (var outFile = new StreamWriter(@"C:\Users\jdegr_000\DesktopSeeds.txt"))
            {

                int i = 0;
                foreach (var pt in tracks.Items)
                {
                    try
                    {
                        var track = pt.Track;
                        var artist = await track.Artists[0].GetFullVersionAsync(Spotify.Api);

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
                        if (!existingAlbums.Contains(track.Album.Name))
                        {
                            var album = await track.Album.GetFullVersionAsync(Spotify.Api);
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
                                .Append("ArtistId = ").Append(existingArtists.IndexOf(artist.Name)).Append(", ")
                                .Append("AlbumId = ").Append(existingAlbums.IndexOf(track.Id)).Append(", ")
                                .Append("Name = ").Append(artist.Name).Append(", ")
                                .Append("SpotifyId = ").Append(artist.Id).Append(", ")
                                .AppendLine("};");
                            existingTracks.Add(track.Name);
                        }
                        outFile.Write(builder.ToString());
                        builder.Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    i++;
                }
                await outFile.WriteAsync(builder.ToString());
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