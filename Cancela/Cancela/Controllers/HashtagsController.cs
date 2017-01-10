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
    public class HashtagsController : ApiController
    {
        private DatumContext db = new DatumContext();

        // GET: api/Hashtags
        public IEnumerable<HashTagModel> GetHashtags()
        {
            IEnumerable<Hashtag> hashList = db.Hashtags.ToList();
            List<HashTagModel> newHashList = new List<HashTagModel>();

            foreach (var hash in hashList)
            {
                Hashtag newHashtag = db.Hashtags.Include(l => l.POIs).Where(l => l.ID == hash.ID).SingleOrDefault();
                HashTagModel newMdl = new HashTagModel(hash);
                newHashList.Add(newMdl);
            }

            return newHashList;
        }

        // GET: api/Hashtags/5
        [ResponseType(typeof(HashTagModel))]
        public IHttpActionResult GetHashtag(int id)
        {
            Hashtag hashtag= db.Hashtags.Include(l => l.POIs).Where(l => l.ID == id).SingleOrDefault();

            if (hashtag == null)
            {
                return NotFound();
            }
            HashTagModel newMdlHash = new HashTagModel(hashtag);

            return Ok(newMdlHash);
        }

        // PUT: api/Hashtags/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHashtag(int id, Hashtag hashtag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hashtag.ID)
            {
                return BadRequest();
            }

            db.Entry(hashtag).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HashtagExists(id))
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

        // POST: api/Hashtags
        [ResponseType(typeof(Hashtag))]
        public IHttpActionResult PostHashtag(Hashtag hashtag,List<int> poi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Hashtag hashtagUpdate = db.Hashtags.Find(hashtag.ID);
            atualizarPoiDoHashTag(hashtagUpdate, poi);
            db.Hashtags.Add(hashtag);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hashtag.ID }, hashtag);
        }

        private void atualizarPoiDoHashTag(Hashtag hashtagParaAtualizar, List<int> selectedPOI)
        {
            if (selectedPOI==null)
            {
                hashtagParaAtualizar.POIs = new List<POI>();
                return;
            }
            var selectedPoiHS = new HashSet<int>(selectedPOI);
            var poiHashtag = new HashSet<int>(hashtagParaAtualizar.POIs.Select(a => a.PoiID));

            var POIs = db.POIs;
            foreach (var poi in POIs)
            {
                 if (selectedPoiHS.Contains(poi.PoiID))
                    {
                
                        if (!poiHashtag.Contains(poi.PoiID))
                        {
                            hashtagParaAtualizar.POIs.Add(poi);
                       }
                    }
                    else
                    {
                        if (poiHashtag.Contains(poi.PoiID))
                       {
                           hashtagParaAtualizar.POIs.Remove(poi);
                       }
                    }
                }
            }
        

        // DELETE: api/Hashtags/5
        [ResponseType(typeof(Hashtag))]
        public async Task<IHttpActionResult> DeleteHashtag(int id)
        {
            Hashtag hashtag = await db.Hashtags.FindAsync(id);
            if (hashtag == null)
            {
                return NotFound();
            }

            db.Hashtags.Remove(hashtag);
            await db.SaveChangesAsync();

            return Ok(hashtag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HashtagExists(int id)
        {
            return db.Hashtags.Count(e => e.ID == id) > 0;
        }
    }
}