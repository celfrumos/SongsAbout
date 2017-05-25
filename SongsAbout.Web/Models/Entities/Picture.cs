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
        SaEntityType SaEntityType { get; set; }
    }
    public class Picture : SaDbEntityAccessor, ISaImage
    {
        [Key]
        public override int Id { get; set; }

        [Display(Name = "alt")]
        [DefaultValue("")]
        public override string Name { get; set; }

        [Display(Name = "src")]
        [DefaultValue("")]
        [Required(ErrorMessage = "Picture must have a source", AllowEmptyStrings = true)]
        public virtual string Src { get; set; }

        [Display(Name = "width")]
        [DefaultValue(0)]
        public virtual int Width { get; set; }

        [Display(Name = "height")]
        [DefaultValue(0)]
        public virtual int Height { get; set; }

        [EnumDataType(typeof(SaEntityType), ErrorMessage = "An error occurred with setting the SaEntityType of the picture")]
        public SaEntityType SaEntityType { get; set; }

        public Picture()
        {
            this.Name = "";
            this.Src = "";
            this.Width = 0;
            this.Height = 0;
            this.SaEntityType = SaEntityType.Any;
        }
        public Picture(SpotifyImage image, string name, SaEntityType entityType = SaEntityType.Any)
        {
            this.Name = name ?? "";
            this.Src = image?.Url ?? "";
            this.Width = image?.Width ?? 0;
            this.Height = image?.Height ?? 0;
            this.SaEntityType = entityType;
        }
        public static implicit operator Picture(SpotifyImage image)
        {
            return new Picture(image, "");
        }
    }

}