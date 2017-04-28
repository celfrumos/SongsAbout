using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SongsAbout.Web.Models
{
    public static class Constants
    {
        public const string SPOTIFY_API_BASE = @"https://api.spotify.com/v1";
        public const string SPOTIFY_WEB_PAGE_BASE = @"https://open.spotify.com";

    }

}
namespace System.Web.Mvc
{
    using SongsAbout.Web.Models;
    public static class HtmlButtonExtension
    {

        public static MvcHtmlString Button(this HtmlHelper helper,
                                           string innerHtml,
                                           object htmlAttributes)
        {
            return Button(helper, innerHtml,
                          HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)
            );
        }

        public static MvcHtmlString Button(this HtmlHelper helper,
                                           string innerHtml,
                                           IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button");
            builder.InnerHtml = innerHtml;
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString DisplaySearchResult<T>(this HtmlHelper helper, T entity, bool includeChildren = false, object htmlAttributes = null) where T : ISaEntity
        {
            var img = new TagBuilder("img");
            var li_Name = new TagBuilder("li");
            var li_img = new TagBuilder("li");
            var ul = new TagBuilder("ul");

            switch (entity.EntityType)
            {
                case SaEntityType.Artist:
                    var artist = entity as Artist;
                    img.AddCssClass("artist");
                    img.AddCssClass("artist-image");
                    img.MergeAttribute("src", artist.ProfilePic?.Url);
                    img.MergeAttribute("alt", artist.ProfilePic?.AltText);

                    ul.AddCssClass("artist");
                    ul.GenerateId($"artist-{artist.ArtistId}");

                    break;
                case SaEntityType.Album:
                    break;
                case SaEntityType.Track:
                    break;
                case SaEntityType.Topic:
                    break;
                case SaEntityType.Genre:
                    break;
                case SaEntityType.Keyword:
                    break;
                case SaEntityType.Any:
                    break;
                default:
                    break;
            }
            img.AddCssClass("image-mid");

            li_Name.AddCssClass("search-name");
            li_Name.SetInnerText(entity.Name);

            li_img.AddCssClass("search-image-container");
            li_img.InnerHtml = img.ToString(TagRenderMode.SelfClosing);

            ul.AddCssClass("list-group-item");

            var list_items = li_Name.ToString() + li_img.ToString();
            ul.InnerHtml = list_items;

            return MvcHtmlString.Create(list_items);
        }

    }
}