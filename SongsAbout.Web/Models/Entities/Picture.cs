using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SpotifyAPI.Web.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web.Mvc;

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
    public static class PictureHtmlDisplayExtension
    {
        public static MvcHtmlString DisplayImage(this HtmlHelper helper, Picture img, bool explicitSize = true, object htmlAttributes = null, params string[] classes)
        {
            var builder = new TagBuilder("img");
            var necessaryAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(new { src = img.Src, alt = img.Name });

            builder.MergeAttributes(necessaryAttributes);

            foreach (var c in classes)
                builder.AddCssClass(c);

            if (explicitSize)
                builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(new { width = img.Width, height = img.Height }));

            if (htmlAttributes != null)
                builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));



            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }

}