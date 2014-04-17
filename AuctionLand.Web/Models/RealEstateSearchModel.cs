using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionLand.Web.Models
{
    public class RealEstateSearchModel
    {
        public string City { get; set; }

        public string Zip { get; set; }

        public string State { get; set; }

        public int MinBedrooms { get; set; }

        public int MaxBedrooms { get; set; }


        public int MinBaths { get; set; }

        public int MaxBaths { get; set; }


        public int? MinBidPrice { get; set; }

        public int? MaxBidPrice { get; set; }

        public DateTime? AuctionStartDateTime { get; set; }

        public DateTime? AuctionEndDateTime { get; set; }

        
    }
}