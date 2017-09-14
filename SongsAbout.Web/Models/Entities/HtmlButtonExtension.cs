using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace SongsAbout.Web.Models
{
    public static class HtmlButtonExtension
    {
        public static MvcHtmlString Button(this HtmlHelper helper, string innerHtml, object htmlAttributes)
        {
            return Button(helper, innerHtml, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string innerHtml, string controllerName, string actionName, object routeValues, object htmlAttributes)
        {

            return Button(helper, innerHtml, controllerName, actionName, HtmlHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string innerHtml, string controllerName, string actionName, IDictionary<string, object> routeValues, IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button")
            {
                InnerHtml = innerHtml
            };

            builder.MergeAttributes(htmlAttributes);
            builder.MergeAttribute("href", RenderUrl(helper, controllerName, actionName, routeValues).ToString());
            return MvcHtmlString.Create(builder.ToString());
        }


        public static MvcHtmlString Button(this HtmlHelper helper, string innerHtml, IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button");
            builder.InnerHtml = innerHtml;
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString RenderUrl(this HtmlHelper helper, string controllerName, string actionName, object routeValues)
        {
            return RenderUrl(helper, controllerName, actionName, HtmlHelper.ObjectToDictionary(routeValues));
        }
        public static MvcHtmlString RenderUrl(this HtmlHelper helper, string controllerName, string actionName, IDictionary<string, object> routeValues)
        {
            StringBuilder str = new StringBuilder($@"{controllerName}/{actionName}");
            if (routeValues?.Count > 0)
            {
                int i = 0;

                foreach (var item in routeValues)
                {
                    if (i++ == 0)
                        str.Append("?");
                    else
                        str.Append("&");

                    str.Append($@"{item.Key}={item.Value}");

                }
            }
            return MvcHtmlString.Create(str.ToString());

        }
        public static MvcHtmlString RenderRawLink(this HtmlHelper helper, string url, string text, object htmlAttributes = null)
        {
            var a = new TagBuilder("a");

            a.MergeAttribute("href", url);
            a.SetInnerText(text);
            if (htmlAttributes != null)
            {
                a.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            }

            return MvcHtmlString.Create(a.ToString());
        }


        public static MvcHtmlString DisplayTrackRow(this HtmlHelper helper, Track track)
        {
            if (track == null)
                return null;

            StringBuilder builder = new StringBuilder();

            LoadAllRelated(ref track, new EntityDbContext());

            builder.Append("<tr class=\"trackrow\">")
                .Append("<td>")
                    .Append(track?.Name)
                .Append("</td>")
                .Append("<td>")
                    .Append(track.Artist?.Name)
                .Append("</td>")
                .Append("<td>")
                    .Append("")
                .Append("</td>")
                .Append("<td>")
                    .Append(track?.LengthMinutes)
                .Append("</td>")
                .Append("<td>")
                    .Append(helper.RenderRawLink(track?.SpotifyWebPage, "View in Spotify", new { @class = "spotify-href" }))
                .Append("</td>")
            .Append("</tr");

            return MvcHtmlString.Create(builder.ToString());
        }
        public static MvcHtmlString DisplaySearchResult<T>(this HtmlHelper helper, T entity, object htmlAttributes = null) where T : ISaEntity
        {
            var name = new TagBuilder("div");
            var img = new TagBuilder("div");
            var link = new TagBuilder("a");



            MvcHtmlString imgHtml = null;

            string
                itemClass = "",
                itemId = "";

            switch (entity.EntityType)
            {
                case SaEntityType.Artist:
                    var artist = entity as Artist;
                    itemClass = "artist";
                    imgHtml = helper.DisplayImage(artist.ProfilePic, false, null, itemClass, "img-mid");

                    break;
                case SaEntityType.Album:

                    var album = entity as Album;
                    itemClass = "album";
                    imgHtml = helper.DisplayImage(album.AlbumCover, false, null, itemClass, "img-mid");

                    break;
                case SaEntityType.Track:
                    var track = entity as Track;
                    itemClass = "track";

                    break;
                case SaEntityType.Topic:
                    break;
                case SaEntityType.Genre:
                    break;
                case SaEntityType.Keyword:
                    break;
            }

            name.AddCssClass("search-name");
            name.SetInnerText(entity.Name);

            img.AddCssClass("search-image-container");
            img.InnerHtml = imgHtml?.ToHtmlString();

            itemId = $"{itemClass}-{entity.Id}";

            var colClass = "col-md-4";

            var list_items = img?.ToString() + name.ToString();


            return MvcHtmlString.Create($"<div id=\"{itemId}\" class=\"search-item {colClass} {itemClass}\"><a href=\"{itemClass}s/Details/{entity.Id}\">{list_items}</a></div>");
        }


        public static void LoadAllRelated<T>(ref T entity, EntityDbContext db) where T : class, ISaIntegralEntity
        {
            return;
            var dbEntry = db.Entry<T>(entity);

            var keywords = dbEntry.Collection(a => a.Keywords);
            var genres = dbEntry.Collection(a => a.Genres);
            var topics = dbEntry.Collection(a => a.Topics);
            var set = db.Set<T>();
            if (keywords.CurrentValue?.Count > 0)
            {
                entity.Keywords.ForEach(k => db.Keywords.Attach(k));
                keywords.Load();
            }
            if (genres.CurrentValue?.Count > 0)
            {
                entity.Genres.ForEach(g => db.Genres.Attach(g));
                genres.Load();
            }
            if (topics.CurrentValue?.Count > 0)
            {
                entity.Topics.ForEach(t => db.Topics.Attach(t));
                topics.Load();
            }

            var type = entity.EntityType;
            if (type == SaEntityType.Artist)
            {
                var ar = entity as Artist;

                var artist = db.Entry(ar);

                artist.Reference(a => a.ProfilePic);

                ar.Albums.ForEach(al => db.Albums.Attach(al));
                if (ar.Albums.Count > 0)
                    artist.Collection(a => a.Albums).Load();

                //ar.Tracks.ForEach(t => db.Tracks?.Attach(t));
                //if (ar.Tracks.Count > 0)

                //    artist.Collection(a => a.Tracks).Load();

            }
            else if (type == SaEntityType.Album)
            {
                var al = entity as Album;
                var album = db.Entry(al);

                album.Reference(a => a.AlbumCover).Load();
                album.Reference(a => a.Artist).Load();

                al.Tracks.ForEach(t => db.Tracks?.Attach(t));
                if (al.Tracks.Count > 0)
                    album.Collection(a => a.Tracks).Load();
                album.Collection(a => a.Artists).Load();
            }
            else if (type == SaEntityType.Track)
            {
                var tr = entity as Track;
                var track = db.Entry(tr);

                // track.Collection(t => t.FeaturedArtists).Load();
                track.Reference(t => t.Artist).Load();
                track.Reference(t => t.Album).Load();

            }
        }
    }
}