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

namespace SongsAbout.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private EntityDbContext db = new EntityDbContext();

        // GET: Albums
        public async Task<ActionResult> Index()
        {
            return View(await LoadModelsAsync());
        }
        private async Task<IEnumerable<Album>> LoadModelsAsync()
        {

            await db.Tracks.LoadAsync();

            return await db.Albums
                        .Include(a => a.Tracks)
                        .Include(a => a.Tracks.Select(t => t.Artist))
                        .Include(a => a.Tracks.Select(t => t.Album))
                        .Include(a => a.Artist)
                        .Include(a => a.AlbumCover)
                       .ToListAsync();
        }

        private async Task<Album> LoadModelAsync(int? id)
        {
            await db.Tracks.LoadAsync();
            Album album = await (from a in db.Albums
                                 where a.AlbumId == id
                                 select a)
                        .Include(a => a.Tracks)
                        .Include(a => a.Tracks.Select(t => t.Artist))
                        .Include(a => a.Tracks.Select(t => t.Album))
                        .Include(a => a.Artist)
                        .Include(a => a.AlbumCover)
                        .FirstOrDefaultAsync();


            return album;

        }
        // GET: Albums/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = await LoadModelAsync(id);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AlbumId,Name,MainArtistId,SpotifyUri,SpotifyHref,ReleaseDate")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = await
                             (from a in db.Albums
                              where a.AlbumId == id
                              select a)
                         .Include(a => a.Tracks)
                         .Include(a => a.AlbumCover)
                         .FirstOrDefaultAsync();
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AlbumId,Name,MainArtistId,SpotifyUri,SpotifyHref,ReleaseDate")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
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
