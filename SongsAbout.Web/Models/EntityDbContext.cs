using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Collections;

namespace SongsAbout.Web.Models
{

    public class EntityDbContext : IdentityDbContext<ApplicationUser>
    {
        public EntityDbSet<Artist> Artists { get; set; }
        public EntityDbSet<Album> Albums { get; set; }
        public EntityDbSet<Track> Tracks { get; set; }

        public EntityDbSet<ProfilePic> ProfilePics { get; set; }
        public EntityDbSet<AlbumCover> AlbumCovers { get; set; }

        public EntityDbSet<Topic> Topics { get; set; }
        public EntityDbSet<Genre> Genres { get; set; }
        public EntityDbSet<Keyword> Keywords { get; set; }



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
                        this.Artists?
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
                }
                if ((type & SaEntityType.Album) == SaEntityType.Album || type == SaEntityType.Any)
                {
                    var albums =
                                this.Albums?
                                .Include(a => a.AlbumCover)
                                .Include(a => a.Tracks)
                                .Include(a => a.Artist)
                                .Include(a => a.FeaturedArtists)
                                .Include(a => a.Topics)
                                .Include(a => a.Keywords)
                                ?.ToList();

                    var found = albums?
                        .Where(a => a.Name.ToLower()
                        .Contains(q.ToLower()) || IsDescribedBy(a, q))
                        ?.Take(limit);

                    results.Items.AddRange(found);

                }
                if ((type & SaEntityType.Track) == SaEntityType.Track || type == SaEntityType.Any)
                {
                    var tracks =
                                 this.Tracks?
                                .Include(a => a.Album)
                                .Include(a => a.Artist)
                                .Include(a => a.FeaturedArtists)
                                .Include(a => a.Topics)
                                .Include(a => a.Keywords)
                                ?.ToList();

                    var found = tracks?
                        .Where(t =>
                        t.Name.ToLower().Contains(q.ToLower()) || IsDescribedBy(t, q))
                        ?.Take(limit);

                    results.Items.AddRange(found);
                }
                if ((type & SaEntityType.Topic) == SaEntityType.Topic || type == SaEntityType.Any)
                {
                    var topics = (from a in this.Topics
                                  where a.Text.ToLower()
                                        .Contains(q.ToLower())
                                  select a)?.Take(limit);

                    results.Items.AddRange(topics);


                }
                if ((type & SaEntityType.Genre) == SaEntityType.Genre || type == SaEntityType.Any)
                {
                    var genres = (from a in this.Genres
                                  where a.Text.ToLower()
                                        .Contains(q.ToLower())
                                  select a)?.Take(limit);

                    results.Items.AddRange(genres);

                }
                if ((type & SaEntityType.Keyword) == SaEntityType.Keyword || type == SaEntityType.Any)
                {
                    var keywords = (from a in this.Keywords
                                    where a.Text.ToLower()
                                          .Contains(q.ToLower())
                                    select a).Take(limit);
                    results.Items.AddRange(keywords);
                }
            }
            return results;
        }
        public SearchResult Search(SearchQuery q)
        {
            return Search(q.query, q.type, q.limit);
        }
        public EntityDbContext() : base("DatabaseFile", throwIfV1Schema: false)
        {
            Artists = new EntityDbSet<Artist>(this);
            Albums = new EntityDbSet<Album>(this);
            Tracks = new EntityDbSet<Track>(this);
            ProfilePics = new EntityDbSet<ProfilePic>(this);
            AlbumCovers = new EntityDbSet<AlbumCover>(this);
            Topics = new EntityDbSet<Topic>(this);
            Genres = new EntityDbSet<Genre>(this);
            Keywords = new EntityDbSet<Keyword>(this);
        }

        public static EntityDbContext Create()
        {
            return new EntityDbContext();
        }
    }

    public class EntityDbSet<T> : DbSet<T>, IEnumerable<T>, IEnumerable 
        where T : class, ISaDbEntityAccessor
    {
        public EntityDbContext db { get; }
        public EntityDbSet(EntityDbContext context) : base()
        {
            db = context;
        }

        public T Get(T entity)
        {
            var res = from a in db.Set<T>()
                      where a.Name == entity.Name
                      select a;

            return res.FirstOrDefault();
        }
        public override T Add(T entity)
        {
            base.Add(entity);
            db.SaveChanges();

            var res = Get(entity);

            return res;
        }

    }
}