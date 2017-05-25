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
                    context.Pictures.Add(new Picture { Id = 0, Src = "https://i.scdn.co/image/b0b295beeb9c89c5060f9f08f9c0de55d00aad0a", Name = "img-Gavin James", Width = 640, Height = 640 });
                    context.Pictures.Add(new Picture { Id = 1, Src = "https://i.scdn.co/image/1d29072e2633c7d9f74fa3fc4f0d9187cd927f2e", Name = "img-Zac Brown Band", Width = 1000, Height = 1000 });
                    context.Pictures.Add(new Picture { Id = 2, Src = "https://i.scdn.co/image/557a642bbc541262c649096b3d1ef938f67ec69a", Name = "img-Josh Ritter", Width = 640, Height = 640 });
                    context.Artists.Add(new Artist { Id = 0, Name = "Gavin James", SpotifyId = "25tMQOrIU4LlUo6Sv8v5SE" });
                    context.Artists.Add(new Artist { Id = 1, Name = "Zac Brown Band", SpotifyId = "6yJCxee7QumYr820xdIsjo" });
                    context.Artists.Add(new Artist { Id = 2, Name = "Josh Ritter", SpotifyId = "6igfLpd8s6DBBAuwebRUuo" });
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