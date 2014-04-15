using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AuctionLand.Data.Mapping;

namespace AuctionLand.Data.Entities.DAL
{
    public class AuctionLandDbContext: DbContext
    {
        public AuctionLandDbContext():base("AuctionLandDB")
        {

        }

        public DbSet<RealEstate> RealEstate { get; set; }
        public DbSet<RealEstateAddress> RealEstateAddress { get; set; }
        public DbSet<RealEstateAuction> RealEstateAuction { get; set; }
        public DbSet<RealEstateImage> RealEstateImage { get; set; }
     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RealEstateMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
