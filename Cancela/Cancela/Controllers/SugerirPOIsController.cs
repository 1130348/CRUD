using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ClassLibrary.DAL;
using ClassLibrary.Model;

namespace Cancela.Controllers
{
    public class SugerirPOIsController : ApiController
    {
        private DatumContext db = new DatumContext();

        // GET: api/SugerirPOIs
        public IQueryable<SugerirPOI> GetSugerirPOI()
        {
            return db.SugerirPOI;
        }

        // GET: api/SugerirPOIs/5
        [ResponseType(typeof(SugerirPOI))]
        public async Task<IHttpActionResult> GetSugerirPOI(int id)
        {
            SugerirPOI sugerirPOI = await db.SugerirPOI.FindAsync(id);
            if (sugerirPOI == null)
            {
                return NotFound();
            }

            return Ok(sugerirPOI);
        }

        // PUT: api/SugerirPOIs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSugerirPOI(int id, SugerirPOI sugerirPOI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sugerirPOI.SugerirPoiID)
            {
                return BadRequest();
            }

            db.Entry(sugerirPOI).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SugerirPOIExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SugerirPOIs
        [ResponseType(typeof(SugerirPOI))]
        public async Task<IHttpActionResult> PostSugerirPOI(SugerirPOI sugerirPOI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SugerirPOI.Add(sugerirPOI);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sugerirPOI.SugerirPoiID }, sugerirPOI);
        }

        // DELETE: api/SugerirPOIs/5
        [ResponseType(typeof(SugerirPOI))]
        public async Task<IHttpActionResult> DeleteSugerirPOI(int id)
        {
            SugerirPOI sugerirPOI = await db.SugerirPOI.FindAsync(id);
            if (sugerirPOI == null)
            {
                return NotFound();
            }

            db.SugerirPOI.Remove(sugerirPOI);
            await db.SaveChangesAsync();

            return Ok(sugerirPOI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SugerirPOIExists(int id)
        {
            return db.SugerirPOI.Count(e => e.SugerirPoiID == id) > 0;
        }
    }
}