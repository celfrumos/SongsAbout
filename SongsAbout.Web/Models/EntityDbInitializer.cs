using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SpotifyAPI.Web.Models;
using System.IO;
using System.Threading.Tasks;

namespace SongsAbout.Web.Models
{
    public class EntityDbInitializer : DropCreateDatabaseAlways<EntityDbContext>
    {


        protected override void Seed(EntityDbContext context)
        {

            try
            {
                if (!Spotify.Authenticated)
                    Spotify.Authenticate();

                //    Spotify.CallAndStoreSeedData();
                var artists = new Dictionary<string, int>();
                var albums = new Dictionary<string, int>();
                var tracks = new Dictionary<string, int>();

                var seed = Spotify.CallDataForSeeding();

                // Artists
                foreach (var a in seed.Artists)
                {
                    if (!artists.ContainsKey(a.Name))
                    {
                        List<Picture> images = new List<Picture>();
                        Picture pic = null;
                        if (a.Images?.Count > 0)
                        {
                            for (int i = 0; i < a.Images.Count; i++)
                            {
                                images.Add(context.Create(new Picture(a.Images[i], $"{a.Name}-{i}", SaEntityType.Artist)));
                            }
                            pic = images[0];
                        }
                        else
                            pic = null;


                        var ar = new Artist(a);
                        ar.Pictures = images;

                        Artist artist = context.Create<Artist>(ar);


                        artists.Add(artist.Name, artist.Id);
                    }
                }
                context.SaveChanges();
                // Albums
                foreach (var al in seed.Albums)
                {
                    if (!albums.ContainsKey(al.Id))
                    {
                        List<Picture> images = new List<Picture>();
                        Picture pic = null;
                        if (al.Images?.Count > 0)
                        {
                            for (int i = 0; i < al.Images.Count; i++)
                            {
                                images.Add(context.Create(new Picture(al.Images[i], $"{al.Name}-{i}", SaEntityType.Album)));
                            }
                            pic = images[0];
                        }
                        else
                            pic = null;

                        int coverid = pic?.Id ?? 0;
                        string artistName = al.Artists.Count > 0 ? al.Artists[0].Name : null;

                        int artistId = 0;

                        if (artistName != null && artists.ContainsKey(artistName))
                        {
                            artistId = artists[artistName];
                        }
                        var alb = new Album(al) { ArtistId = artistId };
                        alb.Pictures = images;
                        var album = context.Create<Album>(alb);

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

                        int artistId = 0,
                            albumId = 0;
                        string artistName = t.Artists.Count > 0 ? t.Artists[0].Name : null;

                        if (artistName != null && artists.ContainsKey(artistName))
                        {
                            artistId = artists[artistName];
                        }
                        if (t.Album?.Name != null && albums.ContainsKey(t.Album.Name))
                        {
                            albumId = albums[t.Album.Name];
                        }
                        // var artist = context.Get<Artist>(artists[artistName]);
                        // var album = context.Get<Album>(albums[t.Album.Name]);
                        try
                        {
                            var tr = new Track(t, feat, artistId, albumId);
                            tr.Artist = context.Get<Artist>(artistId);
                            tr.Album = context.Get<Album>(albumId);
                            Track track = context.Create<Track>(tr);

                            tracks.Add(track.Name, track.Id);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}