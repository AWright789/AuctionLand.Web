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

        IQueryable<RealEstate> Query(string city, string state, int? zip, int? bedroom, int? bathroom, int? bidPriceMin, int? bidPriceMax, int? estateType, DateTime? auctionStart, DateTime? auctionEnd);
        void Update(RealEstate realEstate);
        void Create(RealEstate realEstate);
        void Delete(int id);
    }
}
