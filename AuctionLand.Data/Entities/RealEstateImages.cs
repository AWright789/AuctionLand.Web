using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Data.Entities
{
    class RealEstateImages
    {
        public int Id { get; set; }
        public string EstateImage { get; set; }
        public virtual RealEstate RealEstate { get; set; }
    }
}
