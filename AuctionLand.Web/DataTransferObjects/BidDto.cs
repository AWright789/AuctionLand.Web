using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionLand.Web.DataTransferObjects
{
    public class BidDto 
    {
        public virtual int Id { get; set; }
        public virtual int RealEstateId { get; set; }
        public virtual int ApplicationUserId { get; set; }
        public virtual decimal BidAmount { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual bool IsAutoBid { get; set; }
        public bool BidSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string BidderHandle { get; set; }
        public bool IsWinningBid { get; set; }
        public string BidderName { get; set; }
        public bool IsWinner { get; set; }
        public bool PaymentInformationNeed { get; set; }
        public bool IsOutbidError { get; set; }
        public bool AllowSelfOutbid { get; set; }
        public bool IsSelfOutBidError { get; set; }
        public string DeviceType { get; set; }
        public decimal HighBidAmount { get; set; }
        public bool Winning { get; set; }
        public int LosingByCount { get; set; }
        public int BidCount { get; set; }
        public int BidderCount { get; set; }
        public decimal CeilingBidAmount { get; set; }

    }
}