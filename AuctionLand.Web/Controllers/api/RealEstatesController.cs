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
using AuctionLand.Data.Entities;
using AuctionLand.Data.Entities.DAL;

namespace AuctionLand.Web.Controllers.api
{
    public class RealEstatesController : ApiController
    {
        private AuctionLandDbContext db = new AuctionLandDbContext();

        // GET api/RealEstates
        public IQueryable<RealEstate> GetRealEstate()
        {
            return db.RealEstate;
        }

        // GET api/RealEstates/5
        [ResponseType(typeof(RealEstate))]
        public IHttpActionResult GetRealEstate(int id)
        {
            RealEstate realestate = db.RealEstate.Find(id);
            if (realestate == null)
            {
                return NotFound();
            }

            return Ok(realestate);
        }

        // PUT api/RealEstates/5
        public IHttpActionResult PutRealEstate(int id, RealEstate realestate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != realestate.Id)
            {
                return BadRequest();
            }

            db.Entry(realestate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealEstateExists(id))
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

        // POST api/RealEstates
        [ResponseType(typeof(RealEstate))]
        public IHttpActionResult PostRealEstate(RealEstate realestate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RealEstate.Add(realestate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = realestate.Id }, realestate);
        }

        // DELETE api/RealEstates/5
        [ResponseType(typeof(RealEstate))]
        public IHttpActionResult DeleteRealEstate(int id)
        {
            RealEstate realestate = db.RealEstate.Find(id);
            if (realestate == null)
            {
                return NotFound();
            }

            db.RealEstate.Remove(realestate);
            db.SaveChanges();

            return Ok(realestate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RealEstateExists(int id)
        {
            return db.RealEstate.Count(e => e.Id == id) > 0;
        }
    }
}