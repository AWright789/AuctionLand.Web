using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AuctionLand.Data.Entities.DAL
{
    class RealEstateContext:DbContext
    {
        public RealEstateContext():base("AuctionLand")
        {

        }

        public DbSet<RealEstate> RealEstate { get; set; }
        public DbSet<RealEstateAddress> RealEstateAddress { get; set; }
        public DbSet<RealEstateAuction> RealEstateAuction { get; set; }
        public DbSet<RealEstateImages> RealEstateImage { get; set; }
        public DbSet<RealEstateTypes> RealEstateTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
