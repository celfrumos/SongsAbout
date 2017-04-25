//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using SpotifyAPI.Web;
//using SpotifyAPI.Web.Models;
//using SpotifyAPI.Web.Enums;

//namespace SongsAbout.Web.Views
//{
//    public class SearchController : Controller
//    {
//        private SearchType _searchType;
//        // GET: Search
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult Search(string q)
//        {

//            ViewBag.Query = q;
//            return View();
//        }

//        private async void ExecuteSearch(string query, SearchType searchType, int limit = 20, int offset = 0, int retryCount = 5)
//        {
//            var resultsList = UserSpotify.Search(query, searchType, limit, offset, retryCount);

//            if (HaSearchType(SearchType.Artist))
//            {
//                foreach (SpotifyArtist a in resultsList.Artists.Items)
//                {
//                    AddToFlow(new SPanel(a, SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click));

//                }
//            }
//            if (HaSearchType(SearchType.Album))
//            {
//                foreach (var al in resultsList.Albums.Items)
//                {
//                    await Task.Run(() => AddToFlow(new SPanel(al, SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click)));
//                }
//            }
//            if (HaSearchType(SearchType.Track))
//            {
//                foreach (var t in resultsList.Tracks.Items)
//                {
//                    var row = new TrackRow(t);
//                    AddToFlow(row);
//                    return;
//                }
//            }
//            if (HaSearchType(SearchType.Playlist))
//            {
//                foreach (var p in resultsList.Playlists.Items)
//                {
//                    AddToFlow(new SPanel(p, SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click));
//                }
//            }


//        }
//        private bool HaSearchType(SearchType targetType)
//        {
//            return (_searchType & targetType) == targetType;
//        }
//        private SearchType ToggleSearchType(SearchType targetType)
//        {
//            return Flag.Spotify.Search.ToggleFlag(_searchType, targetType);
//        }

//        public SearchType SetSearchType(SearchType targetType)
//        {
//            return _searchType | targetType;
//        }

//        public SearchType UnsetSearchType(SearchType targetFlag)
//        {
//            return _searchType & (~targetFlag);
//        }

//    }
//}