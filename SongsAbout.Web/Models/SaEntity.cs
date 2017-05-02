﻿using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace SongsAbout.Web.Models
{
    public static class Constants
    {
        public const string SPOTIFY_API_BASE = @"https://api.spotify.com/v1";
        public const string SPOTIFY_WEB_PAGE_BASE = @"https://open.spotify.com";

    }

    public enum EntityDisplayType
    {
        Spotlight,
        SearchResult,
        List,
        Related
    }

    public static class HtmlButtonExtension
    {
        public static MvcHtmlString Button(this HtmlHelper helper, string innerHtml, object htmlAttributes)
        {
            return Button(helper, innerHtml, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string innerHtml, IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button");
            builder.InnerHtml = innerHtml;
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString DisplayImage(this HtmlHelper helper, ISaImage img, bool explicitSize, object htmlAttributes = null, params string[] classes)
        {
            var builder = new TagBuilder("img");
            var necessaryAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(new { src = img.Src, alt = img.AltText });
            builder.MergeAttributes(necessaryAttributes);
            foreach (var c in classes)
                builder.AddCssClass(c);

            if (htmlAttributes != null)
                builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            if (explicitSize)
                builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(new { width = img.Width, height = img.Height }));


            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
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
                    .Append(track.Name)
                .Append("</td>")
                .Append("<td>")
                    .Append(track.Artist.Name)
                .Append("</td>")
                .Append("<td>")
                    .Append("")
                .Append("</td>")
                .Append("<td>")
                    .Append(track.LengthMinutes)
                .Append("</td>")
                .Append("<td>")
                    .Append(helper.RenderRawLink(track.SpotifyWebPage, "View in Spotify", new { @class = "spotify-href" }))
                .Append("</td>")
            .Append("</tr");

            return MvcHtmlString.Create(builder.ToString());
        }
        public static MvcHtmlString DisplaySearchResult<T>(this HtmlHelper helper, T entity, object htmlAttributes = null) where T : ISaEntity
        {
            var name = new TagBuilder("div");
            var img = new TagBuilder("div");

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

            return MvcHtmlString.Create($"<div id=\"{itemId}\" class=\"search-item {colClass} {itemClass}\">{list_items}</div>");
        }


        public static void LoadAllRelated<T>(ref T entity, EntityDbContext db) where T : class, ISaIntegralEntity
        {
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

                ar.Tracks.ForEach(t => db.Tracks?.Attach(t));
                if (ar.Tracks.Count > 0)

                    artist.Collection(a => a.Tracks).Load();

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
                album.Collection(a => a.FeaturedArtists).Load();
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