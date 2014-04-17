using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AuctionLand.Data.Entities;
using AuctionLand.Web.Models;
using AuctionLand.Web.Mappings;

namespace AuctionLand.Web.App_Start
{
    public  class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
        public static void Map()
        {
            
            

        }
    }
}