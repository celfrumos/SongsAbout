using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

    [Serializable]
    public abstract class SaDbEntityAccessor : ISaDbEntityAccessor
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    [Serializable]
    public abstract class SaEntity : SaDbEntityAccessor, ISaEntity
    {
        [NotMapped]
        public abstract SaEntityType EntityType { get; }
    }

    public abstract class SaSpotifyAccessEntity : SaEntity, ISpotifyAccessor
    {
        public string SpotifyId { get; set; }
        [NotMapped]
        [Display(Name = "Spotify Details Web Page")]
        public string SpotifyWebPage
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {this.GetType().Name} '{this.Name}'");

                return $"{Constants.SPOTIFY_WEB_PAGE_BASE}/{this.GetType().Name.ToLower()}/{this.SpotifyId}";

            }
        }


        [NotMapped]
        [Display(Name = "Spotify URI")]
        public string SpotifyUri
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {this.GetType().Name} '{this.Name}'");

                return $"spotify:{this.GetType().Name.ToLower()}:{this.SpotifyId}";
            }
        }

        [NotMapped]
        [Display(Name = "Spotify API Link")]
        public string ApiHref
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {this.GetType().Name} '{this.Name}'");

                return $"{Constants.SPOTIFY_API_BASE}/{this.GetType().Name.ToLower()}s/{this.SpotifyId}";
            }
        }

    }
    public abstract class SaDescriptor : SaEntity, ISaDescriptor
    {
        public virtual bool Describes(ISaIntegralEntity entity)
        {
            return entity.DescribedBy(this.Name);
        }
        public List<Artist> Artists { get; set; }
        public List<Album> Albums { get; set; }
        public List<Track> Tracks { get; set; }
    }

    public abstract class SaIntegralEntity : SaSpotifyAccessEntity, ISaIntegralEntity
    {
        [Display(GroupName = "Descriptors")]
        public List<Genre> Genres { get; set; }

        [Display(GroupName = "Descriptors")]
        public List<Topic> Topics { get; set; }

        [Display(Name = "Album Keywords", GroupName = "Descriptors")]
        public List<Keyword> Keywords { get; set; }

        /// <summary>
        /// Signifies whether or not any of the descriptors of this <see cref="SaIntegralEntity"/> contain the designated <paramref name="term"/>
        /// </summary>
        /// <param name="term">The term to search for</param>
        /// <returns></returns>
        public virtual bool DescribedBy(string term)
        {
            return
                  this.Genres.Any(g => g.Name.ToLower().Contains(term.ToLower()))
                  || this.Topics.Any(g => g.Name.ToLower().Contains(term.ToLower()))
                  || this.Keywords.Any(g => g.Name.ToLower().Contains(term.ToLower()));
        }
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
            var necessaryAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(new { src = img.Src, alt = img.Name });
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