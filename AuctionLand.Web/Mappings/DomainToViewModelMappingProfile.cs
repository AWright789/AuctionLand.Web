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
             Mapper.CreateMap<RealEstate, RealEstateModel>()
                 .ForMember(dest => dest.RealEstateImageModels, opt => opt.MapFrom(src => src.RealEstateImages));
             Mapper.CreateMap<RealEstateImage, RealEstateImageModel>();

             Mapper.CreateMap<Bid, BidModel>()
                 .ForMember(dest => dest.BidderName, opt => opt.Ignore())
                 .ForMember(dest => dest.BidderId, opt => opt.MapFrom(src => src.ApplicationUserId));
         }
    }
}