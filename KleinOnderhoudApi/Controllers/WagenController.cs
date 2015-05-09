using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KleinOnderhoudApi.DAL;
using KleinOnderhoudApi.Models;

namespace KleinOnderhoudApi.Controllers
{
    public class WagenController : ApiController
    {
        private KleinOnderhoudContext db = new KleinOnderhoudContext();

        // GET: api/Wagen
        public IQueryable<Wagen> GetWagens()
        {
            return db.Wagens;
        }

        // GET: api/Wagen/5
        [ResponseType(typeof(Wagen))]
        public IHttpActionResult GetWagen(int id)
        {
            Wagen wagen = db.Wagens.Find(id);
            if (wagen == null)
            {
                return NotFound();
            }

            return Ok(wagen);
        }

        // PUT: api/Wagen/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWagen(int id, Wagen wagen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wagen.Id)
            {
                return BadRequest();
            }

            db.Entry(wagen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WagenExists(id))
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

        // POST: api/Wagen
        [ResponseType(typeof(Wagen))]
        public IHttpActionResult PostWagen(Wagen wagen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wagens.Add(wagen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wagen.Id }, wagen);
        }

        // DELETE: api/Wagen/5
        [ResponseType(typeof(Wagen))]
        public IHttpActionResult DeleteWagen(int id)
        {
            Wagen wagen = db.Wagens.Find(id);
            if (wagen == null)
            {
                return NotFound();
            }

            db.Wagens.Remove(wagen);
            db.SaveChanges();

            return Ok(wagen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WagenExists(int id)
        {
            return db.Wagens.Count(e => e.Id == id) > 0;
        }
    }
}