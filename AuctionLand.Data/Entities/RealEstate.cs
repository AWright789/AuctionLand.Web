using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Data.Entities
{
    class RealEstate
    {
        public int RealEstateId { get; set; }
        public int YearBuilt { get; set; }
        public string Summary { get; set; }
        public double EstateSize { get; set; }
        public double LotSize { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public virtual RealEstateAddress Address { get; set; }
        public virtual RealEstateAuction AuctionInfo { get; set; }
        public virtual RealEstateTypes RealStateTypes { get; set; }
        public virtual List<RealEstateImages> RealEstateImages { get; set; }
    }
}
