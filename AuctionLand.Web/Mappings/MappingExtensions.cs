using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AuctionLand.Data.Entities;
using AuctionLand.Web.Models;

namespace AuctionLand.Web.Mappings
{
    public static class MappingExtensions
    {
        public static RealEstateModel ToModel(this RealEstate entity){
            return Mapper.Map<RealEstateModel>(entity);

        }
    }
}