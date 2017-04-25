using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongsAbout.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Telerik.JustMock;

namespace SongsAbout.Web.Controllers.Tests
{
    [TestClass]
    public class AlbumsControllerTests
    {
        // GET: Albums
        [TestMethod]
        public void AlbumsIndexTestMethod()
        {
            try
            {

                using (var db = new EntityDbContext())
                {
                    var albums = db.Albums.Include(a => a.AlbumCover).Take(20);

                    Assert.IsNotNull(albums);
                    Assert.IsInstanceOfType(albums, typeof(IQueryable<Album>));
                    var list = albums.ToList();
                    Assert.IsInstanceOfType(list, typeof(List<Album>));

                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
       

        [TestMethod]
        public void GetAnyOrAllAlbumsDoesntThrowError()
        {

        }
        [TestMethod]
        public void DetailsTest()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
        }
    }
}