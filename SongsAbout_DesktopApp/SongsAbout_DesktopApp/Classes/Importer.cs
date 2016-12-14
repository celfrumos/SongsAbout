using System;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;
using System.IO;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Models;
using SpotifyAPI.Local.Enums;
using SongsAbout.Properties;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SongsAbout.Entities;
using SongsAbout.Enums;
using Track = SongsAbout.Entities.Track;
using Image = System.Drawing.Image;
using System.Drawing;

namespace SongsAbout.Classes
{
    public static class Importer
    {
        public static void ImportAll()
        {
            try
            {
                ImportFollowedArtists();
                ImportTopTracks();
                ImportSavedTracks();
                ImportSavedPlaylists();
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
                if (!Program.Database.Artists.Contains(artist.Name))
                {
                    Artist a = new Artist(artist);
                    //a.Update(artist);
                    //a.Save();
                    Program.Database.Artists.Add(a);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, $"Error importing artist '{artist.Name}'");
            }
        }

        public static void ImportSavedPlaylists()
        {
            foreach (SimplePlaylist playlist in UserSpotify.WebAPI.GetUserPlaylists(User.Default.PrivateId).Items)
            {
                try
                {
                    Paging<PlaylistTrack> playlists = UserSpotify.WebAPI.GetPlaylistTracks(User.Default.PrivateId, playlist.Id);
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

        /// <summary>
        /// Import the Given Spotify Track into the Database
        /// </summary>
        /// <param name="track"></param>
        /// <exception cref="SaveError"></exception>
        /// <exception cref="SpotifyImportError"></exception>
        public static void ImportTrack(SimpleTrack track)
        {
            try
            {
                ImportTrack(Converter.GetFullTrack(track));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Import the Given Spotify Track into the Database
        /// </summary>
        /// <param name="track"></param>
        /// <exception cref="SaveError"></exception>
        /// <exception cref="SpotifyImportError"></exception>
        public static void ImportTrack(FullTrack track)
        {
            ImportTrack(new FTrack(track));
        }

        /// <summary>
        /// Import the Given Spotify Track into the Database
        /// </summary>
        /// <param name="track"></param>
        /// <exception cref="SaveError"></exception>
        /// <exception cref="SpotifyImportError"></exception>
        public static void ImportTrack(ISpotifyFullEntity track)
        {
            ImportTrack((FTrack)track);
        }

        /// <summary>
        /// Import the Given Spotify Track into the Database
        /// </summary>
        /// <param name="track"></param>
        /// <exception cref="SaveError"></exception>
        /// <exception cref="SpotifyImportError"></exception>
        public static void ImportTrack(FTrack track)
        {
            try
            {
                if (!Track.Exists(track.Name))
                {
                    Program.Database.Tracks[track.Name] = new Track(track);
                }
                else
                {
                    Console.WriteLine($"Track '{track.Name}' already exists");
                }
            }
            catch (SaveError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SpotifyImportError(ex.Message);
            }
        }
        public static bool ImportFromSpotify(ISpotifyEntity spotifyEntity, DbEntityType dbType, SpotifyEntityType spotifyEntityType)
        {
            var name = spotifyEntity.Name;

            switch (dbType)
            {
                case DbEntityType.Artist:
                    if (!Program.Database.Artists.Contains(name))
                    {
                        var a = new Artist(spotifyEntity);
                        a.Save();
                        return true;
                    }
                    break;
                case DbEntityType.Album:
                    if (Album.Exists(name))
                    {
                        var a = new Artist(spotifyEntity);
                        a.Save();
                    }
                    break;
                case DbEntityType.Track:
                    if (Track.Exists(name))
                    {
                        var t = new Track(spotifyEntity);
                        t.Save();
                    }
                    break;
                default:
                    break;
            }
            return false;
        }


        public static bool ImportFromSpotify(ISpotifyEntity spotifyEntity)
        {
            var name = spotifyEntity.Name;
            var spotifyEntityType = spotifyEntity.SpotifyEntityType;
            var dbType = spotifyEntity.DbEntityType;
            switch (dbType)
            {
                case DbEntityType.Artist:
                    if (!Program.Database.Artists.Contains(name))
                    {
                        Program.Database.Artists[spotifyEntity.Name] = new Artist(spotifyEntity);
                        return true;
                    }
                    break;
                case DbEntityType.Album:
                    if (!Album.Exists(name))
                    {
                        var a = new Album(spotifyEntity, spotifyEntityType);
                        a.Save();
                        return true;
                    }
                    break;
                case DbEntityType.Track:
                    if (!Track.Exists(name))
                    {
                        var t = new Track(spotifyEntity);
                        t.Save();
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
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

                        systemPic = Converter.ImageFromBytes(imageBytes);

                        return systemPic;
                    }

                }
                catch (Exception ex)
                {
                    throw new SpotifyImageImportError(ex.Message);
                }
            }
            else
            {
                throw new SpotifyUndefinedProfileError();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pic"></param>
        /// <returns></returns>
        /// <exception cref="SpotifyUndefinedAPIError"></exception>
        /// <exception cref="ConversionError"></exception>
        public static byte[] ImportSpotifyImageBytes(SpotifyAPI.Web.Models.Image pic)
        {
            if (UserSpotify.WebAPI != null)
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
                    throw new ConversionError("SpotifyImage", "byte[]", $"Error getting profile photo: {ex.Message}");
                }
            }
            else
            {
                throw new SpotifyUndefinedAPIError();
            }
        }

        /// <summary>
        /// Import All Saved Tracks into the datbase
        /// </summary>
        /// <exception cref="SpotifyUndefinedAPIError"></exception>
        /// <exception cref="SpotifyException"></exception>
        public static void ImportSavedTracks()
        {
            if (UserSpotify.WebAPI == null)
                throw new SpotifyUndefinedAPIError();

            try
            {
                Paging<SavedTrack> tracks = UserSpotify.WebAPI.GetSavedTracks();
                var existingTracks = Program.Database.Tracks.AllNames;

                foreach (SavedTrack track in tracks.Items)
                {
                    if (!existingTracks.Contains(track.Track.Name))
                    {
                        try
                        {
                            ImportTrack(Converter.GetFullTrack(track));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            catch (SpotifyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void ImportAlbum(SimpleAlbum album)
        {
            try
            {
                ImportAlbum(Converter.GetFullAlbum(album));
            }
            catch (SpotifyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SpotifyImportError<SimpleAlbum>($"Error getting full album '{album.Name}': {ex.Message}");
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
                    foreach (var track in album.Tracks.Items)
                    {
                        var t = new Track(track);
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
                var topTracks = UserSpotify.GetTopTracks();
                foreach (FTrack t in topTracks)
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


        public static void ImportArtist(SimpleArtist ar)
        {
            try
            {
                FullArtist artist = User.Default.SpotifyWebAPI.GetArtist(ar.Id);

                if (!Program.Database.Artists.Contains(artist.Name))
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



    }
}
