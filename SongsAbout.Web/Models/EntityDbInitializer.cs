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

            context.ProfilePics.Add(new ProfilePic { ProfilePicId = 1, Url = @"https://i.scdn.co/image/932e745adcf2799bfc479d9e60156f4968c00236", Width = 640, Height = 700, AltText = "img-solarsuit" });
            context.ProfilePics.Add(new ProfilePic { ProfilePicId = 2, Url = @"/Images/Artists/william-fitzsimmons.jpg", Width = 619, Height = 511, AltText = "img-william-fitzsimmons" });
            context.ProfilePics.Add(new ProfilePic { ProfilePicId = 3, Url = @"https://yt3.ggpht.com/-1S7RkXQox98/AAAAAAAAAAI/AAAAAAAAAAA/hainLSG7AaM/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", Width = 642, Height = 642, AltText = "img-christina-grimmie" });
            context.ProfilePics.Add(new ProfilePic { ProfilePicId = 4, Url = @"https://i.scdn.co/image/96a2e527431f7bf39cea4bf8702fc8159f08e2aa", Width = 640, Height = 640, AltText = "img-john-mayer" });
            context.ProfilePics.Add(new ProfilePic { ProfilePicId = 5, Url = @"https://i.scdn.co/image/f0370da3f52161b07a461b4be9a64d0adbfb498d", Width = 640, Height = 640, AltText = "img-ed-sheeran" });

            Artist SolarSuit = new Artist { Name = "Solarsuit", Bio = "I went to school with and took music lessons with half of these guys. They just got over 100,000 listens on their latest single, \"For the thrill\"", SpotifyId = "0baEjE334rm6o1DfzbTcHT", ProfilePicId = 1 };
            Artist WilliamFitzsimmons = new Artist { Name = "William Fitzsimmons", Bio = "Slow is is forte. And he's killin it", SpotifyId = "41FEVJCBGidsJwbjq0KfgM", ProfilePicId = 2 };
            Artist ChristinaGrimmie = new Artist { Name = "Christina Grimmie", Bio = "Started on Youtube, made it big on The Voice, but was tragically murdered last year.", SpotifyId = "0Cav8jyZKAHMFbAusOmjku", ProfilePicId = 3 };
            Artist JohnMayer = new Artist { Name = "John Mayer", Bio = "The magical d-bag everyone wants to be.", SpotifyId = "0hEurMDQu99nJRq8pTxO14", ProfilePicId = 4 };
            Artist EdSheeran = new Artist { Name = "Ed Sheeran", Bio = "The man. The myth. The Legend.", SpotifyId = "6eUKZXaKkcviH0Ku9w2n3V", ProfilePicId = 5 };
            Artist JonBellion = new Artist
            {
                Name = "Jon Bellion",
                Bio = "The most magical human being who exists",
                SpotifyId = "50JJSqHUf2RQ9xsHs0KMHg",
                ProfilePic = new ProfilePic
                {
                    Height = 640,
                    Url = @"https://i.scdn.co/image/b70305d3545319fefcd4f64df45f830df91537b4",
                    Width = 640
                }
            };

            context.Artists.Add(SolarSuit);
            context.Artists.Add(WilliamFitzsimmons);
            context.Artists.Add(ChristinaGrimmie);
            context.Artists.Add(JohnMayer);
            context.Artists.Add(EdSheeran);
            context.Artists.Add(JonBellion);


            Album Divide = new Album
            {
                Name = "÷",
                ReleaseDate = new DateTime(2016, 10, 12),
                SpotifyId = "7oJa8bPFKVbq4c7NswXHw8",
                ArtistId = EdSheeran.ArtistId,
                AlbumCover = new AlbumCover { Height = 640, Url = @"https://i.scdn.co/image/621d2909bcc2c26cd0b274aab0414c9d422a1576", Width = 640 }
            };

            Album JustForTheThrill = new Album
            {
                Name = "Just For the Thrill",
                ReleaseDate = new DateTime(2016, 10, 12),
                SpotifyId = "38z89yJ9RJgsbW8D1bYNHZ",
                ArtistId = SolarSuit.ArtistId,
                AlbumCover = new AlbumCover { Width = 640, Height = 640, Url = @"https://i.scdn.co/image/3e9e8cf09f1966c34113e7937d05db1589d6744d" }
            };

            Album TheDefinition = new Album
            {
                Name = "The Definition",
                ReleaseDate = new DateTime(2016, 10, 12),
                ArtistId = JonBellion.ArtistId
            };

            Album Plus = new Album
            {
                ArtistId = EdSheeran.ArtistId,
                Name = "+",
                ReleaseDate = new DateTime(2016, 10, 12)
            };

            context.Albums.Add(Divide);
            context.Albums.Add(Plus);
            context.Albums.Add(JustForTheThrill);
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