using System;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;
using System.IO;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Models;
using SpotifyAPI.Local.Enums;
using SongsAbout_DesktopApp.Properties;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using Image = System.Drawing.Image;

namespace SongsAbout_DesktopApp.Classes
{
    public static class Importer
    {
        public static void ImportAll()
        {
            try
            {
                // ImportTopTracks();
                //ImportSavedPlaylists();
                ImportFollowedArtists();
                //ImportSavedTracks();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Importing data from Spotify: {ex.Message}");
            }
        }

        public static void ImportFollowedArtists()
        {
            try
            {
                FollowedArtists followedArtists = UserSpotify.WebAPI.GetFollowedArtists(FollowType.Artist);
                foreach (FullArtist a in followedArtists.Artists.Items)
                {
                    ImportArtist(a);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Importing Followed Artists:{ex.Message}");
            }
        }

        private static void ImportArtist(FullArtist artist)
        {
            try
            {
                if (!Artist.Exists(artist.Name))
                {
                    Artist a = new Artist();
                    a.Update(artist);
                    a.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, $"Error importing artist '{artist.Name}'");
            }
        }

        public static void ImportSavedPlaylists()
        {
            foreach (SimplePlaylist playlist in UserSpotify.WebAPI.GetUserPlaylists(User.Default.UserId, 50, 21).Items)
            {
                try
                {
                    Paging<PlaylistTrack> playlists = UserSpotify.WebAPI.GetPlaylistTracks(User.Default.UserId, playlist.Id);
                    foreach (PlaylistTrack pt in playlists.Items)
                    {
                        ImportTrack(pt.Track);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error importing Playlist: {playlist.Name}, {ex.Message}");
                    //throw new Exception(ex.Message);
                }
            }
            Console.WriteLine("Finished importing Saved Playlists.");
        }

        public static void ImportTrack(SimpleTrack t)
        {
            try
            {
                FullTrack track = User.Default.SpotifyWebAPI.GetTrack(t.Id);
                ImportTrack(ref track);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ImportTrack(FullTrack t)
        {
            try
            {
                if (!Track.Exists(t.Name))
                {
                    Track track = new Track();
                    track.Update(t);
                    track.Save();
                    Console.WriteLine($"Successfully Imported track {t.Name}");
                }
                else {
                    Console.WriteLine($"Track '{t.Name}' already exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw new Exception(ex.Message);
            }
        }

        public static void ImportTrack(ref FullTrack t)
        {
            try
            {
                if (!Track.Exists(t.Name))
                {
                    Track track = new Track(t);
                    //  track.Update(t);
                    track.Save();
                    Console.WriteLine($"Successfully Imported track {t.Name}");
                }
                else
                {
                    Console.WriteLine($"Track '{t.Name}' already exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw new Exception(ex.Message);
            }
        }

        public static Image ImportSpotifyImage(SpotifyAPI.Web.Models.Image pic)
        {
            if (User.Default.PrivateProfile != null)
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        Image systemPic;
                        byte[] imageBytes = wc.DownloadData(new Uri(pic.Url));
                        using (MemoryStream stream = new MemoryStream(imageBytes))
                        {
                            systemPic = Image.FromStream(stream);
                            return systemPic;
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting profile photo " + ex.Message);
                }
            }
            else
            {
                throw new Exception("User WebAPI undefined");
            }
        }

        public static byte[] ImportSpotifyImageBytes(SpotifyAPI.Web.Models.Image pic)
        {
            if (User.Default.PrivateProfile != null)
            {
                try
                {
                    WebClient wc = new WebClient();
                    //TODO: test out non-async downloading
                    byte[] imageBytes = wc.DownloadData(new Uri(pic.Url));

                    return imageBytes;

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

        public static void ImportSavedTracks()
        {
            Paging<SavedTrack> tracks = User.Default.SpotifyWebAPI.GetSavedTracks();
            foreach (SavedTrack t in tracks.Items)
            {
                try
                {
                    FullTrack track = User.Default.SpotifyWebAPI.GetTrack(t.Track.Id);
                    ImportTrack(track);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ImportAlbum(SimpleAlbum album)
        {
            try
            {
                FullAlbum al = User.Default.SpotifyWebAPI.GetAlbum(album.Id);
                ImportAlbum(al);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting full album '{album.Name}': {ex.Message}");
            }
        }

        public static void ImportAlbum(FullAlbum album)
        {
            try
            {
                Album a = new Album();
                if (!Album.Exists(album.Name))
                {
                    a.Update(album);
                    a.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public static void ImportEntireAlbum(FullAlbum album)
        {
            try
            {
                Album a;
                if (!Album.Exists(album.Name))
                {
                    a = new Album(album);
                    foreach (SimpleTrack track in album.Tracks.Items)
                    {
                        Track t = new Track(track);
                        t.Save();
                    }
                    a.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public static void ImportTopTracks()
        {
            try
            {
                Paging<FullTrack> topTracks = UserSpotify.GetTopTracks();
                foreach (FullTrack t in topTracks.Items)
                {
                    ImportTrack(t);
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error fetching user's top tracks: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }

        }

        //public static void ImportPlaylistTrackArtists(PlaylistTrack pt)
        //{
        //    foreach (SimpleArtist ar in pt.Track.Artists)
        //    {
        //        try
        //        {
        //            ImportArtist(ar);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            throw new Exception(ex.Message);
        //        }
        //    }
        //}

        public static void ImportArtist(SimpleArtist ar)
        {
            try
            {
                FullArtist artist = User.Default.SpotifyWebAPI.GetArtist(ar.Id);

                if (!Artist.Exists(artist.Name))
                {
                    Artist a = new Artist();
                    a.Update(artist);
                    a.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, $"Error importing artist '{ar.Name}'");
            }
        }


        //public static void ImportSavedAlbums()
        //{
        //    User.Default.SpotifyWebAPI.GetSavedAlbums();
        //}

    }
}
