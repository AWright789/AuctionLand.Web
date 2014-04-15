using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Data.Entities
{
    public enum ListingStatus
    {
        Active, Sold, Inactive
    }

    public enum ListingType
    {
        Auction, BankOwned
    }
    public enum OccupancyStatus
    {
        Occupied, Vacant
    }
    public enum RealEstateType
    {
        MultiFamily, SingleFamily, Other, Land, CondoTownhome
    }
}
