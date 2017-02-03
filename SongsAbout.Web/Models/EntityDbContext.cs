using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SongsAbout.Web.Models
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext() : base("DatabaseFile")
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}