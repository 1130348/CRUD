using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary.DAL;
using ClassLibrary.Model;

namespace Lugares.Controllers
{
    [Authorize(Roles ="Admin")]
    public class POIController : Controller
    {
        private DatumContext db = new DatumContext();

        // GET: POIs
        public ActionResult Index()
        {
            var pOIs = db.POIs.Include(p => p.Local);
            return View(db.POIs.ToList());
        }

        // GET: POIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POI pOI = db.POIs.Find(id);
            if (pOI == null)
            {
                return HttpNotFound();
            }
            return View(pOI);
        }

        // GET: POIs/Create
        public ActionResult Create()
        {
            ViewBag.LocalID = new SelectList(db.Locals,"LocalID","Nome");
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "nome");
            return View();
        }

        // POST: POIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Descricao,LocalID,CategoriaID,duracaoVisita")] POI pOI)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.POIs.Add(pOI);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.LocalID = new SelectList(db.Locals, "LocalID", "LocalID");
                ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "nome");

            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(pOI);
        }

        // GET: POIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POI pOI = db.POIs.Find(id);
            if (pOI == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalID = new SelectList(db.Locals, "LocalID", "Nome", pOI.LocalID);
            return View(pOI);
        }

        // POST: POIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var poiToUpdate = db.POIs.Find(id);
            if (TryUpdateModel(poiToUpdate, "",
               new string[] { "Nome", "Descricao", "Categoria" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(poiToUpdate);
        }

        // GET: POIs/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            POI poi = db.POIs.Find(id);
            if (poi == null)
            {
                return HttpNotFound();
            }
            return View(poi);
        }

        // POST: POIs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                POI poiToDelete = new POI() { PoiID = id };
                db.Entry(poiToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
