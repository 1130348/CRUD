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

namespace Cancela.Controllers
{
    public class SugerirPOIsController : Controller
    {
        private DatumContext db = new DatumContext();

        // GET: SugerirPOIs
        public ActionResult Index()
        {
            var sugerirPOI = db.SugerirPOI.Include(s => s.Categoria).Include(s => s.Local);
            return View(sugerirPOI.ToList());
        }

        // GET: SugerirPOIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SugerirPOI sugerirPOI = db.SugerirPOI.Find(id);
            if (sugerirPOI == null)
            {
                return HttpNotFound();
            }
            return View(sugerirPOI);
        }

        // GET: SugerirPOIs/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "nome");
            ViewBag.LocalID = new SelectList(db.Locals, "LocalID", "Nome");
            return View();
        }

        // POST: SugerirPOIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoiID,Nome,Descricao,LocalID,CategoriaID,duracaoVisita,UserID")] SugerirPOI sugerirPOI)
        {
            if (ModelState.IsValid)
            {
                db.SugerirPOI.Add(sugerirPOI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "nome", sugerirPOI.CategoriaID);
            ViewBag.LocalID = new SelectList(db.Locals, "LocalID", "Nome", sugerirPOI.LocalID);
            return View(sugerirPOI);
        }

        // GET: SugerirPOIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SugerirPOI sugerirPOI = db.SugerirPOI.Find(id);
            if (sugerirPOI == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "nome", sugerirPOI.CategoriaID);
            ViewBag.LocalID = new SelectList(db.Locals, "LocalID", "Nome", sugerirPOI.LocalID);
            return View(sugerirPOI);
        }

        // POST: SugerirPOIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoiID,Nome,Descricao,LocalID,CategoriaID,duracaoVisita,UserID")] SugerirPOI sugerirPOI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sugerirPOI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "nome", sugerirPOI.CategoriaID);
            ViewBag.LocalID = new SelectList(db.Locals, "LocalID", "Nome", sugerirPOI.LocalID);
            return View(sugerirPOI);
        }

        // GET: SugerirPOIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SugerirPOI sugerirPOI = db.SugerirPOI.Find(id);
            if (sugerirPOI == null)
            {
                return HttpNotFound();
            }
            return View(sugerirPOI);
        }

        // POST: SugerirPOIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SugerirPOI sugerirPOI = db.SugerirPOI.Find(id);
            db.SugerirPOI.Remove(sugerirPOI);
            db.SaveChanges();
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
