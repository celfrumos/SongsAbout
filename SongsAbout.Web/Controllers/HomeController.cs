﻿using SongsAbout.Web.Models;
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
        EntityDbContext db = new EntityDbContext();
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string q, int limit = 5, int? type = (int)(SearchMethod.Any), int? startIndex = 0)
        {
            var results = _searchRecords(q, limit, (SearchMethod)(type));

            return View(viewName: "Search", model: results);
        }

        [HttpGet]
        public ActionResult Search(string q, int limit = 5, SearchMethod type = SearchMethod.Any, int? startIndex = 0)
        {
            var results = _searchRecords(q, limit, type);

            return View(viewName: "Search", model: results);
        }


        private SearchResults _searchRecords(string q, int limit = 5, SearchMethod type = SearchMethod.Any, int? startIndex = 0)
        {
            var results = new SearchResults();


            if ((type & SearchMethod.Artist) == SearchMethod.Artist || type == SearchMethod.Any)
            {
                results.Items.AddRange((from a in db.Artists
                                        where a.Name.ToLower()
                                              .Contains(q.ToLower())
                                        select a).Take(limit));

            }
            if ((type & SearchMethod.Album) == SearchMethod.Album || type == SearchMethod.Any)
            {
                results.Items.AddRange((from a in db.Albums
                                        where a.Name.ToLower()
                                              .Contains(q.ToLower())
                                        select a)
                                        .Take(limit));

            }
            if ((type & SearchMethod.Track) == SearchMethod.Track || type == SearchMethod.Any)
            {

                results.Items.AddRange((from a in db.Tracks
                                        where a.Name.ToLower()
                                              .Contains(q.ToLower())
                                        select a).Take(limit));
            }
            if ((type & SearchMethod.Topic) == SearchMethod.Topic || type == SearchMethod.Any)
            {
                results.Items.AddRange((from a in db.Topics
                                        where a.Text.ToLower()
                                              .Contains(q.ToLower())
                                        select a).Take(limit));

            }
            if ((type & SearchMethod.Genre) == SearchMethod.Genre || type == SearchMethod.Any)
            {

                //results.Items.AddRange((from a in db.Artists
                //                        where a.Name.ToLower()
                //                              .Contains(q.ToLower())
                //                        select a).Take(limit));
            }

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