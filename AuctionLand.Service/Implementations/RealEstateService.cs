using AuctionLand.Data.Entities;
using AuctionLand.Data.Entities.DAL;
using AuctionLand.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace AuctionLand.Service.Implementations
{
    public class RealEstateService :IRealEstateService
    {
        private IAuctionLandDbContext _db;

        public RealEstateService(IAuctionLandDbContext db)
        {
            _db = db;
        }
        public Data.Entities.RealEstate GetById(int id)
        {
            return _db.RealEstates.Find(id);
        }

        public IQueryable<RealEstate> theQuery(string myCity, string myState, string myZip, int? myMinBedrooms, int? myMinBathrooms, int? myBidPriceMin, int? myBidPriceMax, string myRealEstateType)
        {
            return _db.RealEstates.Where(r =>
                (r.City == myCity || myCity == null)
                 && (r.State == myState || myState == null)
                 && (r.Zip.ToString().Equals(myZip) || myZip == null)
                 && (r.Bedrooms >= myMinBedrooms.Value || myMinBedrooms == null)
                 && (r.Bathrooms >= myMinBathrooms.Value || myMinBathrooms == null)
                 && (r.StartingBid >= myBidPriceMin.Value || myBidPriceMin == null)
                 && (r.EndingBid <= myBidPriceMax.Value || myBidPriceMax == null)
                 && (r.RealEstateTypeId.ToString().Equals(myRealEstateType) || myRealEstateType == null)
               );
        }

        public IQueryable<RealEstate> Query(string city, string state, int? zip, int? minBedrooms, int? minBathroom, int? bidPriceMin, int? bidPriceMax, int? realEstateTypeId, DateTime? auctionStart, DateTime? auctionEnd, DateTime? saleDate)
        {
            return _db.RealEstates.Where(r =>
                (r.City == city || city == null)
                && (r.State == state || state == null)
                && (r.Zip == zip.Value || zip == null)
                && (r.Bedrooms >= minBedrooms.Value || minBedrooms == null)
                && (r.Bathrooms >= minBathroom.Value || minBathroom == null)
                && (r.StartingBid == bidPriceMin.Value || bidPriceMin == null)
                && (r.EndingBid == bidPriceMax.Value || bidPriceMax == null)
                && (r.RealEstateTypeId == realEstateTypeId.Value || realEstateTypeId == null)
                && (r.StartDate == auctionStart.Value || auctionStart == null)
                && (r.EndDate == auctionEnd.Value || auctionEnd == null)
                && (r.SaleDate == saleDate.Value || saleDate == null));
        }

        public void Update(Data.Entities.RealEstate realEstate)
        {
            _db.Entry(realEstate).State = System.Data.Entity.EntityState.Modified;
            try
            {

                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealEstateExists(realEstate.Id))
                {
                    //return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        public void Create(Data.Entities.RealEstate realEstate)
        {
            _db.RealEstates.Add(realEstate);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            RealEstate realestate = _db.RealEstates.Find(id);
            if (realestate == null)
            {
                //return NotFound();
            }
            else
            {
                _db.RealEstates.Remove(realestate);
                _db.SaveChanges();
            }
        }
        public bool RealEstateExists(int id)
        {
            return _db.RealEstates.Count(e => e.Id == id) > 0;
        }
        public IQueryable<RealEstate> GetAll()
        {
            return _db.RealEstates;
        }

        
    }
}
