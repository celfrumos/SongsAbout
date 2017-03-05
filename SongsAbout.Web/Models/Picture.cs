using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SpotifyAPI.Web.Models;
namespace SongsAbout.Web.Models
{
    public class Picture
    {
        [Key]
        public int PictureId { get; set; }

        [Display(Name = "alt")]
        virtual public string AltText { get; set; }
        virtual public string Url { get; set; }
        virtual public int Width { get; set; }
        virtual public int Height { get; set; }

        public static implicit operator Picture(SpotifyImage image)
        {
            return new Picture { Url = image.Url, Width = image.Width, Height = image.Height };
        }
    }
    public class ProfilePic : Picture { }
    public class AlbumCover : Picture { }
}