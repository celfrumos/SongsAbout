using System;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;
using System.IO;
using SpotifyAPI.Local;
//using SpotifyAPI.Local.Models;
using SpotifyAPI.Local.Enums;
using SongsAbout.Desktop.Database;

using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SongsAbout.Desktop.Entities;
using SongsAbout.Enums;
using Image = System.Drawing.Image;
using System.Drawing;

namespace SongsAbout
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
                foreach (SpotifyFullArtist a in followedArtists.Artists.Items)
                {
                    ImportArtist(a);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Importing Followed Artists:{ex.Message}");
            }
        }

        public static void ImportArtist(SpotifyFullArtist artist)
        {
            try
            {
                SongDatabase.Artists.Add(new Artist(artist));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, $"Error importing artist '{artist.Name}'");
            }
        }

        public static void ImportSavedPlaylists(bool includeAllTracks = false)
        {

            SongDatabase.LargeQuery = true;
            var existingEntries = SongDatabase.Playlists.Items;
            foreach (SpotifyPlaylist playlist in UserSpotify.WebAPI.GetUserPlaylists(User.Default.PrivateId).Items)
            {
                try
                {
                    Playlist newList = SongDatabase.Playlists[playlist.Name];

                    if (newList == null)
                    {
                        SongDatabase.Playlists.Add(playlist);
                        newList = SongDatabase.Playlists[playlist.Name];
                    }


                    if (includeAllTracks)
                    {
                        var playlistTracks = UserSpotify.WebAPI.GetPlaylistTracks(User.Default.PrivateId, playlist.Id);

                        foreach (PlaylistTrack pt in playlistTracks.Items)
                        {

                            Track track = SongDatabase.Tracks[pt.Track.Name];
                            if (track == null)
                            {
                                track = pt.Track;
                                track.Save();
                                track = SongDatabase.Tracks[pt.Track.Name];
                            }
                            if (!newList.Tracks.Contains(track))
                            {
                                newList.Tracks.Add(track);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error importing Playlist: {playlist.Name}, {ex.Message}");
                }
            }
            SongDatabase.LargeQuery = false;
            Console.WriteLine("Finished importing Saved Playlists.");
        }

        private static void ImportPlaylist(SpotifyPlaylist playlist)
        {
            try
            {
                if (!SongDatabase.Playlists.AllNames.Contains(playlist.Name))
                {
                    SongDatabase.Playlists.Add(playlist);
                }
            }
            catch (Exception ex)
            {
                throw new SpotifyToDBImportException(SpotifyEntityType.Playlist, DbEntityType.Playlist, ex.Message);
            }
        }

        /// <summary>
        /// Import the Given Spotify Track into the Database
        /// </summary>
        /// <param name="track"></param>
        /// <exception cref="SaveError"></exception>
        /// <exception cref="SpotifyImportError"></exception>
        public static void ImportTrack(SpotifyTrack track)
        {
            try
            {
                SongDatabase.Tracks.Add(track);
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
        
        public static bool ImportFromSpotify(SpotifyIntegralEntity spotifyEntity)
        {
            var name = spotifyEntity.Name;
            var spotifyEntityType = spotifyEntity.SpotifyEntityType;
            var dbType = spotifyEntity.DbEntityType;
            // DbEntityType actualDbType = DbEntityType.None;
            try
            {
                switch (dbType)
                {
                    case SpotifyEntityType.Artist:
                        ImportArtist((SpotifyArtist)spotifyEntity);

                        return true;
                    case SpotifyEntityType.Album:
                        SongDatabase.Albums.Add(new Album((SpotifyAlbum)spotifyEntity));
                        return true;
                    case SpotifyEntityType.Track:
                        SongDatabase.Tracks.Add(new Track((SpotifyTrack)spotifyEntity));
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new SpotifyToDBImportException(spotifyEntityType, (DbEntityType)dbType, ex.Message);
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
                var tracks = UserSpotify.WebAPI.GetSavedTracks();
                // var existingTracks = SongDatabase.Tracks.AllNames;

                foreach (SavedTrack track in tracks.Items)
                {
                    //if (!existingTracks.Contains(track.Track.Name))
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
            catch (SpotifyException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void ImportAllPlaylists()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void ImportAlbum(SpotifyAlbum album)
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
                throw new SpotifyImportError(SpotifyEntityType.Album, $"Error getting full album '{album.Name}': {ex.Message}");
            }
        }

        public static void ImportAlbum(SpotifyFullAlbum album, bool importTracks = false)
        {
            try
            {
                Album a = SongDatabase.Albums[album.Name];

                if (a == null)
                {
                    a = new Album(album);
                    SongDatabase.Albums.Add(a);
                    a = SongDatabase.Albums[album.Name];
                }

                if (importTracks)
                {
                    foreach (var track in album.Tracks.Items)
                    {
                        SongDatabase.Tracks.Add(new Track(track));
                    }
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
                foreach (SpotifyTrack t in topTracks)
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


        public static void ImportArtist(SpotifyArtist ar)
        {
            try
            {
                SpotifyFullArtist artist = ar.GetFullVersion(UserSpotify.WebAPI);
                SongDatabase.Artists.Add(new Artist(artist));

            }
            catch (NullValueError)
            {
                throw;
            }
            catch (SaveError)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, $"Error importing artist '{ar.Name}'");
                throw new SpotifyImportError();
            }
        }



    }
}
