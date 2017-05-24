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
                    if (a.Name == "Kevin Parker")
                    {

                    }
                    if (!artists.ContainsKey(a.Name))
                    {
                        SpotifyImage pic;
                        if (a.Images.Count > 0)
                            pic = a.Images[0];
                        else
                            pic = null;

                        var profilePic = pic == null ? null : context.Create(new Picture(pic, a.Name));

                        int picId = profilePic?.Id ?? 0;

                        Artist artist = context.Create<Artist>(new Artist(a) { ProfilePicId = picId });


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

                        var cover = pic == null ? null : context.Create(new Picture(pic, al.Name));

                        int coverid = cover?.Id ?? -1;
                        string artistName = al.Artists.Count > 0 ? al.Artists[0].Name : null;
                        int artistId = 0;

                        if (artistName != null && artists.ContainsKey(artistName))
                        {
                            artistId = artists[artistName];
                        }

                        var album = context.Create<Album>(new Album(al) { AlbumCoverId = coverid, ArtistId = artistId });

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

                        int artistId = -1,
                            albumId = -1;
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

            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}