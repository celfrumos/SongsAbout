using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
      //  public DbSet<SaDescription> Descriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Genre>()
            //    .Property(g => g.Text)
            //    .HasColumnName("Text");
            // modelBuilder.Entity<AutoCompleteResult>().HasKey(r => new { r.Text, r.SaEntityId, r.SaEntityType });
            base.OnModelCreating(modelBuilder);
        }
        //public DbSet<AutoCompleteResult> AutoCompleteResults { get; set; }

        public EntityDbContext() : base("DatabaseFile", throwIfV1Schema: false)
        {

        }

        public static EntityDbContext Create()
        {
            return new EntityDbContext();
        }
    }
}