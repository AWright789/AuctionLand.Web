using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Data.Entities.DAL
{
    public interface IAuctionLandDbContext
    {

         IDbSet<IdentityRole> Roles { get; set; }
         IDbSet<ApplicationUser> Users { get; set; }
         DbSet<RealEstate> RealEstates { get; set; }

         DbSet<RealEstateImage> RealEstateImages { get; set; }
         DbSet<Bid> Bids { get; set; }

         int SaveChanges();

         DbEntityEntry Entry(object entity);
         DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
     

    }
}
