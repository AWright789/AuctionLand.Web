using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionLand.Data.Entities.DAL;
using AuctionLand.Data.Entities;
using AuctionLand.Service.Exceptions;
using AuctionLand.Service.Interfaces;

namespace AuctionLand.Service.Implementations
{
    public class BidService : IBidService
    {

        private IAuctionLandDbContext _db;


        public BidService(IAuctionLandDbContext db)
        {
            _db = db;
        }


        public Data.Entities.Bid GetBidById(int id)
        {
            return (from b in _db.Bids
                    where b.Id == id
                    select b).FirstOrDefault();
        }

        public void InsertBid(Bid bid, out bool error, out string errorMessage, bool allowSelfOutbid = false)
        {
            if (bid == null)
                throw new ArgumentNullException("bid");

            error = false;
            errorMessage = string.Empty;
            var realEstate = (from r in _db.RealEstates where r.Id == bid.RealEstateId select r).First();
        
            var highestNonAutoBid = (from b in _db.Bids
                                     where b.RealEstateId == bid.RealEstateId && !b.IsAutoBid
                                     orderby b.BidAmount descending
                                     select b).FirstOrDefault();

            var highestBidOfAll = (from b in _db.Bids
                                   where b.RealEstateId == bid.RealEstateId
                                   orderby b.BidAmount descending
                                   select b).FirstOrDefault();



            var matchingCeilingBid = (from b in _db.Bids
                                      where b.RealEstateId == bid.RealEstateId  && b.BidAmount == bid.BidAmount
                                      orderby b.BidAmount descending
                                      select b).FirstOrDefault();


            bool isAlreadyHighBidder = (highestBidOfAll != null) && (highestBidOfAll.ApplicationUserId == bid.ApplicationUserId);

            if (isAlreadyHighBidder && !bid.AllowSelfOutbid)
                throw new OutbidSelfException();
            

            //check for already existing bid
            if ((matchingCeilingBid != null))
            {
                if (matchingCeilingBid.ApplicationUserId != bid.ApplicationUserId)
                {

                    if (matchingCeilingBid.IsAutoBid)
                    {
                        matchingCeilingBid.IsAutoBid = false;
                        _db.SaveChanges();
                    }
                    //scope.Complete();
                    throw new OutBidException(errorMessage);
                }
            }
            else
            {
                if (!bid.IsAutoBid)
                {
                    _db.Bids.Add(bid);
                    
                    var lowerAutoBids = (from b in _db.Bids
                                         where b.RealEstateId == bid.RealEstateId  && b.IsAutoBid && b.BidAmount < bid.BidAmount
                                         orderby b.BidAmount descending
                                         select b).ToList();
                    foreach (var lowerAutoBid in lowerAutoBids)
                        lowerAutoBid.IsAutoBid = false;
                        
                    
                    _db.SaveChanges();
                }
                else
                {

                    decimal calculatedHighBidAmount = realEstate.StartingBid;
                    decimal ceilingBidAmount = bid.BidAmount;

                    //if it is a auto bid we must determine the bid amount
                    if ((highestNonAutoBid != null))
                        calculatedHighBidAmount = highestNonAutoBid.BidAmount + realEstate.BidIncrement;

                    if (calculatedHighBidAmount == ceilingBidAmount)
                    {
                        bid.IsAutoBid = false;
                        _db.Bids.Add(bid);
                        var lowerAutoBids = (from b in _db.Bids
                                             where b.RealEstateId == bid.RealEstateId  && b.IsAutoBid && b.BidAmount < bid.BidAmount
                                             orderby b.BidAmount descending
                                             select b).ToList();
                        foreach (var lowerAutoBid in lowerAutoBids)
                            _db.SaveChanges();
                        
                        _db.SaveChanges();
                    }
                    else
                    {
                        if (calculatedHighBidAmount > ceilingBidAmount)
                        {
                            bid.IsAutoBid = false;
                            _db.Bids.Add(bid);
                            var lowerAutoBids = (from b in _db.Bids
                                                 where b.RealEstateId == bid.RealEstateId  && b.IsAutoBid && b.BidAmount < bid.BidAmount
                                                 orderby b.BidAmount descending
                                                 select b).ToList();
                            foreach (var lowerAutoBid in lowerAutoBids)
                                lowerAutoBid.IsAutoBid = false;
                            
                            _db.SaveChanges();
                            
                        }
                        else
                        {
                            //we must make two entries. One at their highest willingness to pay as auto bid and another at the current highest bid + increment
                            //insert their auto bid

                            if ((highestBidOfAll != null) && (highestBidOfAll.BidAmount >= ceilingBidAmount) && (highestBidOfAll.ApplicationUserId != bid.ApplicationUserId))
                            {
                                bid.IsAutoBid = false;
                                _db.Bids.Add(bid);
                            }
                            else
                            {
                                if ((highestBidOfAll != null) && (highestBidOfAll.ApplicationUserId != bid.ApplicationUserId))
                                {
                                    if (highestBidOfAll.IsAutoBid)
                                        if (highestBidOfAll.BidAmount + realEstate.BidIncrement == bid.BidAmount)
                                            bid.IsAutoBid = false;

                                    highestBidOfAll.IsAutoBid = false;
                                    _db.SaveChanges();
                                    
                                }

                                if
                                    ((highestBidOfAll != null) && (highestBidOfAll.ApplicationUserId == bid.ApplicationUserId) && (highestBidOfAll.BidAmount < bid.BidAmount))
                                {
                                    highestBidOfAll.BidAmount = bid.BidAmount;
                                    _db.SaveChanges();
                                }
                                else if ((highestBidOfAll == null) || ((highestBidOfAll != null) && (highestBidOfAll.ApplicationUserId != bid.ApplicationUserId)))
                                {
                                    _db.Bids.Add(bid); // new ceiling bid for same customer
                                    _db.SaveChanges();
                                }


                                var lowerAutoBids = (from b in _db.Bids
                                                     where b.RealEstateId == bid.RealEstateId  && b.IsAutoBid && b.BidAmount < bid.BidAmount
                                                     orderby b.BidAmount descending
                                                     select b).ToList();
                                foreach (var lowerAutoBid in lowerAutoBids)
                                {
                                    lowerAutoBid.IsAutoBid = false;
                                    _db.SaveChanges();
                                }

                                //first check to see if there is another bid at the auto calculated amount
                                var currentHighestFloor = (from b in _db.Bids
                                                           where b.RealEstateId == bid.RealEstateId  && b.BidAmount < bid.BidAmount
                                                           orderby b.BidAmount descending
                                                           select b).FirstOrDefault();
                                if ((currentHighestFloor == null) || (currentHighestFloor.ApplicationUserId != bid.ApplicationUserId))
                                {
                                    //insert floor bid
                                    var floorBid = new Bid
                                    {
                                        BidAmount = (currentHighestFloor == null) ? calculatedHighBidAmount : currentHighestFloor.BidAmount + realEstate.BidIncrement,
                                        CreateDate = DateTime.UtcNow,
                                        ApplicationUserId = bid.ApplicationUserId,
                                        
                                        IsAutoBid = false,
                                       
                                        RealEstateId = bid.RealEstateId,
                                        
                                        DeviceType = bid.DeviceType
                                    };
                                    _db.Bids.Add(floorBid);
                                    _db.SaveChanges();
                                }

                            }
                        }
                    }
                }
            }

            var highestNonAutoBid2 = (from b in _db.Bids
                                      where b.RealEstateId == bid.RealEstateId  && !b.IsAutoBid
                                      orderby b.BidAmount descending
                                      select b).FirstOrDefault();

            var highestBidOfAll2 = (from b in _db.Bids
                                    where b.RealEstateId == bid.RealEstateId 
                                    orderby b.BidAmount descending
                                    select b).FirstOrDefault();

            if ((highestBidOfAll2 != null) && (highestBidOfAll2.IsAutoBid) && (highestNonAutoBid2 != null) && (highestNonAutoBid2.ApplicationUserId != highestBidOfAll2.ApplicationUserId))
            {
                if (highestNonAutoBid2.BidAmount + realEstate.BidIncrement == highestBidOfAll2.BidAmount)
                {

                    highestBidOfAll2.IsAutoBid = false;
                    _db.SaveChanges();
                }
                else
                {
                    //insert auto floor bid
                    var floorBid = new Bid
                    {
                        BidAmount = highestNonAutoBid2.BidAmount + realEstate.BidIncrement,
                        CreateDate = DateTime.UtcNow,
                        ApplicationUserId = highestBidOfAll2.ApplicationUserId,
                        IsAutoBid = false,
                        RealEstateId = highestBidOfAll2.RealEstateId,
                        DeviceType = highestBidOfAll.DeviceType
                    };
                    _db.Bids.Add(floorBid);
                    _db.SaveChanges();
                }
            }
        }

        public void UpdateBid(Data.Entities.Bid bid)
        {
            throw new NotImplementedException();
        }

        public Data.Entities.Bid GetMaxBid(int realEstateId)
        {
            return (from b in _db.Bids
                    where b.RealEstateId == realEstateId && !b.IsAutoBid
                    orderby b.BidAmount descending
                    select b).FirstOrDefault();
        }

        public IQueryable<Bid> GetBidsByUser(string applicationUserId)
        {
            throw new NotImplementedException();
        }


        public IQueryable<Data.Entities.Bid> GetBidsByUserRealEstate(string applicationUserId, int realEstateId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Data.Entities.Bid> GetUserMaxBidWhoHaveBeenOutbidded(Data.Entities.Bid currenMaxBid)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserOutbidNotificationSent(Data.Entities.Bid outBiddedUserBid)
        {
            throw new NotImplementedException();
        }

        public IList<Data.Entities.Bid> GetWinningBidsByUserRealEstateId(string applicationUserId, int realEstateId)
        {
            var query = from b in _db.Bids
                        where  b.ApplicationUserId == applicationUserId && b.IsWinner && b.RealEstateId == realEstateId
                       
                        select b;
            return query.ToList();
        }
    }
}
