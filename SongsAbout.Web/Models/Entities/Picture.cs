using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SpotifyAPI.Web.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SongsAbout.Web.Models
{
    public interface ISaImage : ISaDbEntityAccessor
    {
        string Src { get; set; }
        int Width { get; set; }
        int Height { get; set; }

    }
    public class Picture : SaDbEntityAccessor, ISaImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [NotMapped]
        [Display(Name = "alt")]
        [DefaultValue("")]
        public override string Name { get; set; }

        [Url]
        [Display(Name = "src")]
        [DefaultValue("")]
        [Required(ErrorMessage = "Picture must have a source")]
        public virtual string Src { get; set; }

        [Display(Name = "width")]
        [DefaultValue(0)]
        public virtual int Width { get; set; }

        [Display(Name = "height")]
        [DefaultValue(0)]
        public virtual int Height { get; set; }

        public Picture()
        {
            this.Name = "";
            this.Src = "";
            this.Width = 0;
            this.Height = 0;
        }
        public Picture(SpotifyImage image, string name)
        {
            this.Name = name;
            this.Src = image.Url;
            this.Width = image.Width;
            this.Height = image.Height;
        }
        public static implicit operator Picture(SpotifyImage image)
        {
            return new Picture(image, "");
        }
    }

}