using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SongsAbout.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SongsAbout.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private EntityDbContext db = new EntityDbContext();

        // GET: Albums
        public ActionResult Index()
        {
            var albums = db.Albums
                .Include(a => a.AlbumCover)
                .Include(a => a.Tracks)
                .Take(20);

            return View(albums.ToList());
        }



        // GET: Albums/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = await (from a in db.Albums
                                 where a.AlbumId == id

                                 select a)
                                // .Include("Tracks.Artist.FeaturedArtists.Keywords.Topics.Genres")
                                 .Include(a => a.Tracks)
                                 .Include(a => a.Artist)
                                 .Include(a => a.AlbumCover)
                                 //.Include(a => a.FeaturedArtists)
                                 //.Include(a => a.Keywords)
                                 //.Include(a => a.Topics)
                                 //.Include(a => a.Genres)
                                 .FirstOrDefaultAsync();
            db.Entry(album).Collection(a => a.Tracks).Load();
            db.Entry(album).Collection(a => a.Keywords).Load();
            db.Entry(album).Collection(a => a.FeaturedArtists).Load();
            db.Entry(album).Reference(a => a.Artist).Load();

            album.Artist = db.Artists.Find(album.ArtistId);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.AlbumCoverId = new SelectList(db.AlbumCovers, "AlbumCoverId", "AltText");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AlbumId,Id,Name,ReleaseDate,ArtistId,AlbumCoverId,SpotifyId")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumCoverId = new SelectList(db.AlbumCovers, "AlbumCoverId", "AltText", album.AlbumCoverId);
            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = await db.Albums.FindAsync(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumCoverId = new SelectList(db.AlbumCovers, "AlbumCoverId", "AltText", album.AlbumCoverId);
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AlbumId,Id,Name,ReleaseDate,ArtistId,AlbumCoverId,SpotifyId")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumCoverId = new SelectList(db.AlbumCovers, "AlbumCoverId", "AltText", album.AlbumCoverId);
            return View(album);
        }

        // GET: Albums/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = await db.Albums.FindAsync(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Album album = await db.Albums.FindAsync(id);
            db.Albums.Remove(album);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
