using SongsAbout.Web.Models;
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
    public class SpotifyController : Controller
    {
        // GET: Spotify
        public ActionResult Index()
        {
            Spotify.Authenticate();
            var tracks = Spotify.WebApi.GetUsersTopTracks(TimeRangeType.LongTerm);
            var artists = Spotify.WebApi.GetUsersTopArtists(TimeRangeType.LongTerm, 6);
            var playlists = Spotify.WebApi.GetUserPlaylists(Spotify.UserId, 6);
            (Paging<SpotifyFullTrack> Tracks, Paging<SpotifyFullArtist> Artists, Paging<SpotifyPlaylist> Playlists) results = (tracks, artists, playlists);
            ViewBag.Items = results;
            return View();
        }

        public void Authorize()
        {
            if (!Spotify.Authenticated)
                Spotify.Authenticate();
        }

        private StringBuilder WriteProfilePic(string name, SpotifyImage image, int i)
        {
            return new StringBuilder()
                                .Append("context.ProfilePics.Add(new ProfilePic{ ")
                                .Append("ProfilePicId = ").Append(i).Append(", ")
                                .Append("Url = \"").Append(image.Url).Append("\", ")
                                .Append("AltText = \"img-").Append(name).Append("\", ")
                                .Append("Width = ").Append(image.Width).Append(", ")
                                .Append("Height = ").Append(image.Height)
                                .AppendLine("});");
        }

        public async Task SpotifyAuthAsync()
        {
            Spotify.Authenticate();
            var playlist = Spotify.WebApi.GetPlaylist("rawdeg", "3rzuLmTVqB68cJR67jaaKh");
            var tracks = await Spotify.WebApi.GetPlaylistTracksAsync("rawdeg", playlist.Id);
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
                        var artist = await track.Artists[0].GetFullVersionAsync(Spotify.WebApi);

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
                            var album = await track.Album.GetFullVersionAsync(Spotify.WebApi);
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

        public async Task<ViewResult> Browse()
        {
            var artists = Spotify.WebApi.GetUserPlaylistsAsync(Spotify.UserId);
            var items = await Spotify.CallDataForSeedingAsync();
            return View(items);
        }

        public async Task<ViewResult> Search(string q, SaEntityType type = SaEntityType.Any, int limit = 5, int offset = 0)
        {
            SearchItem results = await Spotify.SearchAsync(q, type, limit, offset);

            return View(results);
        }

        public PartialViewResult SpotifyArtistPartial(SpotifyFullArtist artist)
        {
            //  ViewBag.EntityDisplayType = type;
            return PartialView(artist);
        }
        public PartialViewResult SpotifyTrackPartial(SpotifyFullTrack track)
        {
            return PartialView(track);
        }
    }



}