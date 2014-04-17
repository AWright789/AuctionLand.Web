using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Configuration;
using AuctionLand.Data.Entities;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AuctionLand.Data.Mapping
{
    public class RealEstateMapping : BaseEntityMappping<RealEstate>
    {
        public RealEstateMapping()
        {

            this.Ignore(r => r.ListingStatus);
            this.Ignore(r => r.ListingType);
            this.Ignore(r => r.RealEstateType);
            this.Ignore(r => r.OccupancyStatus);


            this.HasOptional(r => r.Address)
                .WithRequired(a => a.RealEstate).WillCascadeOnDelete(true);

            this.HasOptional(r => r.AuctionInfo)
                .WithRequired(a => a.RealEstate).WillCascadeOnDelete(true);


            this.HasMany(r => r.RealEstateImages)
                .WithRequired(ri => ri.RealEstate)
                .WillCascadeOnDelete(true);
        }
    }
}
