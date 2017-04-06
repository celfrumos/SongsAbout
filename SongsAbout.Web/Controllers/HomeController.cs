using SongsAbout.Web.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SongsAbout.Web.Controllers
{
    public partial class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string q, int? type = (int)(SearchMethod.Any))
        {
            var results = _searchRecords(q, (SearchMethod)(type));

            return View(viewName: "Search", model: results);
        }

        [HttpGet]
        public ActionResult Search(string q, SearchMethod type = SearchMethod.Any)
        {
            var results = _searchRecords(q, type);

            return View(viewName: "Search", model: results);
        }
        private SearchResults<SaEntity> _searchRecords(string q, SearchMethod type = SearchMethod.Any)
        {
            var results = new SearchResults<SaEntity>();

            return results;

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}