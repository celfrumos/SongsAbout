using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SpotifyAPI.Web.Models;
using System.IO;
using System.Threading.Tasks;

namespace SongsAbout.Web.Models
{
    public class EntityDbInitializer : DropCreateDatabaseAlways<EntityDbContext>
    {


        protected override void Seed(EntityDbContext context)
        {
            Spotify.SeedDatabase(context);
        }
    }
}