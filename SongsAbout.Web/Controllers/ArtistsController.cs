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
using SpotifyAPI.Web.Models;

namespace SongsAbout.Web.Controllers
{
    public class ArtistsController : Controller
    {
        private EntityDbContext db = new EntityDbContext();

        // GET: Artists
        public async Task<ActionResult> Index()
        {
            return View(await db.Artists.ToListAsync());
        }

        public PartialViewResult ArtistRowPartial(Artist a, bool allowEdit = false, RowStyle style = RowStyle.SquareImage)
        {
            ViewBag.RowDetails = new RowDetails { AllowEdit = allowEdit, RowStyle = style };
            return PartialView(a);

        }
        // GET: Artists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Saved = true;
            Artist artist = await db.Artists.FindAsync(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        public async Task<ActionResult> Details(string name, SpotifyFullArtist spotifyArt)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Artist artist = await db.Artists
                .SingleOrDefaultAsync(a => a.Name == name);

            ViewBag.Saved = true;

            if (artist == null)
            {
                ViewBag.Saved = false;

                if (spotifyArt == null)
                    return HttpNotFound();

                artist = new Artist(spotifyArt);
            }
            
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Bio,SpotifyId")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = await db.Artists.FindAsync(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Bio,SpotifyId")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = await db.Artists.FindAsync(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Artist artist = await db.Artists.FindAsync(id);
            db.Artists.Remove(artist);
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
