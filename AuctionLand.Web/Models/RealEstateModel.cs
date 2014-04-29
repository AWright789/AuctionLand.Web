
using AuctionLand.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace AuctionLand.Web.Models
{
    public class RealEstateModel
    {

        public RealEstateModel()
        {
            RealEstateImageModels = new List<RealEstateImageModel>();
        }
        public int Id { get; set; }
        [Display(Name="Year Built")]
        public int YearBuilt { get; set; }
        public string Summary { get; set; }
        [Display(Name="Sq.Ft")]
        public double EstateSize { get; set; }
        public double LotSize { get; set; }
        public int Bedrooms { get; set; }
        public double Bathrooms { get; set; }
        [Display(Name="Listing Status")]
        public int ListingStatusId { get; set; }

     
        public bool Featured { get; set; }
        [Display(Name = "Listing Type")]
        public int ListingTypeId { get; set; }


        [Display(Name = "Occupancy Status")]
        public int OccupancyStatusId { get; set; }

        [Display(Name = "Realestate Type")]
        public int RealEstateTypeId { get; set; }

      
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


        public string DefaultImageUrl
        {
            get
            {
                if (this.RealEstateImageModels.FirstOrDefault() != null)
                {
                    return this.RealEstateImageModels.FirstOrDefault().ImageUrl ?? string.Empty;
                }
                return string.Empty;
            }
            set
            {

            }
        }
        public DateTime? SaleDate { get; set; }

        public IEnumerable<RealEstateImageModel> RealEstateImageModels { get; set; }
        public ListingStatus? ListingStatus
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
        public RealEstateType? RealEstateType
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
    }
}