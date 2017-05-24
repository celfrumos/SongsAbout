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
using PagedList;

namespace SongsAbout.Web.Controllers
{
    public class ArtistsController : Controller
    {
        private EntityDbContext db = new EntityDbContext();

        // GET: Artists
        public async Task<ActionResult> Index(int items = 10, int? page = null, string orderBy = nameof(Artist.Name), SortMode sortOrder = SortMode.Ascending, string filter = null, string q = null)
        {
            try
            {
                ViewBag.CurrentSort = sortOrder;
                if (q != null)
                    page = 1;

                else
                    q = filter;


                ViewBag.CurrentFilter = q;

                IEnumerable<Artist> artists = new List<Artist>(db.Artists
                                                .Include(a => a.ProfilePic));
                if (!String.IsNullOrEmpty(q))
                    artists = artists.Where(s => s.Name.ToLower().Contains(q.ToLower()));

                if (sortOrder == SortMode.Ascending)
                    artists = artists.OrderBy(a => typeof(Artist).GetProperty(orderBy).GetValue(a));

                else
                    artists = artists.OrderByDescending(a => typeof(Artist).GetProperty(orderBy).GetValue(a));

                int pageNum = page ?? 1;

                return View(artists.ToPagedList(pageNum, items));
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        // GET: Artists/Details/5
        public async Task<ActionResult> Details(int? id)
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

        // GET: Artists/Create
        public ActionResult Create()
        {
            ViewBag.ProfilePicId = new SelectList(db.Pictures, "Id", "Src");
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Bio,ProfilePicId,SpotifyId")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProfilePicId = new SelectList(db.Pictures, "Id", "Src", artist.ProfilePicId);
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
            ViewBag.ProfilePicId = new SelectList(db.Pictures, "Id", "Src", artist.ProfilePicId);
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Bio,ProfilePicId,SpotifyId")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProfilePicId = new SelectList(db.Pictures, "Id", "Src", artist.ProfilePicId);
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
