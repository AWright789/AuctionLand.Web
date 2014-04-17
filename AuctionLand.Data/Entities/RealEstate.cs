using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Data.Entities
{
     public class RealEstate:BaseEntity
    {
  
        public int YearBuilt { get; set; }
        public string Summary { get; set; }
        public double EstateSize { get; set; }
        public double LotSize { get; set; }
        public int Bedrooms { get; set; }
        public double Bathrooms { get; set; }

        public int ListingStatusId { get; set; }

        public ListingStatus ListingStatus
        {
            get
            {
                return (ListingStatus)ListingStatusId;
            }
            set
            {
                ListingStatusId = (int)value;
            }
        }
        public bool Featured { get; set; }

        public int ListingTypeId { get; set; }

        public ListingType? ListingType
        {
            get
            {
                return (ListingType)ListingTypeId;
            }
            set
            {
                ListingTypeId = (int)value;
            }
        }


        public int OccupancyStatusId { get; set; }

        public OccupancyStatus? OccupancyStatus
        {
            get
            {
                return (OccupancyStatus)OccupancyStatusId;
            }
            set
            {
                OccupancyStatusId = (int)value;
            }
        }
       
        public int RealEstateTypeId { get; set; }

        public virtual RealEstateType RealEstateType
        {
            get
            {
                return (RealEstateType)RealEstateTypeId;
            }
            set
            {
                RealEstateTypeId = (int)value;
            }
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        public DbGeography Location { get; set; }



        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double StartingBid { get; set; }
        public double EndingBid { get; set; }
        public double BidIncrement { get; set; }


     
        public virtual List<RealEstateImage> RealEstateImages { get; set; }
    }
}
