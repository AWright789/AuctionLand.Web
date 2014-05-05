using AuctionLand.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Service.Interfaces
{
    public interface IRealEstateService
    {
        RealEstate GetById(int id);

        IQueryable<RealEstate> Query(string city, string state, int? zip, int? bedroom, int? bathroom, int? bidPriceMin, int? bidPriceMax, int? realEstateTypeId, DateTime? auctionStart, DateTime? auctionEnd, DateTime? saleDate);

        IQueryable<RealEstate> theQuery(string myCity, string myState, int? myZip, int? myMinBedrooms);

        void Update(RealEstate realEstate);
        void Create(RealEstate realEstate);
        void Delete(int id);
        IQueryable<RealEstate> GetAll();
        bool RealEstateExists(int id);
    }
}
