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
        /*
        readonly IImageService _imageService;
        public RealEstatesImageController(IImageService imageService)
        {
            _imageService = imageService;
        }*/
     
        // GET api/RealEstatesImage
        public IQueryable<RealEstateImage> GetRealEstateImages()
        {
            return null;
        }

        //// GET api/RealEstatesImage/5
        //[ResponseType(typeof(RealEstateImage))]
        //public IHttpActionResult GetRealEstateImages(int id)
        //{
        //    RealEstateImage realestateimage = db.RealEstateImages.Find(id);
        //    if (realestateimage == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(realestateimage);
        //}

        //// PUT api/RealEstatesImage/5
        //public IHttpActionResult PutRealEstateImages(int id, RealEstateImage realestateimage)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != realestateimage.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(realestateimage).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RealEstateImagesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST api/RealEstatesImage
        //[ResponseType(typeof(RealEstateImage))]
        //public IHttpActionResult PostRealEstateImages(RealEstateImage realestateimage)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.RealEstateImages.Add(realestateimage);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = realestateimage.Id }, realestateimage);
        //}

        //// DELETE api/RealEstatesImage/5
        //[ResponseType(typeof(RealEstateImage))]
        //public IHttpActionResult DeleteRealEstateImages(int id)
        //{
        //    RealEstateImage realestateimage = db.RealEstateImages.Find(id);
        //    if (realestateimage == null)
        //    {
        //        return NotFound();
        //    }

        //    db.RealEstateImages.Remove(realestateimage);
        //    db.SaveChanges();

        //    return Ok(realestateimage);
        //}

    }
}