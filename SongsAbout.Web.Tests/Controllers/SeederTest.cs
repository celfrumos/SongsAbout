using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SpotifyAPI.Web.Models;
using System.Linq;
using System.Data.Entity;
using Telerik.JustMock;
using Telerik.JustMock.EntityFramework;
using System.Web.Mvc;
using SongsAbout.Web.Models;

namespace SongsAbout.Web.Tests.Controllers
{
    [TestClass]
    public class SeederTest
    {
        [TestMethod]
        public void Seed()
        {
            try
            {
                var context = Mock.Create<EntityDbContext>(Constructor.Mocked);
                Spotify.Authenticate();

                //    Spotify.CallAndStoreSeedData();
                var artists = new Dictionary<string, int>();
                var albums = new Dictionary<string, int>();
                var tracks = new Dictionary<string, int>();

                var seederTask = Spotify.CallDataForSeedingAsync();
                seederTask.Wait();
                var seed = seederTask.Result;

                // Artists
                foreach (var a in seed.Artists)
                {
                    if (!artists.ContainsKey(a.Name))
                    {
                        SpotifyImage pic;
                        if (a.Images.Count > 0)
                            pic = a.Images[0];
                        else
                            pic = null;

                        var profilePic = pic != null ? context.Create(new Picture(pic, a.Name)) : null;

                        int picId = profilePic?.Id ?? -1;

                        Artist artist = context.Create<Artist>(new Artist(a));


                        artists.Add(artist.Name, artist.Id);
                    }
                }
                context.SaveChanges();
                // Albums
                foreach (var al in seed.Albums)
                {
                    if (!albums.ContainsKey(al.Id))
                    {
                        SpotifyImage pic;
                        if (al.Images.Count > 0)
                            pic = al.Images[0];
                        else
                            pic = null;

                        var cover = context.Create(new Picture(pic, al.Name));

                        int coverid = cover?.Id ?? -1;
                        string artistName = al.Artists.Count > 0 ? al.Artists[0].Name : null;
                        int artistId = -1;

                        if (artistName != null && artists.ContainsKey(artistName))
                        {
                            artistId = artists[artistName];
                        }

                        var album = context.Create<Album>(new Album(al));

                        albums.Add(album.Name, album.Id);
                    }
                }

                context.SaveChanges();
                // Tracks
                foreach (var t in seed.Tracks)
                {
                    if (!tracks.ContainsKey(t.Name))
                    {
                        var feat = seed.Features.Where(a => a.Id == t.Id).FirstOrDefault();

                        int artistId = -1, albumId = -1;
                        string artistName = t.Artists.Count > 0 ? t.Artists[0].Name : null;

                        if (artistName != null && artists.ContainsKey(artistName))
                        {
                            artistId = artists[artistName];
                        }
                        if (t.Album?.Name != null && albums.ContainsKey(t.Album.Name))
                        {
                            albumId = albums[t.Album.Name];
                        }

                        Track track = context.Create<Track>(new Track(t, feat) { ArtistId = artistId, AlbumId = albumId });

                        tracks.Add(track.Name, track.Id);
                    }
                }

                context.Dispose();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

    }
}
