using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Data.Entities
{
    public enum ListingStatus
    {
        Active, Sold
    }
    public enum Featured
    {
        Yes, No
    }
    public enum ListingType
    {
        Auction, BankOwned
    }
    public enum OccupancyStatus
    {
        Occupied, Vacant
    }
    public enum TypeDescription
    {
        MultiFamily, SingleFamily, Other, Land, CondoTownhome
    }
    class RealEstateTypes
    {
        public int Id { get; set; }
        public ListingStatus? ListingStatus { get; set; }
        public Featured? Featured { get; set; }
        public ListingType? ListingType { get; set; }
        public OccupancyStatus? OccupancyStatus { get; set; }
        public TypeDescription TypeDescription { get; set; }
        public virtual RealEstate RealEstate { get; set; }

    }
}
