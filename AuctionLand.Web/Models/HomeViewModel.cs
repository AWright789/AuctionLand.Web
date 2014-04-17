using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionLand.Web.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            FeaturedHomes = new List<RealEstateModel>();
            HomesForSale = new List<RealEstateModel>();
            SearchModel = new RealEstateSearchModel();
        }
        public RealEstateSearchModel SearchModel { get; set; }
        public IList<RealEstateModel> FeaturedHomes { get; set; }

        public IList<RealEstateModel> HomesForSale { get; set; }
    }
}