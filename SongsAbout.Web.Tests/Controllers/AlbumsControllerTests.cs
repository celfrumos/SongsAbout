using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongsAbout.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Telerik.JustMock;
using Telerik.JustMock.EntityFramework;
using System.Web.Mvc;

namespace SongsAbout.Web.Controllers.Tests
{
    [TestClass]
    public class AlbumsControllerTests
    {



        [TestMethod]
        public void AddProfilePicsAndArtistsDoesntThrowError()
        {
            try
            {

                using (var context = EntityFrameworkMock.Create<EntityDbContext>())
                {
                    context.ProfilePics.Add(new ProfilePic { ProfilePicId = 0, Url = "https://i.scdn.co/image/b0b295beeb9c89c5060f9f08f9c0de55d00aad0a", AltText = "img-Gavin James", Width = 640, Height = 640 });
                    context.ProfilePics.Add(new ProfilePic { ProfilePicId = 1, Url = "https://i.scdn.co/image/1d29072e2633c7d9f74fa3fc4f0d9187cd927f2e", AltText = "img-Zac Brown Band", Width = 1000, Height = 1000 });
                    context.ProfilePics.Add(new ProfilePic { ProfilePicId = 2, Url = "https://i.scdn.co/image/557a642bbc541262c649096b3d1ef938f67ec69a", AltText = "img-Josh Ritter", Width = 640, Height = 640 });
                    context.Artists.Add(new Artist { ArtistId = 0, Name = "Gavin James", SpotifyId = "25tMQOrIU4LlUo6Sv8v5SE", ProfilePicId = 0 });
                    context.Artists.Add(new Artist { ArtistId = 1, Name = "Zac Brown Band", SpotifyId = "6yJCxee7QumYr820xdIsjo", ProfilePicId = 1 });
                    context.Artists.Add(new Artist { ArtistId = 2, Name = "Josh Ritter", SpotifyId = "6igfLpd8s6DBBAuwebRUuo", ProfilePicId = 2 });
                    context.SaveChanges();
                }


            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }

    }
}