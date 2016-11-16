using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsAbout.Properties;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SongsAbout.Entities;
using Track = SongsAbout.Entities.Track;
using Image = System.Drawing.Image;

namespace SongsAbout.Classes
{
    public static class Converter
    {
        public static FullAlbum GetFullAlbum(SimpleAlbum album)
        {
            try
            {
                return UserSpotify.WebAPI.GetAlbum(album.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(typeof(SimpleAlbum), typeof(FullAlbum), ex.Message);
            }
        }

        public static FullArtist GetFullArtist(SimpleArtist artist)
        {
            try
            {
                return UserSpotify.WebAPI.GetArtist(artist.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(typeof(SimpleArtist), typeof(FullArtist), ex.Message);
            }

        }

        public static FullTrack GetFullTrack(SimpleTrack track)
        {
            try
            {
                return UserSpotify.WebAPI.GetTrack(track.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(typeof(SimpleTrack), typeof(FullTrack), ex.Message);
            }
        }
        public static FullTrack GetFullTrack(SavedTrack track)
        {
            try
            {                
                return UserSpotify.WebAPI.GetTrack(track.Track.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(typeof(SimpleTrack), typeof(FullTrack), ex.Message);
            }
        }

        public static FullPlaylist GetFullPlaylist(SimplePlaylist playlist)
        {
            try
            {
                return UserSpotify.WebAPI.GetPlaylist(User.Default.UserId, playlist.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(typeof(SimpleTrack), typeof(FullTrack), ex.Message);
            }

        }

    }
}
