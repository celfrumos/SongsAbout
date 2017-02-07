using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace SongsAbout.Web.Models
{
    public class SongDbContext : DbContext
    {
        DbSet<Artist> Artists { get; set; }
        public SongDbContext() : base("DefaultConnection")
        {

        }
    }
}