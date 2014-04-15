using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AuctionLand.Data.Mapping
{
    internal class BaseEntityMappping<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseEntityMappping()
        {
            // Primary Key
            HasKey(t => t.Id);
        }
    }

}
