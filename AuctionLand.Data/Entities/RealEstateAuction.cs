﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Data.Entities
{
    class RealEstateAuction
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double StartingBid { get; set; }
        public double EndingBid { get; set; }
        public double BidIncrement { get; set; }

        public virtual RealEstate RealEstate { get; set; }
    }
}
