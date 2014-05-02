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
    public class BidMapping : BaseEntityMappping<Bid>
    {
        public BidMapping()
        {
            this.ToTable("Bid");



            this.HasRequired(b => b.ApplicationUser)
                .WithMany(u => u.Bids)
                .HasForeignKey(u => u.ApplicationUserId)
                .WillCascadeOnDelete(false);

        }
    }
}
