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
        public static RealEstate ToEntity(this RealEstateModel model)
        {
            return Mapper.Map<RealEstate>(model);
        }
        public static RealEstate ToEntity(this RealEstateModel model, RealEstate entity)
        {
            return Mapper.Map<RealEstateModel, RealEstate>(model, entity);
        }

        public static RealEstateImageModel ToModel(this RealEstateImage entity)
        {
            return Mapper.Map<RealEstateImageModel>(entity);
        }
        public static RealEstateImage ToEntity(this RealEstateImageModel model)
        {
            return Mapper.Map<RealEstateImage>(model);
        }
        public static RealEstateImage ToEntity(this RealEstateImageModel model, RealEstateImage entity)
        {
            return Mapper.Map<RealEstateImageModel, RealEstateImage>(model, entity);
        }

        public static BidModel ToModel(this Bid entity)
        {
            return Mapper.Map<Bid, BidModel>(entity);
        }
        

    }
}