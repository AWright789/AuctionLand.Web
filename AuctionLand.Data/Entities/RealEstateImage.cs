using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Data.Entities
{
    public class RealEstateImage : BaseEntity
    {
        
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public virtual RealEstate RealEstate { get; set; }
    }
}
