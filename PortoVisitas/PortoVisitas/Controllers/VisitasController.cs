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
    public class VisitasController : Controller
    {
        private DatumContext db = new DatumContext();

        // GET: Visitas
        public async Task<ActionResult> Index()
        {
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Visitas");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var visitas = JsonConvert.DeserializeObject<IEnumerable<Visita>>(content);
                return View(visitas);
            }else
            {
                return Content("Ocorreu um erro: "+ response.StatusCode);
            }
            
        }

        // GET: Visitas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Visitas/" + id);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var visita = JsonConvert.DeserializeObject<Visita>(content);
                if (visita == null) return HttpNotFound();
                return View(visita);
            }else
            {
                return Content("Ocorreu um erro: " + response.StatusCode);
            }
        }

        // GET: Visitas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visitas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idVisita,data,descrição,horaInicio,idPercurso,idUser")] Visita visita)
        {
            try
            {
                var client = WebApiHttpClient.GetClient();
                string visitaJSON = JsonConvert.SerializeObject(visita);
                HttpContent content = new StringContent(visitaJSON, System.Text.Encoding.Unicode, "application/json");
                var response = await client.PostAsync("api/Visitas", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }else
                {
                    return Content("Ocorreu um erro: " + response.StatusCode);
                }
            }catch
            {
                return Content("Ocorreu um erro.");
            }
        }

        // GET: Visitas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Visitas/" + id);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var visita = JsonConvert.DeserializeObject<Visita>(content);
                if (visita == null) return HttpNotFound();
                return View(visita);
            }
            return Content("Ocorreu um erro: " + response.StatusCode);
        }

        // POST: Visitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idVisita,data,descrição,horaInicio,idPercurso,idUser")] Visita visita)
        {
            try
            {
                var client = WebApiHttpClient.GetClient();
                string visitaJSON = JsonConvert.SerializeObject(visita);
                HttpContent content = new StringContent(visitaJSON, System.Text.Encoding.Unicode, "application/json");
                var response = await client.PutAsync("api/Visitas/" + visita.idVisita, content);
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

        // GET: Visitas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Visitas/" + id);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var visita = JsonConvert.DeserializeObject<Visita>(content);
                if (visita == null) return HttpNotFound();
                return View(visita);
            }
            return Content("Ocorreu um erro: " + response.StatusCode);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var client = WebApiHttpClient.GetClient();
                var response = await client.DeleteAsync("api/Visitas/" + id);
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
