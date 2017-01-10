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
using ClassLibrary.ViewModels;

namespace Cancela.Controllers
{
    public class PercursoesController : ApiController
    {
        private DatumContext db = new DatumContext();

        // GET: api/Percursoes
        public IEnumerable<PercursoModel> GetPercursos()
        {
            IEnumerable<Percurso> percursoList = db.Percursos.ToList();
            List<PercursoModel> newPercursoList = new List<PercursoModel>();

            foreach (var percurso in percursoList)
            {
                Percurso newPercurso = db.Percursos.Include(l => l.POIs).Where(l => l.PercursoID == percurso.PercursoID).SingleOrDefault();
                if (newPercurso != null)
                {
                    PercursoModel newMdl = new PercursoModel(newPercurso);
                
                 if (newMdl != null)
                    {
                       newPercursoList.Add(newMdl);
                    }
                }
            }

            return newPercursoList;
        }

        // GET: api/Percursoes/5
        [ResponseType(typeof(PercursoModel))]
        public IHttpActionResult GetPercurso(int id)
        {
            Percurso percurso =  db.Percursos.Find(id);
            if (percurso == null)
            {
                return NotFound();
            }
            Percurso newPercurso = db.Percursos.Include(l => l.POIs).Where(l => l.PercursoID == percurso.PercursoID).SingleOrDefault();
            if (newPercurso == null)
            {
                return NotFound();
            }
            PercursoModel newMdlPercurso = new PercursoModel(newPercurso);
            if (newMdlPercurso == null)
            {
                return NotFound();
            }

            return Ok(newMdlPercurso);
        }

        // PUT: api/Percursoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPercurso(int id, Percurso percurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != percurso.PercursoID)
            {
                return BadRequest();
            }

            db.Entry(percurso).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PercursoExists(id))
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

        // POST: api/Percursoes
        [ResponseType(typeof(Percurso))]
        public async Task<IHttpActionResult> PostPercurso(Percurso percurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Percursos.Add(percurso);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = percurso.PercursoID }, percurso);
        }

        // DELETE: api/Percursoes/5
        [ResponseType(typeof(Percurso))]
        public async Task<IHttpActionResult> DeletePercurso(int id)
        {
            Percurso percurso = await db.Percursos.FindAsync(id);
            if (percurso == null)
            {
                return NotFound();
            }

            db.Percursos.Remove(percurso);
            await db.SaveChangesAsync();

            return Ok(percurso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PercursoExists(int id)
        {
            return db.Percursos.Count(e => e.PercursoID == id) > 0;
        }
    }
}