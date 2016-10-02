using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SongsAbout_DesktopApp.Properties;
using SpotifyAPI.Web.Models;

namespace SongsAbout_DesktopApp.Classes
{
    public static class Importer
    {

        public static void ImportArtistsFromSpotify()
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
                    MessageBox.Show(ex.Message, "Error importing Playlist: " + playlist.Name);
                }
            }
            MessageBox.Show("Finished importing artists from Playlists.");
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
            Track track = new Track();
            track.Update(t);
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
            catch (Exception)
            {
                throw;
            }
        }
        public static void ImportPlaylistTrackArtists(PlaylistTrack pt)
        {
            foreach (SimpleArtist ar in pt.Track.Artists)
            {
                ImportArtist(ar);
            }
        }

        public static void ImportArtist(SimpleArtist ar)
        {
            try
            {
                FullArtist artist = User.Default.SpotifyWebAPI.GetArtist(ar.Id);
                Artist a = new Artist();
                if (!a.Exists(artist.Name))
                {
                    a.Update(artist);
                    a.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error importing artist: " + ar.Name);
            }
        }

        private static void ImportSavedAlbums()
        {
            User.Default.SpotifyWebAPI.GetSavedAlbums();
        }

    }
}
