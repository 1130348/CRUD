using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary.DAL;
using ClassLibrary.Model;

namespace PortoVisitas.Controllers
{
    public class HashtagsController : Controller
    {
        private DatumContext db = new DatumContext();

        // GET: Hashtags
        public async Task<ActionResult> Index()
        {
            return View(await db.Hashtags.ToListAsync());
        }

        // GET: Hashtags/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hashtag hashtag = await db.Hashtags.FindAsync(id);
            if (hashtag == null)
            {
                return HttpNotFound();
            }
            return View(hashtag);
        }

        // GET: Hashtags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hashtags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Nome")] Hashtag hashtag)
        {
            if (ModelState.IsValid)
            {
                db.Hashtags.Add(hashtag);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hashtag);
        }

        // GET: Hashtags/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hashtag hashtag = await db.Hashtags.FindAsync(id);
            if (hashtag == null)
            {
                return HttpNotFound();
            }
            return View(hashtag);
        }

        // POST: Hashtags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Nome")] Hashtag hashtag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hashtag).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hashtag);
        }

        // GET: Hashtags/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hashtag hashtag = await db.Hashtags.FindAsync(id);
            if (hashtag == null)
            {
                return HttpNotFound();
            }
            return View(hashtag);
        }

        // POST: Hashtags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Hashtag hashtag = await db.Hashtags.FindAsync(id);
            db.Hashtags.Remove(hashtag);
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
