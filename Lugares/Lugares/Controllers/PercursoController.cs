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
    public class PercursoController : Controller
    {
        private DatumContext db = new DatumContext();

        // GET: Percurso
        public ActionResult Index()
        {
            return View(db.Percursos.ToList());
        }

        // GET: Percurso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Percurso percurso = db.Percursos.Find(id);
            if (percurso == null)
            {
                return HttpNotFound();
            }
            return View(percurso);
        }

        // GET: Percurso/Create
        public ActionResult Create()
        {
            ViewBag.POI = new SelectList(db.POIs, "PoiID", "Nome");
            return View();
        }

        // POST: Percurso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome")] Percurso percurso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Percursos.Add(percurso);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            

            return View(percurso);
        }

        // GET: Percurso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Percurso percurso = db.Percursos.Find(id);
            if (percurso == null)
            {
                return HttpNotFound();
            }
            return View(percurso);
        }

        // POST: Percurso/Edit/5
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
            var percursoToUpdate = db.Percursos.Find(id);
            if (TryUpdateModel(percursoToUpdate, "",
               new string[] { "Nome", "Descricao"}))
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
            return View(percursoToUpdate);
        }

        // GET: Percurso/Delete/5
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
            Percurso percurso = db.Percursos.Find(id);
            if (percurso == null)
            {
                return HttpNotFound();
            }
            return View(percurso);
        }

        // POST: Percurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Percurso percursoToDelete = new Percurso() { PercursoID = id };
                db.Entry(percursoToDelete).State = EntityState.Deleted;
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
