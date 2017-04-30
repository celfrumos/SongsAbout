using SongsAbout.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SongsAbout.Web.Controllers
{
    public class SearchController : Controller
    {
        private EntityDbContext db = new EntityDbContext();

        public ActionResult AutoComplete(string term)
        {
            var res = new List<string>();
            var artists = (from a in db.Artists
                           where a.Name.ToLower().Contains(term.ToLower())
                           orderby a.Name descending
                           select a.Name)
                           .Take(5);

            var albums = (from a in db.Albums
                          where a.Name.ToLower().Contains(term.ToLower())
                          orderby a.Name descending
                          select a.Name)
                          .Take(5);

            var tracks = (from t in db.Tracks
                          where t.Name.ToLower().Contains(term.ToLower())
                          orderby t.Name descending
                          select t.Name)
                          .Take(5);

            res.AddRange(artists);
            res.AddRange(albums);
            res.AddRange(tracks);
            res.Sort();

            return Json(res.Select(a => new { value = a }), JsonRequestBehavior.AllowGet);

        }

        
        [HttpGet]
        public ActionResult Index(string q, SaEntityType type = SaEntityType.Artist)
        {

            ViewBag.ItemLimit = 5;
            ViewBag.SearchType = type;
            var results = db.Search(q, SaEntityType.Any, 5);
            ViewBag.Results = results;
            return View(results);
        }
    }
}
