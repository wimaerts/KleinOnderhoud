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
    public class ControleController : ApiController
    {
        private KleinOnderhoudContext db = new KleinOnderhoudContext();

        // GET: api/Controle
        public IQueryable<Controle> GetControles()
        {
            return db.Controles;
        }

        // GET: api/Controle/5
        [ResponseType(typeof(Controle))]
        public IHttpActionResult GetControle(int id)
        {
            Controle controle = db.Controles.Find(id);
            if (controle == null)
            {
                return NotFound();
            }

            return Ok(controle);
        }

        // PUT: api/Controle/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutControle(int id, Controle controle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != controle.Id)
            {
                return BadRequest();
            }

            db.Entry(controle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControleExists(id))
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

        // POST: api/Controle
        [ResponseType(typeof(Controle))]
        public IHttpActionResult PostControle(Controle controle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Controles.Add(controle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = controle.Id }, controle);
        }

        // DELETE: api/Controle/5
        [ResponseType(typeof(Controle))]
        public IHttpActionResult DeleteControle(int id)
        {
            Controle controle = db.Controles.Find(id);
            if (controle == null)
            {
                return NotFound();
            }

            db.Controles.Remove(controle);
            db.SaveChanges();

            return Ok(controle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ControleExists(int id)
        {
            return db.Controles.Count(e => e.Id == id) > 0;
        }
    }
}