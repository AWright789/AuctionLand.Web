using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
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
        public IEnumerable<RealEstateModel> FeaturedHomes { get; set; }
        public IEnumerable<RealEstateModel> HomesForSale { get; set; }

       
    }
}