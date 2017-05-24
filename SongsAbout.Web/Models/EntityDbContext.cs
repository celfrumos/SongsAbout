using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace SongsAbout.Web.Models
{

    public class EntityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Keyword> Keywords { get; set; }

        [NotMapped]
        public BTree<string, ISaEntity> SearchTree { get; set; }

        public T Get<T>(int id) where T : SaDbEntityAccessor
        {
            return this.Set<T>().Find(id);
        }

        public T Get<T>(string nameOrText) where T : SaDbEntityAccessor
        {
            var set = this.Set<T>();
            {
                /*   var type = typeof(T);

                   if (type == typeof(Picture))
                   {
                       var pics = this.Set<Picture>();

                       res = from p in pics
                             where p.Name == nameOrText
                             select p as T;

                   }
                   else
                   {

                       if (type == typeof(Keyword))
                       {

                           var keywords = this.Set<Keyword>();
                           res = from t in keywords
                                 where t.Text == nameOrText
                                 select t as T;
                       }
                       else if (type == typeof(Genre))
                       {
                           var genres = this.Set<Genre>();

                           res = from t in genres
                                 where t.Text == nameOrText
                                 select t as T;

                       }
                       else if (type == typeof(Topic))
                       {
                           var topics = this.Set<Topic>();

                           res = from t in topics
                                 where t.Text == nameOrText
                                 select t as T;

                       }
                       else if (type == typeof(Artist))
                       {
                           var artists = this.Set<Artist>();
                           var matches = from t in artists
                                         where t.Name == nameOrText
                                         select t;
                           res = from t in matches
                                 select t as T;

                       }
                       else if (type == typeof(Album))
                       {
                           var albums = this.Set<Album>();

                           res = from t in albums
                                 where t.Name == nameOrText
                                 select t as T;

                       }
                       else if (type == typeof(Track))
                       {
                           var tracks = this.Set<Track>();

                           res = from t in tracks
                                 where t.Name == nameOrText
                                 select t as T;
                       }
                       else
                       {
                           res = null;
                       }
                   }*/
            }

            return (from t in set
                    let e = t as SaDbEntityAccessor
                    where e.Name == nameOrText
                    select t)?.FirstOrDefault();
        }

        public bool IsDescribedBy(ISaIntegralEntity entity, string q)
        {
            return entity.Genres.Any(g => g.Name.ToLower().Contains(q.ToLower()))
                   || entity.Topics.Any(g => g.Text.ToLower().Contains(q.ToLower()))
                   || entity.Keywords.Any(g => g.Text.ToLower().Contains(q.ToLower()));
        }

        public async Task<Dictionary<Type, Dictionary<string, int>>> GetSearchDictionary(params Type[] types)
        {
            var tree = new Dictionary<Type, Dictionary<string, int>>();

            if (types.Any(t => t == typeof(Artist)))
            {
                tree[typeof(Artist)] = new Dictionary<string, int>();
                await this.Artists.ForEachAsync(a => tree[typeof(Artist)].Add(a.Name, a.Id));
            }

            if (types.Any(t => t == typeof(Album)))
            {
                tree[typeof(Album)] = new Dictionary<string, int>();
                await this.Albums.ForEachAsync(a => tree[typeof(Album)].Add(a.Name, a.Id));
            }
            if (types.Any(t => t == typeof(Track)))
            {
                tree[typeof(Track)] = new Dictionary<string, int>();
                await this.Tracks.ForEachAsync(a => tree[typeof(Track)].Add(a.Name, a.Id));
            }
            if (types.Any(t => t == typeof(Topic)))
            {
                tree[typeof(Topic)] = new Dictionary<string, int>();
                await this.Topics.ForEachAsync(a => tree[typeof(Topic)].Add(a.Text, a.TopicId));
            }
            if (types.Any(t => t == typeof(Genre)))
            {
                tree[typeof(Genre)] = new Dictionary<string, int>();
                await this.Genres.ForEachAsync(a => tree[typeof(Genre)].Add(a.Name, a.Id));
            }
            if (types.Any(t => t == typeof(Keyword)))
            {
                tree[typeof(Keyword)] = new Dictionary<string, int>();
                await this.Keywords.ForEachAsync(a => tree[typeof(Keyword)].Add(a.Text, a.KeywordId));
            }
            return tree;

        }

        public async Task<SearchResult> Search(string q, SaEntityType type, int limit = 5)
        {
            var results = new SearchResult();
            var dictionary = await GetSearchDictionary(type.GetTypes());

            if (!string.IsNullOrWhiteSpace(q))
            {
                foreach (var key in dictionary.Keys)
                {
                    var set = this.Set(key);
                    results.Items[key] = (from a in dictionary[key]
                                          where a.Key.ToLower().Contains(q.ToLower())
                                          select set.Find(a.Value) as ISaEntity)
                                          .ToList();
                }
            }
            return results;
        }

        public async Task<SearchResult> Search(SearchQuery q)
        {
            return await Search(q.query, q.type, q.limit);
        }

        public EntityDbContext() : base("DatabaseFile", throwIfV1Schema: false)
        {
            this.Configuration.ProxyCreationEnabled = false;

        }

        public static EntityDbContext Create()
        {
            return new EntityDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var tracks = modelBuilder.Entity<Track>();

            //tracks.HasKey(t => t.Id);
            tracks.HasRequired(t => t.Artist)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete(false);
            //var artists = modelBuilder.Entity<Artist>();

            //var albums = modelBuilder.Entity<Album>();

            ////modelBuilder.Entity<Album>()
            ////    .HasRequired(a => a.Artist)
            ////    .WithRequiredDependent()
            ////    .WillCascadeOnDelete(false);

            ////tracks.HasRequired(t => t.Album)
            ////    .WithRequiredDependent()
            ////    .WillCascadeOnDelete(false);

            //tracks
            //    .HasRequired(t => t.Artist)
            //    .WithRequiredDependent()
            //    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public T Create<T>(T entity) where T : SaDbEntityAccessor
        {
            var accessor = entity as SaDbEntityAccessor;
            if (accessor == null)
                return null;

            var existing = Get<T>(accessor.Name);


            if (existing != null)
                return existing;

            try
            {
                var set = this.Set<T>();
                var type = typeof(T);
                var props = type.GetProperties();
                var id = props.Where(p => p.Name == "Id").FirstOrDefault();
                var dbGenerated = id?
                    .GetCustomAttributes(typeof(DatabaseGeneratedAttribute), true)
                    .FirstOrDefault() as DatabaseGeneratedAttribute;

                if (dbGenerated != null && dbGenerated.DatabaseGeneratedOption == DatabaseGeneratedOption.Identity)
                {
                    if (this.GetType() != typeof(EntityDbContext))
                    {
                        entity.Id = set.Count() + 1;
                    }
                }
                set.Add(entity);
                this.SaveChanges();

                entity.Id = (from t in this.Set<T>()
                             let e = t as SaDbEntityAccessor
                             where e.Name == accessor.Name
                             select t)
                             .FirstOrDefault()?.Id ?? entity.Id;

                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }


}