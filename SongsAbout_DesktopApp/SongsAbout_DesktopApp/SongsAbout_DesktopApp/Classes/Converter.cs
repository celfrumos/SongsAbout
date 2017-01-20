using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SongsAbout.Properties;
using SpotifyAPI.Web;
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
        public static SpotifyFullAlbum GetFullAlbum(SpotifyAlbum album)
        {
            try
            {
                return UserSpotify.WebAPI.GetAlbum(album.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(SpotifyEntityType.BaseAlbum, SpotifyEntityType.FullAlbum, ex.Message);
            }
        }
        public static SpotifyFullAlbum GetFullAlbum(SavedAlbum album)
        {
            try
            {
                return UserSpotify.WebAPI.GetAlbum(album.Album.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(SpotifyEntityType.BaseAlbum, SpotifyEntityType.FullAlbum, ex.Message);
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
                byte[] array;
              //const string tempPath = "tempImagefile.bmp";
                //var i = Image.FromFile(tempPath);
                var img = new Bitmap(image);
                
                using (var stream = new MemoryStream())
                {               
                    img.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    array = stream.ToArray();
                }
                return array;

            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                var f = ex.HelpLink;
                Console.WriteLine(ex.Message);
                return null;

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
        public static SpotifyFullArtist GetFullArtist(SpotifyArtist artist)
        {
            try
            {
                return UserSpotify.WebAPI.GetArtist(artist.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(SpotifyEntityType.BaseArtist, SpotifyEntityType.FullArtist, ex.Message);
            }

        }


        public static SpotifyFullTrack GetFullTrack(SpotifyTrack track)
        {
            try
            {
                return UserSpotify.WebAPI.GetTrack(track.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(SpotifyEntityType.BaseTrack, SpotifyEntityType.FullTrack, ex.Message);
            }
        }
        public static SpotifyFullTrack GetFullTrack(SavedTrack track)
        {
            try
            {
                return UserSpotify.WebAPI.GetTrack(track.Track.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(SpotifyEntityType.BaseTrack, SpotifyEntityType.FullTrack, ex.Message);
            }
        }

        public static SpotifyFullPlaylist GetFullPlaylist(SpotifyPlaylist playlist)
        {
            try
            {
                return UserSpotify.WebAPI.GetPlaylist(User.Default.PrivateId, playlist.Id);
            }
            catch (Exception ex)
            {
                throw new SpotifyConversionError(SpotifyEntityType.BaseTrack, SpotifyEntityType.FullTrack, ex.Message);
            }

        }

       
    }
}
