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


        public EntityDbContext() : base("DatabaseFile")
        {

        }

        public static EntityDbContext Create()
        {
            return new EntityDbContext();
        }
    }
}