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
using WebAPI;

namespace WebAPI.Controllers
{
    public class FacilitiesController : ApiController
    {
        private DatabaseEntityDataModel db = new DatabaseEntityDataModel();

        // GET: api/Facilities
        public IQueryable<Facility> GetFacility()
        {
            return db.Facility;
        }

        // GET: api/Facilities/5
        [ResponseType(typeof(Facility))]
        public IHttpActionResult GetFacility(int id)
        {
            Facility facility = db.Facility.Find(id);
            if (facility == null)
            {
                return NotFound();
            }

            return Ok(facility);
        }

        // PUT: api/Facilities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFacility(int id, Facility facility)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facility.Id)
            {
                return BadRequest();
            }

            db.Entry(facility).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityExists(id))
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

        // POST: api/Facilities
        [ResponseType(typeof(Facility))]
        public IHttpActionResult PostFacility(Facility facility)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Facility.Add(facility);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = facility.Id }, facility);
        }

        // DELETE: api/Facilities/5
        [ResponseType(typeof(Facility))]
        public IHttpActionResult DeleteFacility(int id)
        {
            Facility facility = db.Facility.Find(id);
            if (facility == null)
            {
                return NotFound();
            }

            db.Facility.Remove(facility);
            db.SaveChanges();

            return Ok(facility);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacilityExists(int id)
        {
            return db.Facility.Count(e => e.Id == id) > 0;
        }
    }
}