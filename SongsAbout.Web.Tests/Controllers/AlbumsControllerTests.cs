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
        public void GetAnyOrAllAlbumsDoesntThrowError()
        {
            try
            {
                var albController = new AlbumsController();
                var result = albController.Index() as ViewResult;
                Assert.IsNotNull(result.Model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    
    }
}