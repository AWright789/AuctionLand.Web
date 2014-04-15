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
    public class RealEstatesImageController : ApiController
    {
        private AuctionLandDbContext db = new AuctionLandDbContext();

        // GET api/RealEstatesImage
        public IQueryable<RealEstateImage> GetRealEstateImage()
        {
            return db.RealEstateImage;
        }

        // GET api/RealEstatesImage/5
        [ResponseType(typeof(RealEstateImage))]
        public IHttpActionResult GetRealEstateImage(int id)
        {
            RealEstateImage realestateimage = db.RealEstateImage.Find(id);
            if (realestateimage == null)
            {
                return NotFound();
            }

            return Ok(realestateimage);
        }

        // PUT api/RealEstatesImage/5
        public IHttpActionResult PutRealEstateImage(int id, RealEstateImage realestateimage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != realestateimage.Id)
            {
                return BadRequest();
            }

            db.Entry(realestateimage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealEstateImageExists(id))
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

        // POST api/RealEstatesImage
        [ResponseType(typeof(RealEstateImage))]
        public IHttpActionResult PostRealEstateImage(RealEstateImage realestateimage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RealEstateImage.Add(realestateimage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = realestateimage.Id }, realestateimage);
        }

        // DELETE api/RealEstatesImage/5
        [ResponseType(typeof(RealEstateImage))]
        public IHttpActionResult DeleteRealEstateImage(int id)
        {
            RealEstateImage realestateimage = db.RealEstateImage.Find(id);
            if (realestateimage == null)
            {
                return NotFound();
            }

            db.RealEstateImage.Remove(realestateimage);
            db.SaveChanges();

            return Ok(realestateimage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RealEstateImageExists(int id)
        {
            return db.RealEstateImage.Count(e => e.Id == id) > 0;
        }
    }
}