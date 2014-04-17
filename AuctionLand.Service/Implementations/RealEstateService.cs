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

        public IQueryable<RealEstate> Query(string city, string state, int? zip, int? bedroom, int? bathroom, int? bidPriceMin, int? bidPriceMax, int? estateType, DateTime? auctionStart, DateTime? auctionEnd)
        {
            return _db.RealEstates.Where(r =>
                (r.City == city || city == null)
                && (r.State == state || state == null)
                && (r.Zip == zip.Value || zip == null)
                && (r.Bedrooms == bedroom.Value || bedroom == null)
                && (r.Bathrooms == bathroom.Value || bathroom == null)
                && (r.StartingBid == bidPriceMax.Value || bidPriceMax == null)
                && (r.EndingBid == bidPriceMin.Value || bidPriceMin == null)
                && (r.StartDate == auctionStart.Value || auctionStart == null)
                && (r.EndDate == auctionEnd.Value || auctionEnd == null));
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
        private bool RealEstateExists(int id)
        {
            return _db.RealEstates.Count(e => e.Id == id) > 0;
        }
    }
}
