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
    public class RealEstatesAddressController : ApiController
    {
        private AuctionLandDbContext db = new AuctionLandDbContext();

        // GET api/RealEstatesAddress
        public IQueryable<RealEstateAddress> GetRealEstateAddress()
        {
            return db.RealEstateAddress;
        }

        // GET api/RealEstatesAddress/5
        [ResponseType(typeof(RealEstateAddress))]
        public IHttpActionResult GetRealEstateAddress(int id)
        {
            RealEstateAddress realestateaddress = db.RealEstateAddress.Find(id);
            if (realestateaddress == null)
            {
                return NotFound();
            }

            return Ok(realestateaddress);
        }

        // PUT api/RealEstatesAddress/5
        public IHttpActionResult PutRealEstateAddress(int id, RealEstateAddress realestateaddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != realestateaddress.Id)
            {
                return BadRequest();
            }

            db.Entry(realestateaddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealEstateAddressExists(id))
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

        // POST api/RealEstatesAddress
        [ResponseType(typeof(RealEstateAddress))]
        public IHttpActionResult PostRealEstateAddress(RealEstateAddress realestateaddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RealEstateAddress.Add(realestateaddress);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RealEstateAddressExists(realestateaddress.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = realestateaddress.Id }, realestateaddress);
        }

        // DELETE api/RealEstatesAddress/5
        [ResponseType(typeof(RealEstateAddress))]
        public IHttpActionResult DeleteRealEstateAddress(int id)
        {
            RealEstateAddress realestateaddress = db.RealEstateAddress.Find(id);
            if (realestateaddress == null)
            {
                return NotFound();
            }

            db.RealEstateAddress.Remove(realestateaddress);
            db.SaveChanges();

            return Ok(realestateaddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RealEstateAddressExists(int id)
        {
            return db.RealEstateAddress.Count(e => e.Id == id) > 0;
        }
    }
}