using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SpotifyAPI.Web.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SongsAbout.Web.Models
{
    public abstract class Picture
    {
        [Display(Name = "alt")]
        public virtual string AltText { get; set; }
        [Display(Name = "src")]
        public virtual string Url { get; set; }
        [Display(Name = "width")]
        public virtual int Width { get; set; }
        [Display(Name = "height")]
        public virtual int Height { get; set; }

    }
    public class ProfilePic : Picture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfilePicId { get; set; }

        public static implicit operator ProfilePic(SpotifyImage image)
        {
            return new ProfilePic { Url = image.Url, Width = image.Width, Height = image.Height };
        }
    }
    public class AlbumCover : Picture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumCoverId { get; set; }

        public static implicit operator AlbumCover(SpotifyImage image)
        {
            return new AlbumCover { Url = image.Url, Width = image.Width, Height = image.Height };
        }
    }
}