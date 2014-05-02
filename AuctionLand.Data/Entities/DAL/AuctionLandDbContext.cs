using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AuctionLand.Data.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuctionLand.Data.Entities.DAL
{
    public class AuctionLandDbContext : IdentityDbContext<ApplicationUser>, IAuctionLandDbContext
    {
        public AuctionLandDbContext():base("AuctionLandDB")
        {

        }

        public DbSet<RealEstate> RealEstates { get; set; }
       
        public DbSet<RealEstateImage> RealEstateImages { get; set; }

        public DbSet<Bid> Bids { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RealEstateMapping());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
