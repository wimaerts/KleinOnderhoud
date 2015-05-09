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
    public class KlantController : ApiController
    {
        private KleinOnderhoudContext db = new KleinOnderhoudContext();

        // GET: api/Klant
        public IQueryable<Klant> GetKlanten()
        {
            return db.Klanten;
        }

        // GET: api/Klant/5
        [ResponseType(typeof(Klant))]
        public IHttpActionResult GetKlant(int id)
        {
            Klant klant = db.Klanten.Find(id);
            if (klant == null)
            {
                return NotFound();
            }

            return Ok(klant);
        }

        // PUT: api/Klant/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlant(int id, Klant klant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klant.Id)
            {
                return BadRequest();
            }

            db.Entry(klant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlantExists(id))
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

        // POST: api/Klant
        [ResponseType(typeof(Klant))]
        public IHttpActionResult PostKlant(Klant klant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Klanten.Add(klant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = klant.Id }, klant);
        }

        // DELETE: api/Klant/5
        [ResponseType(typeof(Klant))]
        public IHttpActionResult DeleteKlant(int id)
        {
            Klant klant = db.Klanten.Find(id);
            if (klant == null)
            {
                return NotFound();
            }

            db.Klanten.Remove(klant);
            db.SaveChanges();

            return Ok(klant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KlantExists(int id)
        {
            return db.Klanten.Count(e => e.Id == id) > 0;
        }
    }
}