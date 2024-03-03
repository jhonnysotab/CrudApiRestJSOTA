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
using CrudApiRestJSOTA.Models;

namespace CrudApiRestJSOTA.Controllers
{
    public class ProfesorsController : ApiController
    {
        private MVCCRUDJSEntities db = new MVCCRUDJSEntities();

        // GET: api/Profesors
        public IQueryable<Profesor> GetProfesor()
        {
            return db.Profesor;
        }

        // GET: api/Profesors/5
        [ResponseType(typeof(Profesor))]
        public IHttpActionResult GetProfesor(int id)
        {
            Profesor profesor = db.Profesor.Find(id);
            if (profesor == null)
            {
                return NotFound();
            }

            return Ok(profesor);
        }

        // PUT: api/Profesors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfesor(int id, Profesor profesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesor.id)
            {
                return BadRequest();
            }

            db.Entry(profesor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesorExists(id))
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

        // POST: api/Profesors
        [ResponseType(typeof(Profesor))]
        public IHttpActionResult PostProfesor(Profesor profesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profesor.Add(profesor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profesor.id }, profesor);
        }

        // DELETE: api/Profesors/5
        [ResponseType(typeof(Profesor))]
        public IHttpActionResult DeleteProfesor(int id)
        {
            Profesor profesor = db.Profesor.Find(id);
            if (profesor == null)
            {
                return NotFound();
            }

            db.Profesor.Remove(profesor);
            db.SaveChanges();

            return Ok(profesor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfesorExists(int id)
        {
            return db.Profesor.Count(e => e.id == id) > 0;
        }
    }
}