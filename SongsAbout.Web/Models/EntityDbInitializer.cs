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
            try
            {

                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


                #region ProfilePics
                context.ProfilePics.Add(new ProfilePic { ProfilePicId = 0, Url = "https://i.scdn.co/image/b0b295beeb9c89c5060f9f08f9c0de55d00aad0a", AltText = "img-Gavin James", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 1, Url = "https://i.scdn.co/image/1d29072e2633c7d9f74fa3fc4f0d9187cd927f2e", AltText = "img-Zac Brown Band", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 2, Url = "https://i.scdn.co/image/557a642bbc541262c649096b3d1ef938f67ec69a", AltText = "img-Josh Ritter", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 3, Url = "https://i.scdn.co/image/2e30a95ed5539cc08cc339439a596db30304d31a", AltText = "img-Damien Rice", Width = 1000, Height = 1409 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 4, Url = "https://i.scdn.co/image/87f80d10ee08702923654c6d02dda95a7d71a029", AltText = "img-Bear's Den", Width = 1000, Height = 1500 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 5, Url = "https://i.scdn.co/image/3b822e8c5d26c2352ad5528adc0035b636e8c293", AltText = "img-Passenger", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 7, Url = "https://i.scdn.co/image/cb539553a14fda1c6be339e79c60106aa258f31c", AltText = "img-Ray LaMontagne", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 8, Url = "https://i.scdn.co/image/0b3c04473aa6a2db8235e5092ec3413f35752b8d", AltText = "img-Muse", Width = 1000, Height = 667 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 9, Url = "https://i.scdn.co/image/e31f80705ec36662a56f53600f884047c8c9d37a", AltText = "img-Defeater", Width = 667, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 10, Url = "https://i.scdn.co/image/7b95c4f69986f59dc3244a72d973d3a32e56d5e5", AltText = "img-The Downtown Fiction", Width = 1000, Height = 563 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 12, Url = "https://i.scdn.co/image/2fc7abfb4f9f94d1cf71b3e6e8e3c504497af9fd", AltText = "img-Ben Howard", Width = 924, Height = 519 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 14, Url = "https://i.scdn.co/image/e759e8e517c8936035d6fb8a7535286937cf4e23", AltText = "img-Bon Iver", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 15, Url = "https://i.scdn.co/image/f0370da3f52161b07a461b4be9a64d0adbfb498d", AltText = "img-Ed Sheeran", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 16, Url = "https://i.scdn.co/image/dc197bb2333aad767069532afb2750ab1d796b87", AltText = "img-James Vincent McMorrow", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 18, Url = "https://i.scdn.co/image/5617643b3e1309e67be28d63438ba41170aa942b", AltText = "img-Stu Larsen", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 19, Url = "https://i.scdn.co/image/4a2c4a0080a3711a5e3015bcfcafec2ebf90e4a7", AltText = "img-The Civil Wars", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 21, Url = "https://i.scdn.co/image/07c35e32c87810913eca6d95dcde841944e5f8b6", AltText = "img-Hozier", Width = 1000, Height = 667 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 22, Url = "https://i.scdn.co/image/0075f5a216a3b234af89dab58178e971e5905042", AltText = "img-Hoobastank", Width = 1000, Height = 636 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 24, Url = "https://i.scdn.co/image/92a8fbbe68b87001e1d096a4b1b7d1a29fdd364d", AltText = "img-Ben Folds Five", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 25, Url = "https://i.scdn.co/image/22d08c8c0a505180794d82ab02c8e0cd5c81ae87", AltText = "img-The Verve Pipe", Width = 1000, Height = 797 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 26, Url = "https://i.scdn.co/image/783e5535cfaf00c9eac90cfb92477c18d554ed87", AltText = "img-The Smashing Pumpkins", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 27, Url = "https://i.scdn.co/image/5b2072e522bf3324019a8c2dc3db20116dff0b87", AltText = "img-Red Hot Chili Peppers", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 28, Url = "https://i.scdn.co/image/a7ebe1e718343142ba4ba36d848986dbb8fbea11", AltText = "img-Rise Against", Width = 1000, Height = 1250 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 29, Url = "https://i.scdn.co/image/a69a5087d8206653ea2228f60fada039c3419321", AltText = "img-BØRNS", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 30, Url = "https://i.scdn.co/image/8cb38cea45e1382002fe98c3314520b0a28f1025", AltText = "img-Queensrÿche", Width = 1000, Height = 563 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 31, Url = "https://i.scdn.co/image/18bbcd7d392b5f48754d7d89afe37f979fb47199", AltText = "img-Five For Fighting", Width = 776, Height = 1164 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 32, Url = "https://i.scdn.co/image/4c3380a27af9d846dae62ffbd6f63e7ef7aa83d1", AltText = "img-Years & Years", Width = 1000, Height = 563 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 34, Url = "https://i.scdn.co/image/48c6ca7a3c85c68b85473ca7c08b53694ecef616", AltText = "img-The Temptations", Width = 1000, Height = 1215 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 45, Url = "https://i.scdn.co/image/e54841d3d62bb0866f8d03566c008224fa14dbf0", AltText = "img-Brett Dennen", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 50, Url = "https://i.scdn.co/image/dd4f43fac8a20266ac10cc3ef426230f46f2ceaa", AltText = "img-Joel Brown", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 52, Url = "https://i.scdn.co/image/1fdea64b6420908000e4b18b0efeeb8b659f465d", AltText = "img-Nick Mulvey", Width = 480, Height = 480 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 53, Url = "https://i.scdn.co/image/afcd616e1ef2d2786f47b3b4a8a6aeea24a72adc", AltText = "img-Radiohead", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 55, Url = "https://i.scdn.co/image/c9475278ed947f3b8241b5504ef8c7830897892b", AltText = "img-Sufjan Stevens", Width = 942, Height = 942 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 57, Url = "https://i.scdn.co/image/76b3f75c063f1859287e11a865d87b1fb0b01515", AltText = "img-The Avett Brothers", Width = 1000, Height = 563 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 59, Url = "https://i.scdn.co/image/c6fa139c6296676efecd19c88b387f0bc123d5f2", AltText = "img-Jamie Lawson", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 60, Url = "https://i.scdn.co/image/d8388cd8b9605d8fd21143495c12260633c23da3", AltText = "img-Matt Corby", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 63, Url = "https://i.scdn.co/image/c5942815e6f54d917064c123946e89723d92af4b", AltText = "img-Damien Leith", Width = 480, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 64, Url = "https://i.scdn.co/image/186c1a3f5756f3a821590e63fdef25ca0aea4806", AltText = "img-Hudson Taylor", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 65, Url = "https://i.scdn.co/image/0207dcc7033cf4a4ec6f78497b95f21817eee8f0", AltText = "img-Zach Hurd", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 66, Url = "https://i.scdn.co/image/112530d55dde155dcefe401355baa3600bc94e4c", AltText = "img-Brandon Flowers", Width = 876, Height = 657 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 67, Url = "https://i.scdn.co/image/16a7ef78e78a86080e989bbac40a6bf5304e58a4", AltText = "img-Nick Jonas", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 69, Url = "https://i.scdn.co/image/2ea4c4c9f93d2ba844ec122a1eaebf1153e27576", AltText = "img-A Great Big World", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 70, Url = "https://i.scdn.co/image/abd3caa11ac6dab64a85eb203f14dee55228379c", AltText = "img-Penny and Sparrow", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 71, Url = "https://i.scdn.co/image/7ac4e51076b021c4574af0e701e7ecd93eb3cc2a", AltText = "img-Anthony D'Amato", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 72, Url = "https://i.scdn.co/image/cf42999826a54f50bd1f0c067876cfd8af9bdcb4", AltText = "img-Landon Pigg", Width = 350, Height = 266 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 73, Url = "https://i.scdn.co/image/46bcda8ace85c001d96bd9d471de4c16c586f695", AltText = "img-Joshua Hyslop", Width = 1000, Height = 748 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 74, Url = "https://i.scdn.co/image/57725d3a39b5fc1c50804fd276ceb2721f6fd3c2", AltText = "img-The Boxer Rebellion", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 75, Url = "https://i.scdn.co/image/4614d832e86290f919a78efdd40137058ba59ced", AltText = "img-The Dangerous Summer", Width = 819, Height = 546 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 76, Url = "https://i.scdn.co/image/a841f0ee4f2d88c42f55f76c2cc6b588841f5d2f", AltText = "img-The Killers", Width = 500, Height = 500 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 81, Url = "https://i.scdn.co/image/d560c02ffe2a6077f7c3c615f94cd86bd404c481", AltText = "img-Disturbed", Width = 1000, Height = 999 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 82, Url = "https://i.scdn.co/image/2786cb62b7d2a54a4cbb0adb4056e164a3bd0456", AltText = "img-Twin Forks", Width = 500, Height = 333 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 83, Url = "https://i.scdn.co/image/d8bc6593d0449a578ceb545fd1ae9172ac67bf83", AltText = "img-James Bay", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 84, Url = "https://i.scdn.co/image/355916288e8167eb6bec974cd0791ba2b752531b", AltText = "img-Jeff LeBlanc", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 86, Url = "https://i.scdn.co/image/a3bed9e4ae5f698be9342ea2919555edd24f502d", AltText = "img-Gavin DeGraw", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 88, Url = "https://i.scdn.co/image/6f005f88cc2268338fdb96bd80d0a1a4043d943e", AltText = "img-Saosin", Width = 1000, Height = 1000 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 89, Url = "https://i.scdn.co/image/d696f417631d1bf4b6091b1ea9d2d21ed85e10a9", AltText = "img-Richard Walters", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 90, Url = "https://i.scdn.co/image/ca0df12bb57a5e724b41bde4e99e9c3375f13d18", AltText = "img-Skinny Living", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 91, Url = "https://i.scdn.co/image/593cf12da738c1f8d14b315ebbd606d2fac72504", AltText = "img-The Midwest Indies", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 92, Url = "https://i.scdn.co/image/02235b3c2043d52429b14dc8566a5f865eb9e33b", AltText = "img-Joshua James", Width = 500, Height = 333 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 93, Url = "https://i.scdn.co/image/e28010a07d5cbdbb349b807e7a5261f5e335cdd5", AltText = "img-Andy Zipf", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 94, Url = "https://i.scdn.co/image/cf169a50f4980519132077adbd48d0ec93cdaeb9", AltText = "img-Phosphorescent", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 95, Url = "https://i.scdn.co/image/ed6659216ed9cc2418feaa4026a5a565644ba807", AltText = "img-Jaymes Young", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 96, Url = "https://i.scdn.co/image/ed3fe376df10f6c1cd475f0b6d6d4f0546b29eec", AltText = "img-Front Porch Step", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 97, Url = "https://i.scdn.co/image/748cfab5b58581d19da9a5a470782bd903234610", AltText = "img-Roo Panes", Width = 640, Height = 640 });
                //context.ProfilePics.Add(new ProfilePic { ProfilePicId = 98, Url = "https://i.scdn.co/image/aec5ed757f1ac4b81620bced3a9f6116de4114e6", AltText = "img-Bombadil", Width = 640, Height = 640 });
                #endregion

                #region Artists
                context.Artists.Add(new Artist { ArtistId = 0, Name = "Gavin James", SpotifyId = "25tMQOrIU4LlUo6Sv8v5SE", ProfilePicId = 0 });
                //context.Artists.Add(new Artist { ArtistId = 1, Name = "Zac Brown Band", SpotifyId = "6yJCxee7QumYr820xdIsjo", ProfilePicId = 1 });
                //context.Artists.Add(new Artist { ArtistId = 2, Name = "Josh Ritter", SpotifyId = "6igfLpd8s6DBBAuwebRUuo", ProfilePicId = 2 });
                //context.Artists.Add(new Artist { ArtistId = 3, Name = "Damien Rice", SpotifyId = "14r9dR01KeBLFfylVSKCZQ", ProfilePicId = 3 });
                //context.Artists.Add(new Artist { ArtistId = 4, Name = "Bear's Den", SpotifyId = "0nJaMZM8paoA5HEUTUXPqi", ProfilePicId = 4 });
                //context.Artists.Add(new Artist { ArtistId = 5, Name = "Passenger", SpotifyId = "0gadJ2b9A4SKsB1RFkBb66", ProfilePicId = 5 });
                //context.Artists.Add(new Artist { ArtistId = 7, Name = "Ray LaMontagne", SpotifyId = "6DoH7ywD5BcQvjloe9OcIj", ProfilePicId = 7 });
                //context.Artists.Add(new Artist { ArtistId = 8, Name = "Muse", SpotifyId = "12Chz98pHFMPJEknJQMWvI", ProfilePicId = 8 });
                //context.Artists.Add(new Artist { ArtistId = 9, Name = "Defeater", SpotifyId = "1L3hqVCHSL1Ajy3m0z1bAT", ProfilePicId = 9 });
                //context.Artists.Add(new Artist { ArtistId = 10, Name = "The Downtown Fiction", SpotifyId = "7MRDkEKtdsGcYn11A4qgUL", ProfilePicId = 10 });
                //context.Artists.Add(new Artist { ArtistId = 12, Name = "Ben Howard", SpotifyId = "5schNIzWdI9gJ1QRK8SBnc", ProfilePicId = 12 });
                //context.Artists.Add(new Artist { ArtistId = 14, Name = "Bon Iver", SpotifyId = "4LEiUm1SRbFMgfqnQTwUbQ", ProfilePicId = 14 });
                //context.Artists.Add(new Artist { ArtistId = 15, Name = "Ed Sheeran", SpotifyId = "6eUKZXaKkcviH0Ku9w2n3V", ProfilePicId = 15 });
                //context.Artists.Add(new Artist { ArtistId = 16, Name = "James Vincent McMorrow", SpotifyId = "7FDlvgcodNfC0IBdWevl4u", ProfilePicId = 16 });
                //context.Artists.Add(new Artist { ArtistId = 18, Name = "Stu Larsen", SpotifyId = "44M8i4BCwuBbmcQWwMaOfH", ProfilePicId = 18 });
                //context.Artists.Add(new Artist { ArtistId = 19, Name = "The Civil Wars", SpotifyId = "6J7rw7NELJUCThPbAfyLIE", ProfilePicId = 19 });
                //context.Artists.Add(new Artist { ArtistId = 21, Name = "Hozier", SpotifyId = "2FXC3k01G6Gw61bmprjgqS", ProfilePicId = 21 });
                //context.Artists.Add(new Artist { ArtistId = 22, Name = "Hoobastank", SpotifyId = "2MqhkhX4npxDZ62ObR5ELO", ProfilePicId = 22 });
                //context.Artists.Add(new Artist { ArtistId = 24, Name = "Ben Folds Five", SpotifyId = "44gRHbEm4Uqa0ykW0rDTNk", ProfilePicId = 24 });
                //context.Artists.Add(new Artist { ArtistId = 25, Name = "The Verve Pipe", SpotifyId = "242iqFnwNhlidVBMI9GYKp", ProfilePicId = 25 });
                //context.Artists.Add(new Artist { ArtistId = 26, Name = "The Smashing Pumpkins", SpotifyId = "40Yq4vzPs9VNUrIBG5Jr2i", ProfilePicId = 26 });
                //context.Artists.Add(new Artist { ArtistId = 27, Name = "Red Hot Chili Peppers", SpotifyId = "0L8ExT028jH3ddEcZwqJJ5", ProfilePicId = 27 });
                //context.Artists.Add(new Artist { ArtistId = 28, Name = "Rise Against", SpotifyId = "6Wr3hh341P84m3EI8qdn9O", ProfilePicId = 28 });
                //context.Artists.Add(new Artist { ArtistId = 29, Name = "BØRNS", SpotifyId = "1KP6TWI40m7p3QBTU6u2xo", ProfilePicId = 29 });
                //context.Artists.Add(new Artist { ArtistId = 30, Name = "Queensrÿche", SpotifyId = "2OgUPVlWYgGBGMefZgGvCO", ProfilePicId = 30 });
                //context.Artists.Add(new Artist { ArtistId = 31, Name = "Five For Fighting", SpotifyId = "7FgMLbnZVrEnir95O0YujA", ProfilePicId = 31 });
                //context.Artists.Add(new Artist { ArtistId = 32, Name = "Years & Years", SpotifyId = "5vBSrE1xujD2FXYRarbAXc", ProfilePicId = 32 });
                //context.Artists.Add(new Artist { ArtistId = 34, Name = "The Temptations", SpotifyId = "3RwQ26hR2tJtA8F9p2n7jG", ProfilePicId = 34 });
                //context.Artists.Add(new Artist { ArtistId = 45, Name = "Brett Dennen", SpotifyId = "0FC1LIeQXKib0jOwZqeIwT", ProfilePicId = 45 });
                //context.Artists.Add(new Artist { ArtistId = 50, Name = "Joel Brown", SpotifyId = "6vMmqaauubP4qBujCf6DPY", ProfilePicId = 50 });
                //context.Artists.Add(new Artist { ArtistId = 52, Name = "Nick Mulvey", SpotifyId = "3x8FbPjh2Qz55XMdE2Yalj", ProfilePicId = 52 });
                //context.Artists.Add(new Artist { ArtistId = 53, Name = "Radiohead", SpotifyId = "4Z8W4fKeB5YxbusRsdQVPb", ProfilePicId = 53 });
                //context.Artists.Add(new Artist { ArtistId = 55, Name = "Sufjan Stevens", SpotifyId = "4MXUO7sVCaFgFjoTI5ox5c", ProfilePicId = 55 });
                //context.Artists.Add(new Artist { ArtistId = 57, Name = "The Avett Brothers", SpotifyId = "196lKsA13K3keVXMDFK66q", ProfilePicId = 57 });
                //context.Artists.Add(new Artist { ArtistId = 59, Name = "Jamie Lawson", SpotifyId = "1jhdZdzOd4TJLAHqQdkUND", ProfilePicId = 59 });
                //context.Artists.Add(new Artist { ArtistId = 60, Name = "Matt Corby", SpotifyId = "7CIW23FQUXPc1zebnO1TDG", ProfilePicId = 60 });
                //context.Artists.Add(new Artist { ArtistId = 63, Name = "Damien Leith", SpotifyId = "5XVcYaeSTGZXwxd63aY9Tv", ProfilePicId = 63 });
                //context.Artists.Add(new Artist { ArtistId = 64, Name = "Hudson Taylor", SpotifyId = "4DX2G1URzfEiRg2wBfv4ub", ProfilePicId = 64 });
                //context.Artists.Add(new Artist { ArtistId = 65, Name = "Zach Hurd", SpotifyId = "1f2CFEq5J7ZyeTAVU6ubRX", ProfilePicId = 65 });
                //context.Artists.Add(new Artist { ArtistId = 66, Name = "Brandon Flowers", SpotifyId = "18Zv2g2vUcEGqJf6WnjfXN", ProfilePicId = 66 });
                //context.Artists.Add(new Artist { ArtistId = 67, Name = "Nick Jonas", SpotifyId = "4Rxn7Im3LGfyRkY2FlHhWi", ProfilePicId = 67 });
                //context.Artists.Add(new Artist { ArtistId = 69, Name = "A Great Big World", SpotifyId = "5xKp3UyavIBUsGy3DQdXeF", ProfilePicId = 69 });
                //context.Artists.Add(new Artist { ArtistId = 70, Name = "Penny and Sparrow", SpotifyId = "65o6y7GtoXzchyiJB3r9Ur", ProfilePicId = 70 });
                //context.Artists.Add(new Artist { ArtistId = 71, Name = "Anthony D'Amato", SpotifyId = "1oplL2hHYq7CQykvSbd6gy", ProfilePicId = 71 });
                //context.Artists.Add(new Artist { ArtistId = 72, Name = "Landon Pigg", SpotifyId = "1whjlG0NSaQytgDIWz10GS", ProfilePicId = 72 });
                //context.Artists.Add(new Artist { ArtistId = 73, Name = "Joshua Hyslop", SpotifyId = "1I7oHjCjMrMUz66v67yJJu", ProfilePicId = 73 });
                //context.Artists.Add(new Artist { ArtistId = 74, Name = "The Boxer Rebellion", SpotifyId = "7DEseTqRODmSu3C7jxCHl5", ProfilePicId = 74 });
                //context.Artists.Add(new Artist { ArtistId = 75, Name = "The Dangerous Summer", SpotifyId = "0iMnpaEHXkgMT956CmP1kj", ProfilePicId = 75 });
                //context.Artists.Add(new Artist { ArtistId = 76, Name = "The Killers", SpotifyId = "0C0XlULifJtAgn6ZNCW2eu", ProfilePicId = 76 });
                //context.Artists.Add(new Artist { ArtistId = 81, Name = "Disturbed", SpotifyId = "3TOqt5oJwL9BE2NG9MEwDa", ProfilePicId = 81 });
                //context.Artists.Add(new Artist { ArtistId = 82, Name = "Twin Forks", SpotifyId = "6GwNGuDRNbx5XwoHQA3QiD", ProfilePicId = 82 });
                //context.Artists.Add(new Artist { ArtistId = 83, Name = "James Bay", SpotifyId = "4EzkuveR9pLvDVFNx6foYD", ProfilePicId = 83 });
                //context.Artists.Add(new Artist { ArtistId = 84, Name = "Jeff LeBlanc", SpotifyId = "0F55dmw0A9gnYhgJfH0b3b", ProfilePicId = 84 });
                //context.Artists.Add(new Artist { ArtistId = 86, Name = "Gavin DeGraw", SpotifyId = "5DYAABs8rkY9VhwtENoQCz", ProfilePicId = 86 });
                //context.Artists.Add(new Artist { ArtistId = 88, Name = "Saosin", SpotifyId = "1NUOfvAhA9AvsF1ISMkgHX", ProfilePicId = 88 });
                //context.Artists.Add(new Artist { ArtistId = 89, Name = "Richard Walters", SpotifyId = "3rUqgY188kWz0hKkqnpk9F", ProfilePicId = 89 });
                //context.Artists.Add(new Artist { ArtistId = 90, Name = "Skinny Living", SpotifyId = "405DvLr0FOuOWYgCt0emff", ProfilePicId = 90 });
                //context.Artists.Add(new Artist { ArtistId = 91, Name = "The Midwest Indies", SpotifyId = "2knI8PaBy2UyrRBhGmBbQJ", ProfilePicId = 91 });
                //context.Artists.Add(new Artist { ArtistId = 92, Name = "Joshua James", SpotifyId = "0YLUOdFiedWIWBttlDAQeO", ProfilePicId = 92 });
                //context.Artists.Add(new Artist { ArtistId = 93, Name = "Andy Zipf", SpotifyId = "5gj2Ul170gSipbsNQbea37", ProfilePicId = 93 });
                //context.Artists.Add(new Artist { ArtistId = 94, Name = "Phosphorescent", SpotifyId = "57kIMCLPgkzQlXjblX7XXP", ProfilePicId = 94 });
                //context.Artists.Add(new Artist { ArtistId = 95, Name = "Jaymes Young", SpotifyId = "6QrQ7OrISRYIfS5mtacaw2", ProfilePicId = 95 });
                //context.Artists.Add(new Artist { ArtistId = 96, Name = "Front Porch Step", SpotifyId = "4UXiNDHAiv8DOSLkp0GbSm", ProfilePicId = 96 });
                //context.Artists.Add(new Artist { ArtistId = 97, Name = "Roo Panes", SpotifyId = "0XHM5ZNJDU8e4CfbWMeSzC", ProfilePicId = 97 });
                //context.Artists.Add(new Artist { ArtistId = 98, Name = "Bombadil", SpotifyId = "6AlXfeCNG9lrauBDG7GyjM", ProfilePicId = 98 });
                #endregion

                #region AlbumCovers
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 0, Url = "https://i.scdn.co/image/7cb1dac416742f2099d1f0edc45dcaac97a8e913", AltText = "img-The Book Of Love", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 1, Url = "https://i.scdn.co/image/a3a4ddecb4b78c6b73301169dd7f43d09fcf8dd1", AltText = "img-JEKYLL + HYDE", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 2, Url = "https://i.scdn.co/image/5445c78743f002a5cde9d7cefd1282defd74bfd3", AltText = "img-The Historical Conquests of Josh Ritter", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 3, Url = "https://i.scdn.co/image/435a8e5d51350af8bb6df0bf1ccc2b23eb0bbaa5", AltText = "img-I Don't Want To Change You", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 4, Url = "https://i.scdn.co/image/cb57464658f61bafede2ee036b17a99c77251201", AltText = "img-Islands", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 5, Url = "https://i.scdn.co/image/e0efd50908c5363780144edfa50e74f0149330a5", AltText = "img-Whispers II", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 7, Url = "https://i.scdn.co/image/2da5597240fedceb6365cb4c7b5355992c27964a", AltText = "img-Trouble", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 8, Url = "https://i.scdn.co/image/849eecf3c9df835181c2970c435ac2d008346ea3", AltText = "img-Drones", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 9, Url = "https://i.scdn.co/image/8b38755be2c59c1a917ab92800301da459e76865", AltText = "img-Empty Days & Sleepless Nights", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 10, Url = "https://i.scdn.co/image/4c78bf7f246502aefb02df7ef50ccce457497933", AltText = "img-Best I Never Had", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 11, Url = "https://i.scdn.co/image/63a7be15eae7b897d1481b6e4447b2bf694e1da3", AltText = "img-Whispers (Deluxe)", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 12, Url = "https://i.scdn.co/image/8b32a99560bc0da8eeb563fb0fd7e140f182bfdc", AltText = "img-Every Kingdom (Deluxe Version)", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 14, Url = "https://i.scdn.co/image/08121d319bb1c95d0e575cbae3ff8801205d4e22", AltText = "img-For Emma, Forever Ago", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 15, Url = "https://i.scdn.co/image/b68b39fdc2409d0f526ad48775ddcd93ff496cda", AltText = "img-x (Deluxe Edition)", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 16, Url = "https://i.scdn.co/image/e5485384ade8154d63546a11af915ee70ab334f0", AltText = "img-Silver Lining", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 18, Url = "https://i.scdn.co/image/40ed78446b8987e0aaa6c0527eb68d6289a62e81", AltText = "img-Vagabond", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 19, Url = "https://i.scdn.co/image/2195d8056a41c73fa7132f5e956a030dd32bf3dc", AltText = "img-Barton Hollow", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 21, Url = "https://i.scdn.co/image/54ae81bff27a1979815d40846c763431d872b680", AltText = "img-Hozier", Width = 640, Height = 636 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 22, Url = "https://i.scdn.co/image/692e8c84afb1e5140ad4ff7695343e8c775bae68", AltText = "img-Best Of", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 23, Url = "https://i.scdn.co/image/849eecf3c9df835181c2970c435ac2d008346ea3", AltText = "img-Dead Inside", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 24, Url = "https://i.scdn.co/image/8ff64c89950a4b3584bec7263328a62a68d97c30", AltText = "img-Whatever And Ever Amen (Remastered Edition)", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 25, Url = "https://i.scdn.co/image/01aaf336d7f99e37af9e83e6f7edce7baf427ba7", AltText = "img-Villains", Width = 638, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 26, Url = "https://i.scdn.co/image/f983782b136e0dae72064e28a524e2dbcfefd8af", AltText = "img-Rotten Apples, The Smashing Pumpkins Greatest Hits", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 27, Url = "https://i.scdn.co/image/260c7a6da14bb13a4cc9e75bf5b549fb87fa22a9", AltText = "img-Californication (Deluxe Version)", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 28, Url = "https://i.scdn.co/image/8bd92d3256a5f5ce9dd793684452c1121368b91e", AltText = "img-Siren Song Of The Counter-Culture", Width = 629, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 29, Url = "https://i.scdn.co/image/18cfd668457e1bbc42810c4ac259428ecee9764b", AltText = "img-Candy", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 30, Url = "https://i.scdn.co/image/8bf65dfa59d23b680cbda204c93f6a266b25f3df", AltText = "img-The Best Of Queensryche (Deluxe Edition)", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 31, Url = "https://i.scdn.co/image/e91c580d99e56ec8cca2036368aed560bd1f2cdf", AltText = "img-America Town", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 32, Url = "https://i.scdn.co/image/796283387c818b39066382c96cc13c3661dcb537", AltText = "img-Communion", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 34, Url = "https://i.scdn.co/image/ae8e44b60b57c645b5f4537db7db4a4a8ae69c4d", AltText = "img-An American Love Story", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 35, Url = "https://i.scdn.co/image/796283387c818b39066382c96cc13c3661dcb537", AltText = "img-Communion (Deluxe)", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 37, Url = "https://i.scdn.co/image/43bf97e5b621230110d3d515bd272bde91059d1f", AltText = "img-+", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 43, Url = "https://i.scdn.co/image/925928009d79a338c83ffc3d80d09aa4cd41e5b4", AltText = "img-Without/Within", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 45, Url = "https://i.scdn.co/image/96ddf4684c2117d1b0c468c413d59ffbf5fce64c", AltText = "img-The Definitive Collection", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 50, Url = "https://i.scdn.co/image/912c5beceb9ef8a7dac75d5169c05fcaca5c4aa6", AltText = "img-In Retrospect", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 52, Url = "https://i.scdn.co/image/3c99ace701d416e66e33243e84eed106e6b5d3f0", AltText = "img-First Mind", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 53, Url = "https://i.scdn.co/image/8eee28994e7a5963fd9415392ae8777562baca4c", AltText = "img-Pablo Honey [Collector's Edition]", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 55, Url = "https://i.scdn.co/image/1ba7c23172045f4cec6fc498bf267133ef3e859a", AltText = "img-Michigan", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 56, Url = "https://i.scdn.co/image/8caec0104e3163cde958808d32631e1e79a08ebe", AltText = "img-Seven Swans", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 57, Url = "https://i.scdn.co/image/28f5d249ebef93ff897a2dccbe6c7e5b36fd0922", AltText = "img-Emotionalism", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 58, Url = "https://i.scdn.co/image/85269645c7921959dd560ee6e1eaed0779598342", AltText = "img-The Second Gleam", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 59, Url = "https://i.scdn.co/image/cd6483d0a2e3dc7da285fd1a8fa2adb2946efe0a", AltText = "img-Jamie Lawson", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 60, Url = "https://i.scdn.co/image/60a714d5c89f5751902f78dedd9a09b71572606c", AltText = "img-Resolution", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 61, Url = "https://i.scdn.co/image/13eaf5dd1ae17b5d25fb25dc145bda918f393845", AltText = "img-Into The Flame", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 63, Url = "https://i.scdn.co/image/43fd51abf65e47d9b90e5b682c9e1c915196d5c0", AltText = "img-Where We Land", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 64, Url = "https://i.scdn.co/image/453f530dcd98b46c446591ef65b0dc23da822ff1", AltText = "img-Chasing Rubies", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 65, Url = "https://i.scdn.co/image/0207dcc7033cf4a4ec6f78497b95f21817eee8f0", AltText = "img-She Never Sleeps", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 66, Url = "https://i.scdn.co/image/d2ce48899ebc8a2e18caee8ab711dad4d66765d1", AltText = "img-Flamingo", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 67, Url = "https://i.scdn.co/image/5f1fe7052e0449f686f45dbcb481227af7602122", AltText = "img-Nick Jonas X2", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 68, Url = "https://i.scdn.co/image/96623ab2e48c9939bc5e55bdea680e14c3af3559", AltText = "img-Jealous", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 69, Url = "https://i.scdn.co/image/8863198086f9707f49deeb0c5f8a269344dc7dda", AltText = "img-Is There Anybody Out There?", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 70, Url = "https://i.scdn.co/image/4edac565bdf5a2acef42ea91956f0fc73a2ba02e", AltText = "img-Tenboom", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 71, Url = "https://i.scdn.co/image/b7c60bac34921d07b46bfeee6da3a3ac22c65665", AltText = "img-The Shipwreck From The Shore", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 72, Url = "https://i.scdn.co/image/09324265e14ce8fde416087b13806983736d1bb3", AltText = "img-The Boy Who Never", Width = 640, Height = 579 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 73, Url = "https://i.scdn.co/image/fbc41f74093f16bcd527c1a8d24399861bb3c539", AltText = "img-Where the Mountain Meets the Valley", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 74, Url = "https://i.scdn.co/image/5837426ae02c873b33c96593c759513a83f3a096", AltText = "img-Promises", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 75, Url = "https://i.scdn.co/image/85b7a99dfcd26e127c278490a27b9983dc8b3de1", AltText = "img-Reach For The Sun", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 76, Url = "https://i.scdn.co/image/ae33d84ad5b1b47f5c7b73c63ca0f1fd4d131b84", AltText = "img-Hot Fuss", Width = 629, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 78, Url = "https://i.scdn.co/image/f36d041b1f05a4b4278e204c89800d8f609b1849", AltText = "img-Sam's Town", Width = 640, Height = 635 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 80, Url = "https://i.scdn.co/image/5470d09a9e68ce0e4fb7060a7c91dd8dd14ad782", AltText = "img-Day & Age", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 81, Url = "https://i.scdn.co/image/0f0e46bdf41faaf955dc5d4dcc60177414a0704d", AltText = "img-Immortalized", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 82, Url = "https://i.scdn.co/image/1ba59cc261ee6b1aad9021f61dd4214a208d0f88", AltText = "img-Twin Forks", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 83, Url = "https://i.scdn.co/image/80cce6b1bb492fd45ddb26a81c79959527d98a63", AltText = "img-Chaos And The Calm", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 84, Url = "https://i.scdn.co/image/eba32d12b195f14d62a46850b0b16dd3deaa788d", AltText = "img-Vision", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 86, Url = "https://i.scdn.co/image/dbbc4e1d1c39c7ae2a81137a8808626c5aeaf593", AltText = "img-Sweeter", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 88, Url = "https://i.scdn.co/image/0207d9bf2b857215b1472ef5f87d3f9217269437", AltText = "img-Saosin", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 89, Url = "https://i.scdn.co/image/61869fa6798976942ac131949bb83c3450a83bf0", AltText = "img-Two Birds EP", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 90, Url = "https://i.scdn.co/image/b02bafcfd35f14aa83aa74e4c6821d700dede39a", AltText = "img-Storybook", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 91, Url = "https://i.scdn.co/image/593cf12da738c1f8d14b315ebbd606d2fac72504", AltText = "img-Truman", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 92, Url = "https://i.scdn.co/image/4ab0c08489093f07fd7c9297f25b2cbe0587ffbd", AltText = "img-B-Sides It's Dark Outside", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 93, Url = "https://i.scdn.co/image/e28010a07d5cbdbb349b807e7a5261f5e335cdd5", AltText = "img-The Cowards Choir", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 94, Url = "https://i.scdn.co/image/6875f6d9c370543a3be74e4cf9dc19a4b499a115", AltText = "img-Muchacho de Lujo [Deluxe Edition]", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 95, Url = "https://i.scdn.co/image/a9452d1db4aa5bb234456628b60efc22effce236", AltText = "img-Habits Of My Heart EP", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 96, Url = "https://i.scdn.co/image/ed3fe376df10f6c1cd475f0b6d6d4f0546b29eec", AltText = "img-Aware", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 97, Url = "https://i.scdn.co/image/55e6c90a6971bce1d2838c2df728004371c44b61", AltText = "img-Little Giant", Width = 640, Height = 640 });
                //context.AlbumCovers.Add(new AlbumCover { AlbumCoverId = 98, Url = "https://i.scdn.co/image/bef9bc342984f439cfeb66366434dbfb61cb703a", AltText = "img-Metrics of Affection", Width = 640, Height = 640 });
                #endregion

                #region Albums
                //context.Albums.Add(new Album { AlbumId = 0, ArtistId = 0, Name = "The Book Of Love", SpotifyId = " 0N1btvaeNMojeaTbp5LQby", ReleaseDate = Convert.ToDateTime("3/6/2015 12:00:00 AM"), AlbumCoverId = 0 });
                //context.Albums.Add(new Album { AlbumId = 1, ArtistId = 1, Name = "JEKYLL + HYDE", SpotifyId = " 1xy141zMRluP7YaE94IawT", ReleaseDate = Convert.ToDateTime("4/28/2015 12:00:00 AM"), AlbumCoverId = 1 });
                //context.Albums.Add(new Album { AlbumId = 2, ArtistId = 2, Name = "The Historical Conquests of Josh Ritter", SpotifyId = " 40xscsIpyzlVZTBC5cDOFH", ReleaseDate = Convert.ToDateTime("8/21/2007 12:00:00 AM"), AlbumCoverId = 2 });
                //context.Albums.Add(new Album { AlbumId = 3, ArtistId = 3, Name = "I Don't Want To Change You", SpotifyId = " 5XjLh03TyuPPWZWMYQeExC", ReleaseDate = Convert.ToDateTime("9/24/2014 12:00:00 AM"), AlbumCoverId = 3 });
                //context.Albums.Add(new Album { AlbumId = 4, ArtistId = 4, Name = "Islands", SpotifyId = " 15z9H7eEOCtB2Xq28SDWwp", ReleaseDate = Convert.ToDateTime("10/21/2014 12:00:00 AM"), AlbumCoverId = 4 });
                //context.Albums.Add(new Album { AlbumId = 5, ArtistId = 5, Name = "Whispers II", SpotifyId = " 1tuA98Wr7drhpoaMqPIO5V", ReleaseDate = Convert.ToDateTime("4/20/2015 12:00:00 AM"), AlbumCoverId = 5 });
                //context.Albums.Add(new Album { AlbumId = 7, ArtistId = 7, Name = "Trouble", SpotifyId = " 2DQHgaOMVOs2OKLaksiMx9", ReleaseDate = Convert.ToDateTime("8/15/2004 12:00:00 AM"), AlbumCoverId = 7 });
                //context.Albums.Add(new Album { AlbumId = 8, ArtistId = 8, Name = "Drones", SpotifyId = " 2wart5Qjnvx1fd7LPdQxgJ", ReleaseDate = Convert.ToDateTime("6/4/2015 12:00:00 AM"), AlbumCoverId = 8 });
                //context.Albums.Add(new Album { AlbumId = 9, ArtistId = 9, Name = "Empty Days & Sleepless Nights", SpotifyId = " 21VSN8gsYIiT4XajInScc1", ReleaseDate = Convert.ToDateTime("3/8/2011 12:00:00 AM"), AlbumCoverId = 9 });
                //context.Albums.Add(new Album { AlbumId = 10, ArtistId = 10, Name = "Best I Never Had", SpotifyId = " 5fXNchpJ8jblaAsFQgVjLH", ReleaseDate = Convert.ToDateTime("3/23/2010 12:00:00 AM"), AlbumCoverId = 10 });
                //context.Albums.Add(new Album { AlbumId = 11, ArtistId = 5, Name = "Whispers (Deluxe)", SpotifyId = " 3WvSr7uc2MOaNgWDxNxLqJ", ReleaseDate = Convert.ToDateTime("6/6/2014 12:00:00 AM"), AlbumCoverId = 11 });
                //context.Albums.Add(new Album { AlbumId = 12, ArtistId = 12, Name = "Every Kingdom (Deluxe Version)", SpotifyId = " 2MxcbOGFi99D9JACvj74AH", ReleaseDate = Convert.ToDateTime("1/1/2011 12:00:00 AM"), AlbumCoverId = 12 });
                //context.Albums.Add(new Album { AlbumId = 14, ArtistId = 14, Name = "For Emma, Forever Ago", SpotifyId = " 2wBGb1zLSWrmiOdinWE831", ReleaseDate = Convert.ToDateTime("7/8/2007 12:00:00 AM"), AlbumCoverId = 14 });
                //context.Albums.Add(new Album { AlbumId = 15, ArtistId = 15, Name = "x (Deluxe Edition)", SpotifyId = " 1xn54DMo2qIqBuMqHtUsFd", ReleaseDate = Convert.ToDateTime("6/21/2014 12:00:00 AM"), AlbumCoverId = 15 });
                //context.Albums.Add(new Album { AlbumId = 16, ArtistId = 16, Name = "Silver Lining", SpotifyId = " 5U017xFzIEof40cTb7Z1SF", ReleaseDate = Convert.ToDateTime("5/20/2011 12:00:00 AM"), AlbumCoverId = 16 });
                //context.Albums.Add(new Album { AlbumId = 18, ArtistId = 18, Name = "Vagabond", SpotifyId = " 0wnmzxrNPbDrffxcDs2yII", ReleaseDate = Convert.ToDateTime("7/11/2014 12:00:00 AM"), AlbumCoverId = 18 });
                //context.Albums.Add(new Album { AlbumId = 19, ArtistId = 19, Name = "Barton Hollow", SpotifyId = " 3GtyVMEnfmc3rl8pTYBJqi", ReleaseDate = Convert.ToDateTime("3/2/2012 12:00:00 AM"), AlbumCoverId = 19 });
                //context.Albums.Add(new Album { AlbumId = 21, ArtistId = 21, Name = "Hozier", SpotifyId = " 04E0aLUdCHnhnnYrDDvcHq", ReleaseDate = Convert.ToDateTime("10/7/2014 12:00:00 AM"), AlbumCoverId = 21 });
                //context.Albums.Add(new Album { AlbumId = 22, ArtistId = 22, Name = "Best Of", SpotifyId = " 6471rrLPKqZgXQ6TqN5AgU", ReleaseDate = Convert.ToDateTime("1/1/2010 12:00:00 AM"), AlbumCoverId = 22 });
                //context.Albums.Add(new Album { AlbumId = 23, ArtistId = 8, Name = "Dead Inside", SpotifyId = " 6p5gd9wYS8TAHQgc6HVuAf", ReleaseDate = Convert.ToDateTime("3/23/2015 12:00:00 AM"), AlbumCoverId = 23 });
                //context.Albums.Add(new Album { AlbumId = 24, ArtistId = 24, Name = "Whatever And Ever Amen (Remastered Edition)", SpotifyId = " 3oz8kworUyU7oXjaEVhDsZ", ReleaseDate = Convert.ToDateTime("2/10/1997 12:00:00 AM"), AlbumCoverId = 24 });
                //context.Albums.Add(new Album { AlbumId = 25, ArtistId = 25, Name = "Villains", SpotifyId = " 3sV3CL42DZ8C11MuQwVUEi", ReleaseDate = Convert.ToDateTime("3/25/1996 12:00:00 AM"), AlbumCoverId = 25 });
                //context.Albums.Add(new Album { AlbumId = 26, ArtistId = 26, Name = "Rotten Apples, The Smashing Pumpkins Greatest Hits", SpotifyId = " 1cUnNrx2TxvrpwPRtvpGwn", ReleaseDate = Convert.ToDateTime("11/20/2001 12:00:00 AM"), AlbumCoverId = 26 });
                //context.Albums.Add(new Album { AlbumId = 27, ArtistId = 27, Name = "Californication (Deluxe Version)", SpotifyId = " 2Y9IRtehByVkegoD7TcLfi", ReleaseDate = Convert.ToDateTime("6/8/1999 12:00:00 AM"), AlbumCoverId = 27 });
                //context.Albums.Add(new Album { AlbumId = 28, ArtistId = 28, Name = "Siren Song Of The Counter-Culture", SpotifyId = " 1vHYkIhnwbpzrC3hGguDN6", ReleaseDate = Convert.ToDateTime("1/1/2004 12:00:00 AM"), AlbumCoverId = 28 });
                //context.Albums.Add(new Album { AlbumId = 29, ArtistId = 29, Name = "Candy", SpotifyId = " 3QykM79uWpxMEc3e29D711", ReleaseDate = Convert.ToDateTime("11/10/2014 12:00:00 AM"), AlbumCoverId = 29 });
                //context.Albums.Add(new Album { AlbumId = 30, ArtistId = 30, Name = "The Best Of Queensryche (Deluxe Edition)", SpotifyId = " 2aeeuAwAoszbv0YkEscAFx", ReleaseDate = Convert.ToDateTime("8/28/2007 12:00:00 AM"), AlbumCoverId = 30 });
                //context.Albums.Add(new Album { AlbumId = 31, ArtistId = 31, Name = "America Town", SpotifyId = " 5MqEXYwwyJYjOb3g7vJ9ZY", ReleaseDate = Convert.ToDateTime("9/26/2000 12:00:00 AM"), AlbumCoverId = 31 });
                //context.Albums.Add(new Album { AlbumId = 32, ArtistId = 32, Name = "Communion", SpotifyId = " 4UEwyWgDZ9V7WgNRqD0Etx", ReleaseDate = Convert.ToDateTime("7/10/2015 12:00:00 AM"), AlbumCoverId = 32 });
                //context.Albums.Add(new Album { AlbumId = 34, ArtistId = 34, Name = "An American Love Story", SpotifyId = " 0P2UzaCywB5aWhIplMUryK", ReleaseDate = Convert.ToDateTime("8/10/1999 12:00:00 AM"), AlbumCoverId = 34 });
                //context.Albums.Add(new Album { AlbumId = 35, ArtistId = 32, Name = "Communion (Deluxe)", SpotifyId = " 50jDQcZjE2kdx5rn3AL0c8", ReleaseDate = Convert.ToDateTime("7/10/2015 12:00:00 AM"), AlbumCoverId = 35 });
                //context.Albums.Add(new Album { AlbumId = 37, ArtistId = 15, Name = "+", SpotifyId = " 02pi98kE0nra0yBqCStzbC", ReleaseDate = Convert.ToDateTime("9/9/2011 12:00:00 AM"), AlbumCoverId = 37 });
                //context.Albums.Add(new Album { AlbumId = 43, ArtistId = 4, Name = "Without/Within", SpotifyId = " 5IbjvCuVMchAsoXKOvVrof", ReleaseDate = Convert.ToDateTime("10/28/2013 12:00:00 AM"), AlbumCoverId = 43 });
                //context.Albums.Add(new Album { AlbumId = 45, ArtistId = 45, Name = "The Definitive Collection", SpotifyId = " 7qF9HEA57AL9dPGlipcDvF", ReleaseDate = Convert.ToDateTime("1/29/2013 12:00:00 AM"), AlbumCoverId = 45 });
                //context.Albums.Add(new Album { AlbumId = 50, ArtistId = 50, Name = "In Retrospect", SpotifyId = " 3cFKgcv6a3IhNw7f4qfVrw", ReleaseDate = Convert.ToDateTime("5/5/2011 12:00:00 AM"), AlbumCoverId = 50 });
                //context.Albums.Add(new Album { AlbumId = 52, ArtistId = 52, Name = "First Mind", SpotifyId = " 0ntJpgznXrZ6Qc8wTxtcXh", ReleaseDate = Convert.ToDateTime("5/12/2014 12:00:00 AM"), AlbumCoverId = 52 });
                //context.Albums.Add(new Album { AlbumId = 53, ArtistId = 53, Name = "Pablo Honey [Collector's Edition]", SpotifyId = " 6AZv3m27uyRxi8KyJSfUxL", ReleaseDate = Convert.ToDateTime("4/23/1993 12:00:00 AM"), AlbumCoverId = 53 });
                //context.Albums.Add(new Album { AlbumId = 55, ArtistId = 55, Name = "Michigan", SpotifyId = " 4mIfqTE8DOnFRFWUQH02Og", ReleaseDate = Convert.ToDateTime("7/1/2003 12:00:00 AM"), AlbumCoverId = 55 });
                //context.Albums.Add(new Album { AlbumId = 56, ArtistId = 55, Name = "Seven Swans", SpotifyId = " 71M94qZwSYHxlae0EFxpsy", ReleaseDate = Convert.ToDateTime("3/16/2004 12:00:00 AM"), AlbumCoverId = 56 });
                //context.Albums.Add(new Album { AlbumId = 57, ArtistId = 57, Name = "Emotionalism", SpotifyId = " 2ktxUTtc7FIpTH3vN70NZm", ReleaseDate = Convert.ToDateTime("5/15/2007 12:00:00 AM"), AlbumCoverId = 57 });
                //context.Albums.Add(new Album { AlbumId = 58, ArtistId = 57, Name = "The Second Gleam", SpotifyId = " 12Rp5bkZ5iX3URHnhaV3fy", ReleaseDate = Convert.ToDateTime("7/22/2008 12:00:00 AM"), AlbumCoverId = 58 });
                //context.Albums.Add(new Album { AlbumId = 59, ArtistId = 59, Name = "Jamie Lawson", SpotifyId = " 7qrYgKHSH8bIE5gSqXD5pR", ReleaseDate = Convert.ToDateTime("10/16/2015 12:00:00 AM"), AlbumCoverId = 59 });
                //context.Albums.Add(new Album { AlbumId = 60, ArtistId = 60, Name = "Resolution", SpotifyId = " 4tdzAgo7pkWfip1jSWtXZ8", ReleaseDate = Convert.ToDateTime("7/10/2013 12:00:00 AM"), AlbumCoverId = 60 });
                //context.Albums.Add(new Album { AlbumId = 61, ArtistId = 60, Name = "Into The Flame", SpotifyId = " 32TZZ9ZjC7EFFMYQxf3jYa", ReleaseDate = Convert.ToDateTime("11/16/2012 12:00:00 AM"), AlbumCoverId = 61 });
                //context.Albums.Add(new Album { AlbumId = 63, ArtistId = 63, Name = "Where We Land", SpotifyId = " 2TUwNtx2IHTlI893tFbuo1", ReleaseDate = Convert.ToDateTime("8/18/2007 12:00:00 AM"), AlbumCoverId = 63 });
                //context.Albums.Add(new Album { AlbumId = 64, ArtistId = 64, Name = "Chasing Rubies", SpotifyId = " 1PhDRrqg3pfj14hJ8YZjkX", ReleaseDate = Convert.ToDateTime("8/6/2013 12:00:00 AM"), AlbumCoverId = 64 });
                //context.Albums.Add(new Album { AlbumId = 65, ArtistId = 65, Name = "She Never Sleeps", SpotifyId = " 3Ii9Qw8DEJAT9lrFfHU0Lw", ReleaseDate = Convert.ToDateTime("9/6/2012 12:00:00 AM"), AlbumCoverId = 65 });
                //context.Albums.Add(new Album { AlbumId = 66, ArtistId = 66, Name = "Flamingo", SpotifyId = " 7zKxFkMyehmw9u3MhLpMPK", ReleaseDate = Convert.ToDateTime("1/1/2010 12:00:00 AM"), AlbumCoverId = 66 });
                //context.Albums.Add(new Album { AlbumId = 67, ArtistId = 67, Name = "Nick Jonas X2", SpotifyId = " 4G4Azv5cwPBv3vCA0mD6ei", ReleaseDate = Convert.ToDateTime("11/20/2015 12:00:00 AM"), AlbumCoverId = 67 });
                //context.Albums.Add(new Album { AlbumId = 68, ArtistId = 67, Name = "Jealous", SpotifyId = " 5nPBVVe9BU2LhAskz2mfv2", ReleaseDate = Convert.ToDateTime("9/8/2014 12:00:00 AM"), AlbumCoverId = 68 });
                //context.Albums.Add(new Album { AlbumId = 69, ArtistId = 69, Name = "Is There Anybody Out There?", SpotifyId = " 1yOcLa4euMk9sV7rRJ89Dl", ReleaseDate = Convert.ToDateTime("1/17/2014 12:00:00 AM"), AlbumCoverId = 69 });
                //context.Albums.Add(new Album { AlbumId = 70, ArtistId = 70, Name = "Tenboom", SpotifyId = " 2cVOSmXfC0wZBoj7TmpZl7", ReleaseDate = Convert.ToDateTime("1/8/2013 12:00:00 AM"), AlbumCoverId = 70 });
                //context.Albums.Add(new Album { AlbumId = 71, ArtistId = 71, Name = "The Shipwreck From The Shore", SpotifyId = " 2Qgr6jCKL8wNL2guAKcH5b", ReleaseDate = Convert.ToDateTime("9/2/2014 12:00:00 AM"), AlbumCoverId = 71 });
                //context.Albums.Add(new Album { AlbumId = 72, ArtistId = 72, Name = "The Boy Who Never", SpotifyId = " 1fFFfcxhKi0kSPhm8kdOuf", ReleaseDate = Convert.ToDateTime("9/24/2009 12:00:00 AM"), AlbumCoverId = 72 });
                //context.Albums.Add(new Album { AlbumId = 73, ArtistId = 73, Name = "Where the Mountain Meets the Valley", SpotifyId = " 5edOmr4NvYttuaSL8i2YbZ", ReleaseDate = Convert.ToDateTime("5/15/2012 12:00:00 AM"), AlbumCoverId = 73 });
                //context.Albums.Add(new Album { AlbumId = 74, ArtistId = 74, Name = "Promises", SpotifyId = " 3BknnUoNzGzkUQQUA78AfK", ReleaseDate = Convert.ToDateTime("5/10/2013 12:00:00 AM"), AlbumCoverId = 74 });
                //context.Albums.Add(new Album { AlbumId = 75, ArtistId = 75, Name = "Reach For The Sun", SpotifyId = " 13Zqbq7TFA0zOHrK4ZLO9J", ReleaseDate = Convert.ToDateTime("5/5/2009 12:00:00 AM"), AlbumCoverId = 75 });
                //context.Albums.Add(new Album { AlbumId = 76, ArtistId = 76, Name = "Hot Fuss", SpotifyId = " 4undIeGmofnAYKhnDclN1w", ReleaseDate = Convert.ToDateTime("1/1/2004 12:00:00 AM"), AlbumCoverId = 76 });
                //context.Albums.Add(new Album { AlbumId = 78, ArtistId = 76, Name = "Sam's Town", SpotifyId = " 4o3RJndRhHxkieQzQGhmbw", ReleaseDate = Convert.ToDateTime("10/2/2006 12:00:00 AM"), AlbumCoverId = 78 });
                //context.Albums.Add(new Album { AlbumId = 80, ArtistId = 76, Name = "Day & Age", SpotifyId = " 7FuhgOwoael0fsg9zjZxog", ReleaseDate = Convert.ToDateTime("1/1/2008 12:00:00 AM"), AlbumCoverId = 80 });
                //context.Albums.Add(new Album { AlbumId = 81, ArtistId = 81, Name = "Immortalized", SpotifyId = " 3qFQ4XNQ15alZrAaj5oGJK", ReleaseDate = Convert.ToDateTime("8/21/2015 12:00:00 AM"), AlbumCoverId = 81 });
                //context.Albums.Add(new Album { AlbumId = 82, ArtistId = 82, Name = "Twin Forks", SpotifyId = " 0cYBxtmLvhPfswriLL3um2", ReleaseDate = Convert.ToDateTime("2/25/2014 12:00:00 AM"), AlbumCoverId = 82 });
                //context.Albums.Add(new Album { AlbumId = 83, ArtistId = 83, Name = "Chaos And The Calm", SpotifyId = " 5BxvswQSGWrBbVCdx6mFGO", ReleaseDate = Convert.ToDateTime("12/15/2014 12:00:00 AM"), AlbumCoverId = 83 });
                //context.Albums.Add(new Album { AlbumId = 84, ArtistId = 84, Name = "Vision", SpotifyId = " 7c9MUVV44xJd14HgW0PVYm", ReleaseDate = Convert.ToDateTime("5/12/2015 12:00:00 AM"), AlbumCoverId = 84 });
                //context.Albums.Add(new Album { AlbumId = 86, ArtistId = 86, Name = "Sweeter", SpotifyId = " 2zVRgW8bXd7ukXRZSWw81j", ReleaseDate = Convert.ToDateTime("9/16/2011 12:00:00 AM"), AlbumCoverId = 86 });
                //context.Albums.Add(new Album { AlbumId = 88, ArtistId = 88, Name = "Saosin", SpotifyId = " 2osTPStH5H7i4fMHS7eauR", ReleaseDate = Convert.ToDateTime("9/26/2006 12:00:00 AM"), AlbumCoverId = 88 });
                //context.Albums.Add(new Album { AlbumId = 89, ArtistId = 89, Name = "Two Birds EP", SpotifyId = " 76gPuKkCjZbBXKS9nfWL6Y", ReleaseDate = Convert.ToDateTime("8/26/2013 12:00:00 AM"), AlbumCoverId = 89 });
                //context.Albums.Add(new Album { AlbumId = 90, ArtistId = 90, Name = "Storybook", SpotifyId = " 6nsOTGBDZZcb0xP1z4NuTV", ReleaseDate = Convert.ToDateTime("3/30/2014 12:00:00 AM"), AlbumCoverId = 90 });
                //context.Albums.Add(new Album { AlbumId = 91, ArtistId = 91, Name = "Truman", SpotifyId = " 0KJQ4tvWWp04IMvFGHNSAn", ReleaseDate = Convert.ToDateTime("7/20/2012 12:00:00 AM"), AlbumCoverId = 91 });
                //context.Albums.Add(new Album { AlbumId = 92, ArtistId = 92, Name = "B-Sides It's Dark Outside", SpotifyId = " 222HutTUce1KlGv3qSnwTI", ReleaseDate = Convert.ToDateTime("1/1/2006 12:00:00 AM"), AlbumCoverId = 92 });
                //context.Albums.Add(new Album { AlbumId = 93, ArtistId = 93, Name = "The Cowards Choir", SpotifyId = " 2AdNq7duQAXz1Jriimwx9G", ReleaseDate = Convert.ToDateTime("7/1/2009 12:00:00 AM"), AlbumCoverId = 93 });
                //context.Albums.Add(new Album { AlbumId = 94, ArtistId = 94, Name = "Muchacho de Lujo [Deluxe Edition]", SpotifyId = " 5MjoNQ2MOoFZFTTYNlT5x2", ReleaseDate = Convert.ToDateTime("10/25/2013 12:00:00 AM"), AlbumCoverId = 94 });
                //context.Albums.Add(new Album { AlbumId = 95, ArtistId = 95, Name = "Habits Of My Heart EP", SpotifyId = " 7c4oC2FhDzwu7XU7XRB4lZ", ReleaseDate = Convert.ToDateTime("9/28/2014 12:00:00 AM"), AlbumCoverId = 95 });
                //context.Albums.Add(new Album { AlbumId = 96, ArtistId = 96, Name = "Aware", SpotifyId = " 7f9GLwM6FgxoyehG3XT3lq", ReleaseDate = Convert.ToDateTime("11/12/2013 12:00:00 AM"), AlbumCoverId = 96 });
                //context.Albums.Add(new Album { AlbumId = 97, ArtistId = 97, Name = "Little Giant", SpotifyId = " 7fqZrcQ53NpZugjmXHtLK3", ReleaseDate = Convert.ToDateTime("10/6/2014 12:00:00 AM"), AlbumCoverId = 97 });
                //context.Albums.Add(new Album { AlbumId = 98, ArtistId = 98, Name = "Metrics of Affection", SpotifyId = " 334Uk4L4aNU8d1yjVu9Vmz", ReleaseDate = Convert.ToDateTime("7/23/2013 12:00:00 AM"), AlbumCoverId = 98 });
                #endregion

                #region Tracks
                //context.Tracks.Add(new Track { TrackId = 0, ArtistId = 0, AlbumId = 0,/**/ Name = "The Book Of Love", SpotifyId = "25tMQOrIU4LlUo6Sv8v5SE"                                            /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 1, ArtistId = 1, AlbumId = 1,/**/ Name = "Tomorrow Never Comes - (Acoustic Version)", SpotifyId = "6yJCxee7QumYr820xdIsjo"                   /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 2, ArtistId = 2, AlbumId = 2,/**/ Name = "The Temptation of Adam", SpotifyId = "6igfLpd8s6DBBAuwebRUuo"                                      /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 3, ArtistId = 3, AlbumId = 3,/**/ Name = "I Don't Want To Change You", SpotifyId = "14r9dR01KeBLFfylVSKCZQ"                                  /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 4, ArtistId = 4, AlbumId = 4,/**/ Name = "Above The Clouds Of Pompeii", SpotifyId = "0nJaMZM8paoA5HEUTUXPqi"                                 /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 5, ArtistId = 5, AlbumId = 5,/**/ Name = "The Way That I Need You", SpotifyId = "0gadJ2b9A4SKsB1RFkBb66"                                     /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 7, ArtistId = 7, AlbumId = 7,/**/ Name = "Jolene", SpotifyId = "6DoH7ywD5BcQvjloe9OcIj"                                                      /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 8, ArtistId = 8, AlbumId = 8,/**/ Name = "Mercy", SpotifyId = "12Chz98pHFMPJEknJQMWvI"                                                       /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 9, ArtistId = 9, AlbumId = 9,/**/ Name = "I Don't Mind", SpotifyId = "1L3hqVCHSL1Ajy3m0z1bAT"                                                /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 10, ArtistId = 10, AlbumId = 10,/**/ Name = "I Just Wanna Run", SpotifyId = "7MRDkEKtdsGcYn11A4qgUL"                                            /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 11, ArtistId = 5, AlbumId = 11,/**/ Name = "Coins in a Fountain", SpotifyId = "0gadJ2b9A4SKsB1RFkBb66"                                         /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 12, ArtistId = 12, AlbumId = 12,/**/ Name = "Old Pine", SpotifyId = "5schNIzWdI9gJ1QRK8SBnc"                                                    /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 14, ArtistId = 14, AlbumId = 14,/**/ Name = "Skinny Love", SpotifyId = "4LEiUm1SRbFMgfqnQTwUbQ"                                                 /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 15, ArtistId = 15, AlbumId = 15,/**/ Name = "I See Fire", SpotifyId = "6eUKZXaKkcviH0Ku9w2n3V"                                                  /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 16, ArtistId = 16, AlbumId = 16,/**/ Name = "Higher Love", SpotifyId = "7FDlvgcodNfC0IBdWevl4u"                                                 /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 18, ArtistId = 18, AlbumId = 18,/**/ Name = "Thirteen Sad Farewells", SpotifyId = "44M8i4BCwuBbmcQWwMaOfH"                                      /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 19, ArtistId = 19, AlbumId = 19,/**/ Name = "Barton Hollow", SpotifyId = "6J7rw7NELJUCThPbAfyLIE"                                               /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 21, ArtistId = 21, AlbumId = 21,/**/ Name = "Take Me to Church", SpotifyId = "2FXC3k01G6Gw61bmprjgqS"                                           /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 22, ArtistId = 22, AlbumId = 22,/**/ Name = "The Reason", SpotifyId = "2MqhkhX4npxDZ62ObR5ELO"                                                  /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 23, ArtistId = 8, AlbumId = 23,/**/ Name = "Dead Inside", SpotifyId = "12Chz98pHFMPJEknJQMWvI"                                                 /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 24, ArtistId = 24, AlbumId = 24,/**/ Name = "Brick", SpotifyId = "44gRHbEm4Uqa0ykW0rDTNk"                                                       /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 25, ArtistId = 25, AlbumId = 25,/**/ Name = "The Freshmen", SpotifyId = "242iqFnwNhlidVBMI9GYKp"                                                /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 26, ArtistId = 26, AlbumId = 26,/**/ Name = "Landslide", SpotifyId = "40Yq4vzPs9VNUrIBG5Jr2i"                                                   /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 27, ArtistId = 27, AlbumId = 27,/**/ Name = "Californication", SpotifyId = "0L8ExT028jH3ddEcZwqJJ5"                                             /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 28, ArtistId = 28, AlbumId = 28,/**/ Name = "Swing Life Away", SpotifyId = "6Wr3hh341P84m3EI8qdn9O"                                             /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 29, ArtistId = 29, AlbumId = 29,/**/ Name = "Electric Love", SpotifyId = "1KP6TWI40m7p3QBTU6u2xo"                                               /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 30, ArtistId = 30, AlbumId = 30,/**/ Name = "Silent Lucidity", SpotifyId = "2OgUPVlWYgGBGMefZgGvCO"                                             /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 31, ArtistId = 31, AlbumId = 31,/**/ Name = "Superman (It's Not Easy) - New Album Version", SpotifyId = "7FgMLbnZVrEnir95O0YujA"                /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 32, ArtistId = 32, AlbumId = 32,/**/ Name = "King", SpotifyId = "5vBSrE1xujD2FXYRarbAXc"                                                        /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 34, ArtistId = 34, AlbumId = 34,/**/ Name = "My Girl", SpotifyId = "3RwQ26hR2tJtA8F9p2n7jG"                                                     /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 35, ArtistId = 32, AlbumId = 35,/**/ Name = "Take Shelter", SpotifyId = "5vBSrE1xujD2FXYRarbAXc"                                                /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 36, ArtistId = 15, AlbumId = 15,/**/ Name = "Tenerife Sea", SpotifyId = "6eUKZXaKkcviH0Ku9w2n3V"                                                /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 37, ArtistId = 15, AlbumId = 37,/**/ Name = "U.N.I.", SpotifyId = "6eUKZXaKkcviH0Ku9w2n3V"                                                      /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 38, ArtistId = 15, AlbumId = 37,/**/ Name = "Autumn Leaves - Deluxe Edition", SpotifyId = "6eUKZXaKkcviH0Ku9w2n3V"                              /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 39, ArtistId = 15, AlbumId = 37,/**/ Name = "Lego House", SpotifyId = "6eUKZXaKkcviH0Ku9w2n3V"                                                  /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 40, ArtistId = 5, AlbumId = 5, /**/ Name = "Travelling Alone", SpotifyId = "0gadJ2b9A4SKsB1RFkBb66"                                            /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 41, ArtistId = 5, AlbumId = 5, /**/ Name = "David", SpotifyId = "0gadJ2b9A4SKsB1RFkBb66"                                                       /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 42, ArtistId = 5, AlbumId = 11,/**/ Name = "Heart's On Fire - Acoustic", SpotifyId = "0gadJ2b9A4SKsB1RFkBb66"                                  /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 43, ArtistId = 4, AlbumId = 43,/**/ Name = "Sophie", SpotifyId = "0nJaMZM8paoA5HEUTUXPqi"                                                      /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 45, ArtistId = 45, AlbumId = 45,/**/ Name = "Comeback Kid (That's My Dog)", SpotifyId = "0FC1LIeQXKib0jOwZqeIwT"                                /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 50, ArtistId = 50, AlbumId = 50,/**/ Name = "Veterans Day", SpotifyId = "6vMmqaauubP4qBujCf6DPY"                                                /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 51, ArtistId = 50, AlbumId = 50,/**/ Name = "Personal Rockstar", SpotifyId = "6vMmqaauubP4qBujCf6DPY"                                           /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 52, ArtistId = 52, AlbumId = 52,/**/ Name = "I Don't Want To Go Home", SpotifyId = "3x8FbPjh2Qz55XMdE2Yalj"                                     /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 53, ArtistId = 53, AlbumId = 53,/**/ Name = "Creep - Acoustic", SpotifyId = "4Z8W4fKeB5YxbusRsdQVPb"                                            /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 54, ArtistId = 18, AlbumId = 18,/**/ Name = "San Francisco", SpotifyId = "44M8i4BCwuBbmcQWwMaOfH"                                               /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 55, ArtistId = 55, AlbumId = 55,/**/ Name = "For the Widows in Paradise, For the Fatherless in Ypsilanti", SpotifyId = "4MXUO7sVCaFgFjoTI5ox5c" /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 56, ArtistId = 55, AlbumId = 56,/**/ Name = "To Be Alone With You", SpotifyId = "4MXUO7sVCaFgFjoTI5ox5c"                                        /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 57, ArtistId = 57, AlbumId = 57,/**/ Name = "The Ballad Of Love And Hate", SpotifyId = "196lKsA13K3keVXMDFK66q"                                 /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 58, ArtistId = 57, AlbumId = 58,/**/ Name = "Murder in the City", SpotifyId = "196lKsA13K3keVXMDFK66q"                                          /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 59, ArtistId = 59, AlbumId = 59,/**/ Name = "Wasn't Expecting That", SpotifyId = "1jhdZdzOd4TJLAHqQdkUND"                                       /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 60, ArtistId = 60, AlbumId = 60,/**/ Name = "Resolution", SpotifyId = "7CIW23FQUXPc1zebnO1TDG"                                                  /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 61, ArtistId = 60, AlbumId = 61,/**/ Name = "Untitled", SpotifyId = "7CIW23FQUXPc1zebnO1TDG"                                                    /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 62, ArtistId = 60, AlbumId = 61,/**/ Name = "Brother", SpotifyId = "7CIW23FQUXPc1zebnO1TDG"                                                     /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 63, ArtistId = 63, AlbumId = 63,/**/ Name = "Beautiful", SpotifyId = "5XVcYaeSTGZXwxd63aY9Tv"                                                   /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 64, ArtistId = 64, AlbumId = 64,/**/ Name = "Chasing Rubies - Acoustic", SpotifyId = "4DX2G1URzfEiRg2wBfv4ub"                                   /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 65, ArtistId = 65, AlbumId = 65,/**/ Name = "Brooklyn Raining", SpotifyId = "1f2CFEq5J7ZyeTAVU6ubRX"                                            /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 66, ArtistId = 66, AlbumId = 66,/**/ Name = "Crossfire", SpotifyId = "18Zv2g2vUcEGqJf6WnjfXN"                                                   /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 67, ArtistId = 67, AlbumId = 67,/**/ Name = "Chains", SpotifyId = "4Rxn7Im3LGfyRkY2FlHhWi"                                                      /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 68, ArtistId = 67, AlbumId = 68,/**/ Name = "Jealous", SpotifyId = "4Rxn7Im3LGfyRkY2FlHhWi"                                                     /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 69, ArtistId = 69, AlbumId = 69,/**/ Name = "Say Something", SpotifyId = "5xKp3UyavIBUsGy3DQdXeF"                                               /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 70, ArtistId = 70, AlbumId = 70,/**/ Name = "Brothers", SpotifyId = "65o6y7GtoXzchyiJB3r9Ur"                                                    /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 71, ArtistId = 71, AlbumId = 71,/**/ Name = "If It Don't Work Out", SpotifyId = "1oplL2hHYq7CQykvSbd6gy"                                        /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 72, ArtistId = 72, AlbumId = 72,/**/ Name = "Falling in Love at a Coffee Shop", SpotifyId = "1whjlG0NSaQytgDIWz10GS"                            /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 73, ArtistId = 73, AlbumId = 73,/**/ Name = "Do Not Let Me Go", SpotifyId = "1I7oHjCjMrMUz66v67yJJu"                                            /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 74, ArtistId = 74, AlbumId = 74,/**/ Name = "New York", SpotifyId = "7DEseTqRODmSu3C7jxCHl5"                                                    /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 75, ArtistId = 75, AlbumId = 75,/**/ Name = "The Permanent Rain", SpotifyId = "0iMnpaEHXkgMT956CmP1kj"                                          /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 76, ArtistId = 76, AlbumId = 76,/**/ Name = "Mr. Brightside", SpotifyId = "0C0XlULifJtAgn6ZNCW2eu"                                              /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 77, ArtistId = 76, AlbumId = 76,/**/ Name = "Somebody Told Me", SpotifyId = "0C0XlULifJtAgn6ZNCW2eu"                                            /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 78, ArtistId = 76, AlbumId = 78,/**/ Name = "When You Were Young", SpotifyId = "0C0XlULifJtAgn6ZNCW2eu"                                         /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 79, ArtistId = 76, AlbumId = 76,/**/ Name = "All These Things That I've Done", SpotifyId = "0C0XlULifJtAgn6ZNCW2eu"                             /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 80, ArtistId = 76, AlbumId = 80,/**/ Name = "Human", SpotifyId = "0C0XlULifJtAgn6ZNCW2eu"                                                       /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 81, ArtistId = 81, AlbumId = 81,/**/ Name = "The Sound Of Silence", SpotifyId = "3TOqt5oJwL9BE2NG9MEwDa"                                        /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 82, ArtistId = 82, AlbumId = 82,/**/ Name = "Back To You", SpotifyId = "6GwNGuDRNbx5XwoHQA3QiD"                                                 /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 83, ArtistId = 83, AlbumId = 83,/**/ Name = "Let It Go", SpotifyId = "4EzkuveR9pLvDVFNx6foYD"                                                   /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 84, ArtistId = 84, AlbumId = 84,/**/ Name = "Lost Tonight", SpotifyId = "0F55dmw0A9gnYhgJfH0b3b"                                                /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 85, ArtistId = 32, AlbumId = 35,/**/ Name = "King - Acoustic", SpotifyId = "5vBSrE1xujD2FXYRarbAXc"                                             /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 86, ArtistId = 86, AlbumId = 86,/**/ Name = "Run Every Time", SpotifyId = "5DYAABs8rkY9VhwtENoQCz"                                              /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 88, ArtistId = 88, AlbumId = 88,/**/ Name = "You're Not Alone", SpotifyId = "1NUOfvAhA9AvsF1ISMkgHX"                                            /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 89, ArtistId = 89, AlbumId = 89,/**/ Name = "The Rules for Lovers", SpotifyId = "3rUqgY188kWz0hKkqnpk9F"                                        /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 90, ArtistId = 90, AlbumId = 90,/**/ Name = "Storybook", SpotifyId = "405DvLr0FOuOWYgCt0emff"                                                   /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 91, ArtistId = 91, AlbumId = 91,/**/ Name = "Love During Wartime", SpotifyId = "2knI8PaBy2UyrRBhGmBbQJ"                                         /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 92, ArtistId = 92, AlbumId = 92,/**/ Name = "Lovers Without Love", SpotifyId = "0YLUOdFiedWIWBttlDAQeO"                                         /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 93, ArtistId = 93, AlbumId = 93,/**/ Name = "I'd Sing Hallelujah", SpotifyId = "5gj2Ul170gSipbsNQbea37"                                         /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 94, ArtistId = 94, AlbumId = 94,/**/ Name = "Song For Zula - Live at St. Pancras Church", SpotifyId = "57kIMCLPgkzQlXjblX7XXP"                  /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 95, ArtistId = 95, AlbumId = 95,/**/ Name = "Moondust (Stripped)", SpotifyId = "6QrQ7OrISRYIfS5mtacaw2"                                         /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 96, ArtistId = 96, AlbumId = 96,/**/ Name = "If I Tremble", SpotifyId = "4UXiNDHAiv8DOSLkp0GbSm"                                                /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 97, ArtistId = 97, AlbumId = 97,/**/ Name = "Home From Home", SpotifyId = "0XHM5ZNJDU8e4CfbWMeSzC"                                              /**/ , CanPlay = false, DurationMs = 20000 });
                //context.Tracks.Add(new Track { TrackId = 98, ArtistId = 98, AlbumId = 98,/**/ Name = "Thank You", SpotifyId = "6AlXfeCNG9lrauBDG7GyjM"                                                   /**/ , CanPlay = false, DurationMs = 20000 });          /**/
                //context.Tracks.Add(new Track { TrackId = 99, ArtistId = 96, AlbumId = 96,/**/ Name = "Island of the Misfit Boy", SpotifyId = "4UXiNDHAiv8DOSLkp0GbSm"                                    /**/ , CanPlay = false, DurationMs = 20000 });
                #endregion



                //context.Keywords.Add(new Keyword { KeywordId = 0, KeywordText = "Happy" });
                //context.Keywords.Add(new Keyword { KeywordId = 1, KeywordText = "Sad" });
                //context.Keywords.Add(new Keyword { KeywordId = 2, KeywordText = "Angry" });
                //context.Keywords.Add(new Keyword { KeywordId = 3, KeywordText = "Mad" });
                //context.Keywords.Add(new Keyword { KeywordId = 4, KeywordText = "Mad" });

                //context.Topics.Add(new Topic { TopicId = 0, Text = "Losing someone special" });
                //context.Topics.Add(new Topic { TopicId = 0, Text = "Getting Married" });
                //context.Topics.Add(new Topic { TopicId = 0, Text = "Losing someone special" });

                //foreach (var ar in context.Artists.Take(20))
                //{
                //    SaEntity.AutoCompleteResults.Add(new AutoCompleteResult { SaEntityId = ar.Id, SaEntityType = ar.EntityType, Text = ar.Name });
                //}
                //foreach (var al in context.Albums)
                //{
                //    SaEntity.AutoCompleteResults.Add(new AutoCompleteResult { SaEntityId = al.Id, SaEntityType = al.EntityType, Text = al.Name });
                //}
                //foreach (var t in context.Tracks)
                //{
                //    SaEntity.AutoCompleteResults.Add(new AutoCompleteResult { SaEntityId = t.Id, SaEntityType = t.EntityType, Text = t.Name });
                //}
                //foreach (var k in context.Keywords)
                //{
                //    SaEntity.AutoCompleteResults.Add(new AutoCompleteResult { SaEntityId = k.Id, SaEntityType = k.EntityType, Text = k.Name });
                //}

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
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}