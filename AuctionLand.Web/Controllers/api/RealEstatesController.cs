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
using AuctionLand.Service.Interfaces;
using AuctionLand.Service.Implementations;

namespace AuctionLand.Web.Controllers.api
{
    public class RealEstatesController : ApiController
    {
        readonly IRealEstateService _realEstateService;
         public RealEstatesController(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }
        // GET api/RealEstates
        public IQueryable<RealEstate> GetRealEstate()
        {
            return _realEstateService.Query(null,null,null,null,null,null,null,null,null,null,null);
        }

        // GET api/RealEstates/5
        [ResponseType(typeof(RealEstate))]
        public IHttpActionResult GetRealEstate(int id)
        {
            RealEstate realestate = _realEstateService.GetById(id);
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

           // db.Entry(realestate).State = EntityState.Modified;
            _realEstateService.Update(realestate);
            /*try
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
            }*/
             

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
            _realEstateService.Create(realestate);
           // db.RealEstate.Add(realestate);
            //db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = realestate.Id }, realestate);
        }

        // DELETE api/RealEstates/5
        [ResponseType(typeof(RealEstate))]
        public IHttpActionResult DeleteRealEstate(int id)
        {
            _realEstateService.Delete(id);
            RealEstate realestate = _realEstateService.GetById(id);
            if (realestate == null)
            {
                return NotFound();
            }
            /*
            db.RealEstate.Remove(realestate);
            db.SaveChanges();
            */

            return Ok(realestate);
        }

      
    }
}