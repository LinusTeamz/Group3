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
    public class FacilitiesBookedController : ApiController
    {
        private DatabaseEntityDataModel db = new DatabaseEntityDataModel();

        // GET: api/FacilitiesBooked
        public IQueryable<FacilitiesBooked> GetFacilitiesBooked()
        {
            return db.FacilitiesBooked;
        }

        // GET: api/FacilitiesBooked/5
        [ResponseType(typeof(FacilitiesBooked))]
        public IHttpActionResult GetFacilitiesBooked(int id)
        {
            FacilitiesBooked facilitiesBooked = db.FacilitiesBooked.Find(id);
            if (facilitiesBooked == null)
            {
                return NotFound();
            }

            return Ok(facilitiesBooked);
        }

        // PUT: api/FacilitiesBooked/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFacilitiesBooked(int id, FacilitiesBooked facilitiesBooked)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facilitiesBooked.Id)
            {
                return BadRequest();
            }

            db.Entry(facilitiesBooked).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilitiesBookedExists(id))
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

        // POST: api/FacilitiesBooked
        [ResponseType(typeof(FacilitiesBooked))]
        public IHttpActionResult PostFacilitiesBooked(FacilitiesBooked facilitiesBooked)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FacilitiesBooked.Add(facilitiesBooked);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = facilitiesBooked.Id }, facilitiesBooked);
        }

        // DELETE: api/FacilitiesBooked/5
        [ResponseType(typeof(FacilitiesBooked))]
        public IHttpActionResult DeleteFacilitiesBooked(int id)
        {
            FacilitiesBooked facilitiesBooked = db.FacilitiesBooked.Find(id);
            if (facilitiesBooked == null)
            {
                return NotFound();
            }

            db.FacilitiesBooked.Remove(facilitiesBooked);
            db.SaveChanges();

            return Ok(facilitiesBooked);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacilitiesBookedExists(int id)
        {
            return db.FacilitiesBooked.Count(e => e.Id == id) > 0;
        }
    }
}