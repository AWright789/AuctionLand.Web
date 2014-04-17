using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionLand.Web.Models
{
    public class HomeViewModel
    {
        public RealEstateSearchModel SearchModel { get; set; }
        public ICollection<RealEstateModel> FeaturedHomes { get; set; }

        public ICollection<RealEstateModel> HomesForSale { get; set; }
    }
}