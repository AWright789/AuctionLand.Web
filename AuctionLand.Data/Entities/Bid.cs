using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Data.Entities
{
    public partial class Bid:BaseEntity
    {
        public virtual int RealEstateId { get; set; }
        public virtual string ApplicationUserId { get; set; }
        public virtual decimal BidAmount { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual bool IsAutoBid { get; set; }
        public virtual bool OutBidNotificationSent { get; set; }
        public virtual bool IsWinningBid { get; set; }
        public virtual bool PaymentError { get; set; }
        public virtual string PaymentErrorMessage { get; set; }
        public bool AllowSelfOutbid { get; set; }
        public string DeviceType { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}
