using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionLand.Web.Models
{
    public class BidModel
    {
        public int RealEstateId { get; set; }
        public string BidderName { get; set; }
        public string BidderId { get; set; }
        public double BidAmount { get; set; }
        public bool IsWinningBid { get; set; }
        public DateTime CreateDate { get; set; }

    }
}