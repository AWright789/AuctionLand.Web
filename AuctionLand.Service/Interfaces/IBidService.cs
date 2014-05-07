using AuctionLand.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Service.Interfaces
{
    public interface IBidService
    {
        Bid GetBidById(int id);

        void InsertBid(Bid bid, out bool error, out string errorMessage, bool allowSelfOutbid = false);

        void UpdateBid(Bid bid);

        Bid GetMaxBid(int realEstateId);


        IQueryable<Bid> GetBidsByUser(string applicationUserId);

        IQueryable<Bid> GetBidsByUserRealEstate(string applicationUserId, int realEstateId);

        IEnumerable<Bid> GetUserMaxBidWhoHaveBeenOutbidded(Bid currenMaxBid);

        void UpdateUserOutbidNotificationSent(Bid outBiddedUserBid);

        IList<Bid> GetWinningBidsByUserRealEstateId(string applicationUserId, int realEstateId);

    }

    
}
