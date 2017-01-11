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
    public class SugerirPOIsController : Controller
    {

        // GET: SugerirPOIs
        public async Task<ActionResult> Index()
        {
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/SugerirPOIs");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var sugPOI = JsonConvert.DeserializeObject<IEnumerable<SugerirPOI>>(content);
                return View(sugPOI);
            }
            else
            {
                return Content("Ocorreu um erro: " + response.StatusCode);
            }

        }

        // GET: SugerirPOIs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/SugerirPOIs/" + id);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var sugPoi = JsonConvert.DeserializeObject<SugerirPOI>(content);
                if (sugPoi == null) return HttpNotFound();
                return View(sugPoi);
            }
            else
            {
                return Content("Ocorreu um erro: " + response.StatusCode);
            }

        }

        // GET: SugerirPOIs/Create
        public async Task<ActionResult> Create()
        {
            var client = WebApiHttpClient.GetClient();

            HttpResponseMessage responseLocals = await client.GetAsync("api/Locals");
            string contentLocals = await responseLocals.Content.ReadAsStringAsync();
            var locals = JsonConvert.DeserializeObject<IEnumerable<Local>>(contentLocals);
            ViewBag.LocalID = new SelectList(locals, "LocalID", "Nome");

            HttpResponseMessage responseCategorias = await client.GetAsync("api/Categorias");
            string contentCategorias = await responseCategorias.Content.ReadAsStringAsync();
            var categorias = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(contentCategorias);
            ViewBag.CategoriaID = new SelectList(categorias, "CategoriaID", "nome");

            return View();
        }

        // POST: SugerirPOIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SugerirPoiID,Nome,Descricao,LocalID,CategoriaID,duracaoVisita,UserID")] SugerirPOI sugerirPOI)
        {
            try
            {
                var client = WebApiHttpClient.GetClient();
                string sugJSON = JsonConvert.SerializeObject(sugerirPOI);
                HttpContent content = new StringContent(sugJSON,
                System.Text.Encoding.Unicode, "application/json");
                var response = await client.PostAsync("api/SugerirPOIs", content);
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

        // GET: SugerirPOIs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/SugerirPOIs/" + id);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var sugPoi = JsonConvert.DeserializeObject<SugerirPOI>(content);
                if (sugPoi == null) return HttpNotFound();

                HttpResponseMessage responseLocals = await client.GetAsync("api/Locals");
                string contentLocals = await responseLocals.Content.ReadAsStringAsync();
                var locals = JsonConvert.DeserializeObject<IEnumerable<Local>>(contentLocals);
                ViewBag.LocalID = new SelectList(locals, "LocalID", "Nome", sugPoi.LocalID);

                HttpResponseMessage responseCategorias = await client.GetAsync("api/Categorias");
                string contentCategorias = await responseCategorias.Content.ReadAsStringAsync();
                var categorias = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(contentCategorias);
                ViewBag.CategoriaID = new SelectList(categorias, "CategoriaID", "nome");

                return View(sugPoi);
            }
            return Content("Ocorreu um erro: " + response.StatusCode);
        }

        // POST: SugerirPOIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SugerirPoiID,Nome,Descricao,LocalID,CategoriaID,duracaoVisita,UserID")] SugerirPOI sugerirPOI)
        {
            try
            {
                var client = WebApiHttpClient.GetClient();
                string editoraJSON = JsonConvert.SerializeObject(sugerirPOI);
                HttpContent content = new StringContent(editoraJSON,
                System.Text.Encoding.Unicode, "application/json");
                var response =
                await client.PutAsync("api/SugerirPOIs/" + sugerirPOI.SugerirPoiID, content);
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

        // GET: SugerirPOIs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/SugerirPOIs/" + id);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var sugPoi = JsonConvert.DeserializeObject<SugerirPOI>(content);
                if (sugPoi == null) return HttpNotFound();
                return View(sugPoi);
            }
            return Content("Ocorreu um erro: " + response.StatusCode);

        }

        // POST: SugerirPOIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var client = WebApiHttpClient.GetClient();
                var response = await client.DeleteAsync("api/SugerirPOIs/" + id);
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
