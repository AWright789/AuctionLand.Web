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
            this.ToTable("RealEstate");
            this.Ignore(r => r.ListingStatus);
            this.Ignore(r => r.ListingType);
            this.Ignore(r => r.RealEstateType);
            this.Ignore(r => r.OccupancyStatus);

           
            this.HasMany(r => r.RealEstateImages)
                .WithRequired(ri => ri.RealEstate)
                .WillCascadeOnDelete(true);
        }
    }
}
