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
        private AuctionLandDbContext db = new AuctionLandDbContext();

        public Data.Entities.RealEstate GetById(int id)
        {
            return db.RealEstate.Find(id);
        }

        public IQueryable<RealEstate> Query(string city, string state, int? zip, int? bedroom, int? bathroom, int? bidPriceMin, int? bidPriceMax, int? estateType, DateTime? auctionStart, DateTime? auctionEnd)
        {
            return db.RealEstate.Where(r =>
                (r.Address.City == city || city == null)
                && (r.Address.State == state || state == null)
                && (r.Address.Zip == zip.Value || zip == null)
                && (r.Bedrooms == bedroom.Value || bedroom == null)
                && (r.Bathrooms == bathroom.Value || bathroom == null)
                && (r.AuctionInfo.StartingBid == bidPriceMax.Value || bidPriceMax == null)
                && (r.AuctionInfo.EndingBid == bidPriceMin.Value || bidPriceMin == null)
                && (r.AuctionInfo.StartDate == auctionStart.Value || auctionStart == null)
                && (r.AuctionInfo.EndDate == auctionEnd.Value || auctionEnd == null));
        }

        public void Update(Data.Entities.RealEstate realEstate)
        {
            db.Entry(realEstate).State = System.Data.Entity.EntityState.Modified;
            try
            {

                db.SaveChanges();
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
            db.RealEstate.Add(realEstate);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            RealEstate realestate = db.RealEstate.Find(id);
            if (realestate == null)
            {
                //return NotFound();
            }
            else
            {
                db.RealEstate.Remove(realestate);
                db.SaveChanges();
            }
        }
        private bool RealEstateExists(int id)
        {
            return db.RealEstate.Count(e => e.Id == id) > 0;
        }
    }
}
