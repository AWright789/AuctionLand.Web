using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionLand.Web.Models
{
    public class RealEstateImageModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }


        public string Description { get; set; }


        public int RealEstate_Id { get; set; }

    }
}