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
using PortoVisitas.Helper;
using System.Net.Http;
using Newtonsoft.Json;

namespace PortoVisitas.Controllers
{
    public class PercursoesController : Controller
    {
        private DatumContext db = new DatumContext();

        // GET: Percursoes
        public async Task<ActionResult> Index()
        {
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Percursoes");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var percursos =
                JsonConvert.DeserializeObject<IEnumerable<Percurso>>(content);
                return View(percursos);
            }
            else
            {
                return Content("Ocorreu um erro: " + response.StatusCode);
            }

        }

        // GET: Percursoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Percursoes/" + id);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var percurso = JsonConvert.DeserializeObject<Percurso>(content);
                if (percurso == null) return HttpNotFound();
                return View(percurso);
            }
            else
            {
                return Content("Ocorreu um erro: " + response.StatusCode);
            }
        }

        // GET: Percursoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Percursoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PercursoID,Nome,Descricao")] Percurso percurso)
        {
            try
            {
                var client = WebApiHttpClient.GetClient();
                string percursoJSON = JsonConvert.SerializeObject(percurso);
                HttpContent content = new StringContent(percursoJSON,
                System.Text.Encoding.Unicode, "application/json");
                var response = await client.PostAsync("api/Percursoes", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("Ocorreu um erro: " + response.StatusCode);
                }
            }
            catch
            {
                return Content("Ocorreu um erro.");
            }

        }

        // GET: Percursoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Percursoes/" + id);
            if (response.IsSuccessStatusCode)
            {

                string content = await response.Content.ReadAsStringAsync();
                var percurso = JsonConvert.DeserializeObject<Percurso>(content);
                if (percurso == null) return HttpNotFound();

                HttpResponseMessage responsePois = await client.GetAsync("api/POIs");
                string contentPois = await responsePois.Content.ReadAsStringAsync();
                var pois = JsonConvert.DeserializeObject<IEnumerable<POI>>(contentPois);
                ViewBag.POI = new SelectList(pois, "PoiID", "Nome");

                return View(percurso);
            }
            return Content("Ocorreu um erro: " + response.StatusCode);
        }

        // POST: Percursoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PercursoID,Nome,Descricao")] Percurso percurso)
        {
            try
            {
                var client = WebApiHttpClient.GetClient();
                string percursoJSON = JsonConvert.SerializeObject(percurso);
                HttpContent content = new StringContent(percursoJSON,
                System.Text.Encoding.Unicode, "application/json");
                var response =
                await client.PutAsync("api/Percursoes/" + percurso.PercursoID, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("Ocorreu um erro: " + response.StatusCode);
                }
            }
            catch
            {
                return Content("Ocorreu um erro.");
            }
        }

        // GET: Percursoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Percursoes/" + id);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var percurso = JsonConvert.DeserializeObject<Percurso>(content);
                if (percurso == null) return HttpNotFound();
                return View(percurso);
            }
            return Content("Ocorreu um erro: " + response.StatusCode);

        }

        // POST: Percursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var client = WebApiHttpClient.GetClient();
                var response = await client.DeleteAsync("api/Percursoes/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("Ocorreu um erro: " + response.StatusCode);
                }
            }
            catch
            {
                return Content("Ocorreu um erro.");
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
