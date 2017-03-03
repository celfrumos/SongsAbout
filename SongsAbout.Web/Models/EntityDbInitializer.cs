using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace SongsAbout.Web.Models
{
    public class EntityDbInitializer : DropCreateDatabaseAlways<EntityDbContext>
    {
        protected override void Seed(EntityDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            Artist SolarSuit = new Artist
            {
                ArtistId = 0,
                Name = "Solarsuit",
                Bio = "I went to school with and took music lessons with half of these guys. They just got over 100,000 listens on their latest single, \"For the thrill\"",
                SpotifyWebPage = @"https://open.spotify.com/artist/0baEjE334rm6o1DfzbTcHT",
                ApiHref = @"https://api.spotify.com/v1/artists/0baEjE334rm6o1DfzbTcHT",
                SpotifyUri = "spotify:artist:0baEjE334rm6o1DfzbTcHT",
                ProfilePic = new Picture { SourceFile = "/Images/Artists/solarsuit.jpg", Width = 700, Height = 700 }
            };
            Artist WilliamFitzsimmons = new Artist
            {
                Name = "William Fitzsimmons",
                Bio = "Slow is is forte. And he's killin it",
                ApiHref = @"https://api.spotify.com/v1/artists/41FEVJCBGidsJwbjq0KfgM",
                SpotifyUri = "spotify:artist:41FEVJCBGidsJwbjq0KfgM"
            };
            Artist ChristinaGrimmie = new Artist
            {
                Name = "Christina Grimmie",
                Bio = "Started on Youtube, made it big on The Voice, but was tragically murdered last year.",
                ApiHref = @"https://api.spotify.com/v1/artists/0Cav8jyZKAHMFbAusOmjku",
                SpotifyUri = "spotify:artist:0Cav8jyZKAHMFbAusOmjku"
            };
            Artist JohnMayer = new Artist
            {
                Name = "John Mayer",
                Bio = "The magical d-bag everyone wants to be.",
                ApiHref = @"https://api.spotify.com/v1/artists/0hEurMDQu99nJRq8pTxO14",
                SpotifyUri = "spotify:artist:0hEurMDQu99nJRq8pTxO14"
            };

            context.Artists.Add(SolarSuit);
            context.Artists.Add(WilliamFitzsimmons);
            context.Artists.Add(ChristinaGrimmie);
            context.Artists.Add(JohnMayer);

            base.Seed(context);

            var admin = new ApplicationUser
            {
                UserName = "jdegraw",
                Email = "jdegraw42@gmail.com",
                BirthDate = new DateTime(1994, month: 4, day: 18),
                FirstName = "Josh",
                LastName = "DeGraw"
            };
            var editor = new ApplicationUser
            {
                UserName = "editor",
                Email = "editor@gmail.com",
                BirthDate = new DateTime(1994, month: 4, day: 18),
                FirstName = "Editor",
                LastName = "DeGraw"
            };
            var viewer = new ApplicationUser
            {
                UserName = "Viewer",
                Email = "viewer@gmail.com",
                BirthDate = new DateTime(1994, month: 4, day: 18),
                FirstName = "Viewer",
                LastName = "DeGraw"
            };
            userManager.Create(admin, "password");
            userManager.Create(editor, "password");
            userManager.Create(viewer, "password");

            roleManager.Create(new IdentityRole("canEdit"));
            roleManager.Create(new IdentityRole("admin"));
            roleManager.Create(new IdentityRole("canEdit"));

            userManager.AddToRole(admin.Id, "canEdit");
            userManager.AddToRole(admin.Id, "admin");
            userManager.AddToRole(editor.Id, "canEdit");
        }
    }
}