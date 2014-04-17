using AuctionLand.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionLand.Web.Models
{
    public class RealEstateModel
    {
        public int YearBuilt { get; set; }
        public string Summary { get; set; }
        public double EstateSize { get; set; }
        public double LotSize { get; set; }
        public int Bedrooms { get; set; }
        public double Bathrooms { get; set; }

        public int ListingStatusId { get; set; }

     
        public bool Featured { get; set; }

        public int ListingTypeId { get; set; }

     

        public int OccupancyStatusId { get; set; }


        public int RealEstateTypeId { get; set; }

      
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double StartingBid { get; set; }
        public double EndingBid { get; set; }
        public double BidIncrement { get; set; }


    }
}