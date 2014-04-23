using AuctionLand.Data.Entities;
using AuctionLand.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionLand.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
         public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

         protected override void Configure()
         {
             Mapper.CreateMap<RealEstate, RealEstateModel>();
             Mapper.CreateMap<RealEstateImage, RealEstateImageModel>();
         }
    }
}