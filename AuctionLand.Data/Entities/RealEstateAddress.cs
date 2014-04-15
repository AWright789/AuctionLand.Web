﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Data.Entities
{
    public class RealEstateAddress:BaseEntity
    {
   
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        public DbGeography Location { get; set; }

        public virtual RealEstate RealEstate { get; set; }
    }
}