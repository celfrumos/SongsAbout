using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SongsAbout_DesktopApp.Properties;
using SpotifyAPI.Web.Models;

namespace SongsAbout_DesktopApp.Classes
{
    public static class Importer
    {

        public static void ImportSavedPlaylists()
        {
            List<SimplePlaylist> userPlaylists = UserSpotify.GetPlaylists();
            foreach (SimplePlaylist playlist in userPlaylists)
            {
                try
                {
                    Paging<PlaylistTrack> playlistTracks = User.Default.SpotifyWebAPI.GetPlaylistTracks(User.Default.UserId, playlist.Id);
                    ImportPlaylistTracks(playlistTracks);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error importing Playlist: " + playlist.Name + ", " + ex.Message);
                    //throw new Exception(ex.Message);
                }
            }
            Console.WriteLine("Finished importing artists from Playlists.");
        }

        public static void ImportPlaylistTracks(Paging<PlaylistTrack> playlistTracks)
        {
            foreach (PlaylistTrack pt in playlistTracks.Items)
            {
                ImportTrack(pt.Track);
                ImportAlbum(pt.Track.Album);
                ImportPlaylistTrackArtists(pt);
            }
        }

        public static void ImportTrack(FullTrack t)
        {
            try
            {
                Track track = new Track();
                track.Update(t);
                track.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw new Exception(ex.Message);
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
            catch (Exception)
            {
                throw;
            }
        }

        public static void ImportAlbum(FullAlbum album)
        {
            try
            {
                Album a = new Album();
                a.Update(album);
                a.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public static void ImportPlaylistTrackArtists(PlaylistTrack pt)
        {
            foreach (SimpleArtist ar in pt.Track.Artists)
            {
                try
                {

                    ImportArtist(ar);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }

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
                Console.WriteLine(ex.Message, "Error importing artist: " + ar.Name);
            }
        }

        //public static void ImportSavedAlbums()
        //{
        //    User.Default.SpotifyWebAPI.GetSavedAlbums();
        //}

    }
}
