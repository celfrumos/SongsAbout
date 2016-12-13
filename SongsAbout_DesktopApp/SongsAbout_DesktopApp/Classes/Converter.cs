using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
                throw new SpotifyConversionError(SpotifyEntityType.SimpleAlbum, SpotifyEntityType.FullAlbum, ex.Message);
            }
        }

        /// <summary>
        /// Convert an image to a byte Array
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        /// <exception cref="ConversionError"></exception>
        public static System.Drawing.Image ImageFromBytes(byte[] imageBytes)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(imageBytes))
                {
                    return System.Drawing.Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                throw new ConversionError(typeof(byte[]).FullName, typeof(Image).FullName, ex.Message);
            }
        }
        /// <summary>
        /// Convert an image to a byte Array
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        /// <exception cref="ConversionError"></exception>
        public static byte[] ImageToBytes(System.Drawing.Image image)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                return stream.ToArray();
            }
            catch (Exception ex)
            {
                throw new ConversionError("System.Drawing.Image", "byte[]", ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        /// <exception cref="SpotifyConversionError"></exception>
        public static FullArtist GetFullArtist(SimpleArtist artist)
        {
            try
            {
                return UserSpotify.WebAPI.GetArtist(artist.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(SpotifyEntityType.SimpleArtist, SpotifyEntityType.FullArtist, ex.Message);
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
                throw new SpotifyConversionError(SpotifyEntityType.SimpleTrack, SpotifyEntityType.FullTrack, ex.Message);
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
                throw new SpotifyConversionError(SpotifyEntityType.SimpleTrack, SpotifyEntityType.FullTrack, ex.Message);
            }
        }

        public static FullPlaylist GetFullPlaylist(SimplePlaylist playlist)
        {
            try
            {
                return UserSpotify.WebAPI.GetPlaylist(User.Default.PrivateId, playlist.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(SpotifyEntityType.SimpleTrack, SpotifyEntityType.FullTrack, ex.Message);
            }

        }

    }
}
