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
    public class RealEstatesAuctionController : ApiController
    {
        private AuctionLandDbContext db = new AuctionLandDbContext();

        // GET api/RealEstatesAuction
        public IQueryable<RealEstateAuction> GetRealEstateAuction()
        {
            return db.RealEstateAuction;
        }

        // GET api/RealEstatesAuction/5
        [ResponseType(typeof(RealEstateAuction))]
        public IHttpActionResult GetRealEstateAuction(int id)
        {
            RealEstateAuction realestateauction = db.RealEstateAuction.Find(id);
            if (realestateauction == null)
            {
                return NotFound();
            }

            return Ok(realestateauction);
        }

        // PUT api/RealEstatesAuction/5
        public IHttpActionResult PutRealEstateAuction(int id, RealEstateAuction realestateauction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != realestateauction.Id)
            {
                return BadRequest();
            }

            db.Entry(realestateauction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealEstateAuctionExists(id))
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

        // POST api/RealEstatesAuction
        [ResponseType(typeof(RealEstateAuction))]
        public IHttpActionResult PostRealEstateAuction(RealEstateAuction realestateauction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RealEstateAuction.Add(realestateauction);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RealEstateAuctionExists(realestateauction.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = realestateauction.Id }, realestateauction);
        }

        // DELETE api/RealEstatesAuction/5
        [ResponseType(typeof(RealEstateAuction))]
        public IHttpActionResult DeleteRealEstateAuction(int id)
        {
            RealEstateAuction realestateauction = db.RealEstateAuction.Find(id);
            if (realestateauction == null)
            {
                return NotFound();
            }

            db.RealEstateAuction.Remove(realestateauction);
            db.SaveChanges();

            return Ok(realestateauction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RealEstateAuctionExists(int id)
        {
            return db.RealEstateAuction.Count(e => e.Id == id) > 0;
        }
    }
}