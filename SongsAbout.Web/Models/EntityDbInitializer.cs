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
            context.ProfilePics.Add(new ProfilePic { PictureId = 1, Url = @"/Images/Artists/solarsuit.jpg", Width = 700, Height = 700, AltText = "img-solarsuit" });
            context.ProfilePics.Add(new ProfilePic { PictureId = 2, Url = @"/Images/Artists/william-fitzsimmons.jpg", Width = 619, Height = 511, AltText = "img-william-fitzsimmons" });
            context.ProfilePics.Add(new ProfilePic { PictureId = 3, Url = @"https://yt3.ggpht.com/-1S7RkXQox98/AAAAAAAAAAI/AAAAAAAAAAA/hainLSG7AaM/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", Width = 642, Height = 642, AltText = "img-christina-grimmie" });
            context.ProfilePics.Add(new ProfilePic { PictureId = 4, Url = @"https://i.scdn.co/image/96a2e527431f7bf39cea4bf8702fc8159f08e2aa", Width = 640, Height = 640, AltText = "img-john-mayer" });

            Artist SolarSuit = new Artist { ArtistId = 0, Name = "Solarsuit", Bio = "I went to school with and took music lessons with half of these guys. They just got over 100,000 listens on their latest single, \"For the thrill\"", SpotifyId = "0baEjE334rm6o1DfzbTcHT", PictureId = 1 };
            Artist WilliamFitzsimmons = new Artist { Name = "William Fitzsimmons", Bio = "Slow is is forte. And he's killin it", SpotifyId = "41FEVJCBGidsJwbjq0KfgM", PictureId = 2 };
            Artist ChristinaGrimmie = new Artist { Name = "Christina Grimmie", Bio = "Started on Youtube, made it big on The Voice, but was tragically murdered last year.", SpotifyId = "0Cav8jyZKAHMFbAusOmjku", PictureId = 3 };
            Artist JohnMayer = new Artist { Name = "John Mayer", Bio = "The magical d-bag everyone wants to be.", SpotifyId = "0hEurMDQu99nJRq8pTxO14", PictureId = 4 };

            context.Artists.Add(SolarSuit);
            context.Artists.Add(WilliamFitzsimmons);
            context.Artists.Add(ChristinaGrimmie);
            context.Artists.Add(JohnMayer);

            base.Seed(context);

            var admin = new ApplicationUser { UserName = "jdegraw", Email = "jdegraw42@gmail.com", BirthDate = new DateTime(1994, month: 4, day: 18), FirstName = "Josh", LastName = "DeGraw" };
            var editor = new ApplicationUser { UserName = "editor", Email = "editor@gmail.com", BirthDate = new DateTime(1994, month: 4, day: 18), FirstName = "Editor", LastName = "DeGraw" };
            var viewer = new ApplicationUser { UserName = "Viewer", Email = "viewer@gmail.com", BirthDate = new DateTime(1994, month: 4, day: 18), FirstName = "Viewer", LastName = "DeGraw" };

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