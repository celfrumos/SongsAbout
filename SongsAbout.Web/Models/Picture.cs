using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SpotifyAPI.Web.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SongsAbout.Web.Models
{
    public interface ISaImage : ISaDbEntityAccessor
    {
        string AltText { get; set; }
        string Src { get; set; }
        int Width { get; set; }
        int Height { get; set; }

    }
    public class ProfilePic : ISaImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfilePicId { get; set; }

        public static implicit operator ProfilePic(SpotifyImage image)
        {
            return new ProfilePic { Src = image.Url, Width = image.Width, Height = image.Height };
        }
        [Display(Name = "alt")]
        public virtual string AltText { get; set; }

        [NotMapped]
        public string Name { get { return AltText; } set { AltText = value; } }
        [NotMapped]
        public int Id { get { return ProfilePicId; } set { ProfilePicId = value; } }
        [Url]
        [Display(Name = "src")]
        public virtual string Src { get; set; }
        [Display(Name = "width")]
        public virtual int Width { get; set; }
        [Display(Name = "height")]
        public virtual int Height { get; set; }
    }


    public class AlbumCover : ISaImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumCoverId { get; set; }

        public static implicit operator AlbumCover(SpotifyImage image)
        {
            return new AlbumCover { Src = image.Url, Width = image.Width, Height = image.Height };
        }
        [Display(Name = "alt")]
        public virtual string AltText { get; set; }

        [NotMapped]
        public string Name { get { return AltText; } set { AltText = value; } }
        [NotMapped]
        public int Id { get { return AlbumCoverId; } set { AlbumCoverId = value; } }

        [Url]
        [Display(Name = "src")]
        public virtual string Src { get; set; }
        [Display(Name = "width")]
        public virtual int Width { get; set; }
        [Display(Name = "height")]
        public virtual int Height { get; set; }
    }
}