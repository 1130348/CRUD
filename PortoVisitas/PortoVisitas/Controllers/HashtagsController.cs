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
    public class HashtagsController : Controller
    {

        // GET: Hashtags
        public async Task<ActionResult> Index()
        {
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Hashtags");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var hash =
                JsonConvert.DeserializeObject<IEnumerable<Hashtag>>(content);
                return View(hash);
            }
            else
            {
                return Content("Ocorreu um erro: " + response.StatusCode);
            }
        }

        // GET: Hashtags/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Hashtags/" + id);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var hash = JsonConvert.DeserializeObject<Hashtag>(content);
                if (hash == null) return HttpNotFound();
                return View(hash);
            }
            else
            {
                return Content("Ocorreu um erro: " + response.StatusCode);
            }
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
            try
            {
                var client = WebApiHttpClient.GetClient();
                string hashJSON = JsonConvert.SerializeObject(hashtag);
                HttpContent content = new StringContent(hashJSON,
                System.Text.Encoding.Unicode, "application/json");
                var response = await client.PostAsync("api/Hashtags", content);
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

        // GET: Hashtags/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Hashtags/" + id);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var hash = JsonConvert.DeserializeObject<Hashtag>(content);
                if (hash == null) return HttpNotFound();
                return View(hash);
            }
            return Content("Ocorreu um erro: " + response.StatusCode);
        }

        // POST: Hashtags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Nome")] Hashtag hashtag)
        {
            try
            {
                var client = WebApiHttpClient.GetClient();
                string hashJSON = JsonConvert.SerializeObject(hashtag);
                HttpContent content = new StringContent(hashJSON,
                System.Text.Encoding.Unicode, "application/json");
                var response =
                await client.PutAsync("api/Hashtags/" + hashtag.ID, content);
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

        // GET: Hashtags/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = WebApiHttpClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Hashtags/" + id);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var hash = JsonConvert.DeserializeObject<Hashtag>(content);
                if (hash == null) return HttpNotFound();
                return View(hash);
            }
            return Content("Ocorreu um erro: " + response.StatusCode);
        }

        // POST: Hashtags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var client = WebApiHttpClient.GetClient();
                var response = await client.DeleteAsync("api/Hashtags/" + id);
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
