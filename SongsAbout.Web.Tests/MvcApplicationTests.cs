using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongsAbout.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsAbout.Web.Controllers;
using SongsAbout.Web.Models;
using System.Data.Entity;
using SongsAbout.Web.Views;

namespace SongsAbout.Web.Tests
{
    [TestClass]
    public class MvcApplicationTests
    {
        [TestMethod()]
        public void Application_StartTest()
        {
            try
            {
                Database.SetInitializer<EntityDbContext>(new EntityDbInitializer());
                var inita = new EntityDbInitializer();
                using (var db = new EntityDbContext())
                {
                    inita.InitializeDatabase(db);

                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"{ex.Message}");
            }
        }
    }
}