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
using System.Web.Http;
using System.Drawing;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace Cancela.Controllers
{
    public class POIsController : ApiController
    {
        private DatumContext db = new DatumContext();

        // GET: api/POIs
        public IEnumerable<POIDTOSend> GetPOIs()
        {
            List<POIDTOSend> newList = new List<POIDTOSend>();
            IEnumerable<POI> list = db.POIs.ToList();
            foreach(var poi in list)
            {
                newList.Add(new POIDTOSend(poi));
            }
            return newList;
        }

        // GET: api/POIs/5
        [ResponseType(typeof(POIDTOSend))]
        public IHttpActionResult GetPOI(int id)
        {
            POI poi = db.POIs.Find(id);
            if(poi == null)
            {
                return NotFound();
            }
            return Ok(new POIDTOSend(poi));
        }

        // PUT: api/POIs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPOI(int id, POIDTOReceive poiDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != poiDTO.PoiID)
            {
                return BadRequest();
            }

            POI poi = db.POIs.Find(id);

            //if (poi.CheckNotOwner(User.Identity.GetUserId()))
            //{
            //    return StatusCode(HttpStatusCode.Unauthorized);
            //}

            copyToDto(poi, poiDTO);
            db.Entry(poi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!POIExists(id))
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

        // POST: api/POIs
        [ResponseType(typeof(POIDTOSend))]
        public IHttpActionResult PostPOI(POIDTOReceive poiDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            POI poi = new POI();
            copyToDto(poi, poiDTO);

            db.POIs.Add(poi);
            db.SaveChanges();
            poiDTO.PoiID = poi.PoiID;
            return CreatedAtRoute("DefaultApi", new { id = poiDTO.PoiID }, poiDTO);
        }

        // DELETE: api/POIs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeletePOI(int id)
        {
            POI poi = db.POIs.Find(id);
            if(poi == null)
            {
                return NotFound();
            }

            //if (poi.CheckNotOwner(User.Identity.GetUserId()))
            //{
            //    return StatusCode(HttpStatusCode.Unauthorized);
            //}

            db.POIs.Remove(poi);
            db.SaveChanges();
            return Ok();
        }


        private void copyToDto(POI poi, POIDTOReceive poiDto)
        {
            if (poiDto.Nome != null)
            {
                poi.Nome = poiDto.Nome;
            }
            if (poiDto.Descricao != null)
            {
                poi.Descricao = poiDto.Descricao;
            }
            Local local = db.Locals.Find(poiDto.LocalID);
            if (local != null)
            {
                poi.LocalID = poiDto.LocalID;
                poi.Local = local;
            }
            Categoria categoria = db.Categorias.Find(poiDto.CategoriaID);
            if (categoria != null)
            {
                poi.CategoriaID = poiDto.CategoriaID;
                poi.Categoria = categoria;
            }
            //poi.UserId = User.Identity.GetUserId();
            //poi.User = db.Users.Find(poi.UserId);
        }

        private bool POIExists(int id)
        {
            return db.POIs.Count(e => e.PoiID == id) > 0;
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
