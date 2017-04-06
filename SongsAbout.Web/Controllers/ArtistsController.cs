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
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using System.IO;
using System.Text;

namespace SongsAbout.Web.Controllers
{
    public class ArtistsController : Controller
    {
        private EntityDbContext db = new EntityDbContext();

        // GET: Artists
        public async Task<ActionResult> Index(int startIndex = 0, int count = 20)
        {
            try
            {
                var artists = db.Artists
                      .Take(count)
                      .Include(a => a.ProfilePic);

                ViewBag.TotalCount = await db.Artists.CountAsync();
                ViewBag.Count = count;
                ViewBag.StartIndex = startIndex;
                ViewBag.EndIndex = count - startIndex - 1;

                return View(artists);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message+"\n"+ex?.InnerException?.Message + "\n" + ex?.InnerException?.InnerException?.Message);
            }

        }

        // GET: Artists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = await (from a in db.Artists
                                   where a.ArtistId == id
                                   select a)
                                   .Include(a => a.ProfilePic)
                                   .Include(a => a.Albums)
                                   .Include(a => a.Albums.Select(al => al.Artist))
                                   .FirstOrDefaultAsync();


            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            ViewBag.ProfilePicId = new SelectList(db.ProfilePics, "ProfilePicId", "AltText");
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ArtistId,Name,Bio,SpotifyId,ProfilePicId")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProfilePicId = new SelectList(db.ProfilePics, "ProfilePicId", "AltText", artist.ProfilePicId);
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
            ViewBag.ProfilePicId = new SelectList(db.ProfilePics, "ProfilePicId", "AltText", artist.ProfilePicId);
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ArtistId,Name,Bio,SpotifyId,ProfilePicId")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProfilePicId = new SelectList(db.ProfilePics, "ProfilePicId", "AltText", artist.ProfilePicId);
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
