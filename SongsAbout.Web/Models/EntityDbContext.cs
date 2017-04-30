using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{

    public class EntityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }

        public DbSet<ProfilePic> ProfilePics { get; set; }
        public DbSet<AlbumCover> AlbumCovers { get; set; }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Keyword> Keywords { get; set; }

        public T GetEntity<T>(string name) where T : ISaEntity
        {
            var t = typeof(T);
            var interfaceMap = t.GetInterfaceMap(typeof(ISaEntity));

            var obj = (ISaEntity)t.GetConstructor(new Type[] { }).Invoke(new object[] { });

            switch (obj.EntityType)
            {
                case SaEntityType.Artist:
                    obj = (from a in this.Artists
                           where a.Name == name
                           select (ISaEntity)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Album:
                    obj = (from a in this.Albums
                           where a.Name == name
                           select (ISaEntity)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Track:
                    obj = (from a in this.Tracks
                           where a.Name == name
                           select (ISaEntity)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Topic:
                    obj = (from a in this.Topics
                           where a.Name == name
                           select (ISaEntity)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Genre:
                    obj = (from a in this.Genres
                           where a.Name == name
                           select (ISaEntity)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Keyword:
                    obj = (from a in this.Keywords
                           where a.Name == name
                           select (ISaEntity)a)?.FirstOrDefault();
                    break;
                default:
                    obj = null;
                    break;
            }

            return (T)obj;
        }
        public T GetDescriptor<T>(string text) where T : ISaDescription
        {
            var t = typeof(T);
            var interfaceMap = t.GetInterfaceMap(typeof(ISaEntity));

            var obj = (ISaDescription)t.GetConstructor(new Type[] { }).Invoke(new object[] { });

            switch (obj.EntityType)
            {
                case SaEntityType.Topic:
                    obj = (from a in this.Topics
                           where a.Text == text
                           select (ISaDescription)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Genre:
                    obj = (from a in this.Genres
                           where a.Text == text
                           select (ISaDescription)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Keyword:
                    obj = (from a in this.Keywords
                           where a.Text == text
                           select (ISaDescription)a)?.FirstOrDefault();
                    break;
                default:
                    obj = null;
                    break;
            }

            return (T)obj;
        }
        public T GetEntity<T>(T prototype, string name) where T : ISaEntity
        {
            var obj = prototype as ISaEntity;

            switch (obj.EntityType)
            {
                case SaEntityType.Artist:
                    obj = (from a in this.Artists
                           where a.Name == name
                           select (ISaEntity)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Album:
                    obj = (from a in this.Albums
                           where a.Name == name
                           select (ISaEntity)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Track:
                    obj = (from a in this.Tracks
                           where a.Name == name
                           select (ISaEntity)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Topic:
                    obj = (from a in this.Topics
                           where a.Name == name
                           select (ISaEntity)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Genre:
                    obj = (from a in this.Genres
                           where a.Name == name
                           select (ISaEntity)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Keyword:
                    obj = (from a in this.Keywords
                           where a.Name == name
                           select (ISaEntity)a)?.FirstOrDefault();
                    break;
                default:
                    obj = null;
                    break;
            }

            return (T)obj;
        }
        public T GetDescriptor<T>(T prototype, string text) where T : ISaDescription
        {

            var obj = prototype as ISaDescription;

            switch (obj.EntityType)
            {
                case SaEntityType.Topic:
                    obj = (from a in this.Topics
                           where a.Text == text
                           select (ISaDescription)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Genre:
                    obj = (from a in this.Genres
                           where a.Text == text
                           select (ISaDescription)a)?.FirstOrDefault();
                    break;
                case SaEntityType.Keyword:
                    obj = (from a in this.Keywords
                           where a.Text == text
                           select (ISaDescription)a)?.FirstOrDefault();
                    break;
                default:
                    obj = null;
                    break;
            }

            return (T)obj;
        }

        public bool IsDescribedBy(ISaIntegralEntity entity, string q)
        {
            return entity.Genres.Any(g => g.Text.ToLower().Contains(q.ToLower()))
                   || entity.Topics.Any(g => g.Text.ToLower().Contains(q.ToLower()))
                   || entity.Keywords.Any(g => g.Text.ToLower().Contains(q.ToLower()));
        }

        public SearchResult Search(string q, SaEntityType type, int limit = 5)
        {
            SearchResult results = new SearchResult();
            if (!string.IsNullOrWhiteSpace(q))
            {
                if ((type & SaEntityType.Artist) == SaEntityType.Artist || type == SaEntityType.Any)
                {
                    var artists =
                        this.Artists
                                .Include(a => a.ProfilePic)
                                .Include(a => a.Tracks)
                                .Include(a => a.Albums)
                                .Include(a => a.Topics)
                                .Include(a => a.Keywords).ToList();

                    var found = artists?
                        .Where(a => a.Name.ToLower()
                        .Contains(q.ToLower()) || IsDescribedBy(a, q))
                        ?.Take(limit);

                    results.Items.AddRange(found);
                    results.Artists = found?.ToList();
                }
                if ((type & SaEntityType.Album) == SaEntityType.Album || type == SaEntityType.Any)
                {
                    var albums =
                                this.Albums
                                .Include(a => a.AlbumCover)?
                                .Include(a => a.Tracks)?
                                .Include(a => a.Artist)?
                                .Include(a => a.FeaturedArtists)?
                                .Include(a => a.Topics)?
                                .Include(a => a.Keywords)?.ToList();

                    var found = albums?
                        .Where(a => a.Name.ToLower()
                        .Contains(q.ToLower()) || IsDescribedBy(a, q))
                        ?.Take(limit);

                    results.Items.AddRange(found);
                    results.Albums = found?.ToList();

                }
                if ((type & SaEntityType.Track) == SaEntityType.Track || type == SaEntityType.Any)
                {
                    var tracks =
                                 this.Tracks
                                .Include(a => a.Album)
                                .Include(a => a.Artist)
                                .Include(a => a.FeaturedArtists)
                                .Include(a => a.Topics)
                                .Include(a => a.Keywords)?.ToList();

                    var found = tracks?
                        .Where(t =>
                        t.Name.ToLower().Contains(q.ToLower()) || IsDescribedBy(t, q))
                        ?.Take(limit);

                    results.Items.AddRange(found);
                    results.Tracks = found?.ToList();
                }
                if ((type & SaEntityType.Topic) == SaEntityType.Topic || type == SaEntityType.Any)
                {
                    var topics = (from a in this.Topics
                                  where a.Text.ToLower()
                                        .Contains(q.ToLower())
                                  select a)?.Take(limit);

                    results.Items.AddRange(topics);
                    results.Topics = topics?.ToList();


                }
                if ((type & SaEntityType.Genre) == SaEntityType.Genre || type == SaEntityType.Any)
                {
                    var genres = (from a in this.Genres
                                  where a.Text.ToLower()
                                        .Contains(q.ToLower())
                                  select a)?.Take(limit);

                    results.Items.AddRange(genres);
                    results.Genres = genres?.ToList();

                }
                if ((type & SaEntityType.Keyword) == SaEntityType.Keyword || type == SaEntityType.Any)
                {
                    var keywords = (from a in this.Keywords
                                    where a.Text.ToLower()
                                          .Contains(q.ToLower())
                                    select a).Take(limit);
                    results.Items.AddRange(keywords);
                    results.Keywords = keywords.ToList();
                }
            }
            return results;
        }

        public EntityDbContext() : base("DatabaseFile", throwIfV1Schema: false)
        {
            
        }

        public static EntityDbContext Create()
        {
            return new EntityDbContext();
        }
    }
}