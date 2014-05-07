using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AuctionLand.Data.Entities.DAL;
using AuctionLand.Service.Exceptions;
using AuctionLand.Service.Implementations;
using AuctionLand.Service.Interfaces;
using AuctionLand.Web.DataTransferObjects;
using AutoMapper;
using AuctionLand.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuctionLand.Web.Controllers.api
{
     [Authorize]
    public class BidsController : ApiController
     {
         private readonly UserManager<ApplicationUser> _userManager;
         private readonly IRealEstateService _realEstateService;
         private readonly IBidService _bidService ;
         private const string KOutBidNotification = "Your bid was successfully placed. However, another bidder has already out bidded you! Try again.";


         public BidsController(UserManager<ApplicationUser> userManager, IRealEstateService realEstateService, IBidService bidService)
        {
            _userManager = userManager;
             _realEstateService = realEstateService;
             _bidService = bidService;
        }

        

        /// <summary>
        /// Posts a Bid to the API.
        /// </summary>
        /// <param name="value">BidDto object being posted</param>
        /// <returns>Returns a BidDto check the IsSuccessful property to determine if a bid was successful</returns>
        public BidDto Post([FromBody]BidDto value)
        {
            value.ErrorMessage = string.Empty;
            {
               value.IsWinner = false;
                value.BidSuccessful = false;
                //value.DeviceType = "HTML";
                Mapper.CreateMap<BidDto, Bid>();
                Mapper.CreateMap<Bid, BidDto>();
                var bid = Mapper.Map<Bid>(value);
                bid.CreateDate = DateTime.UtcNow;
                try
                {


                    ApplicationUser biddingUser = _userManager.FindById(User.Identity.GetUserId());
                    


                    //First thing check and see if the auction has ended and disallow bidding if it has
                    var realEstate = _realEstateService.GetById(value.RealEstateId);
                    if (realEstate == null)
                    {
                        value.BidSuccessful = false;
                        value.ErrorMessage = "Invalid Real Estate Identifier.";
                        return value;
                    }
                    else if (realEstate.StartDate > DateTime.UtcNow)
                    {
                        value.BidSuccessful = false;
                        value.ErrorMessage = "Auction has not started. Currently bidding is not allowed.";
                        return value;
                    }
                    else if (realEstate.HasEnded || realEstate.EndDate <= DateTime.UtcNow)
                    {
                        value.BidSuccessful = false;
                        value.ErrorMessage =
                            "Unfortunately the Auction has ended. No additional bidding allowed.";
                        return value;
                    }


                   
                    
                    bool error;
                    string errorMessage;
                    _bidService.InsertBid(bid, out error, out errorMessage);
                    var newMaxBid = _bidService.GetMaxBid(bid.RealEstateId);
                    if (newMaxBid.Id != bid.Id)
                        bid = newMaxBid;
                    value = Mapper.Map<BidDto>(bid);
                    value.BidSuccessful = !error;
                    value.ErrorMessage = errorMessage;
                    //value.BidInfo = ProductController.PrepareAuctionItemBidInfo(bid.ProductId, bid.EventManagerId, biddingCustomer.Id, _productService, _customerService, _bidService);
                    if (biddingUser.Id != bid.ApplicationUserId)
                    {
                        //this means this bidding customer was automatically autobid
                        value.BidSuccessful = false;
                        value.IsOutbidError = true;
                        value.ErrorMessage = KOutBidNotification;

                    }
                }
                catch (OutBidException outBidException)
                {
                    value.ErrorMessage = KOutBidNotification;
                    value.IsOutbidError = true;
                    value.BidSuccessful = false;

                }
                catch (DbUpdateException sqlException)
                {

                    //_logService.Error(sqlException.Message, sqlException, null);
                    value.BidSuccessful = false;
                    value.ErrorMessage = "Oh my! An error occured placing your bid. Please try again.";
                    if (sqlException.GetBaseException().Message.Contains("UNIQUE KEY"))
                    {

                        value.ErrorMessage = KOutBidNotification;
                        value.IsOutbidError = true;
                        //value.BidInfo = ProductController.PrepareAuctionItemBidInfo(value.ProductId, value.CustomerId, _productService, _customerService, _bidService);
                    }
                }
                catch (OutbidSelfException)
                {
                    value.ErrorMessage = "You are already the highest bidder.  Would you still like to place your bid?";
                    value.IsSelfOutBidError = true;
                    value.BidSuccessful = false;
                }
                catch (Exception exc)
                {
                    //_logService.Error(exc.Message, exc, null);
                    value.BidSuccessful = false;
                    value.ErrorMessage = "Oh my! An error occured placing your bid. Please try again.";
                }
                //try
                //{
                //    value.BidInfo = ProductController.PrepareAuctionItemBidInfo(bid.ProductId, (biddingUser == null) ? 0 : biddingUser.Id, _productService, _customerService, _bidService);

                //}
                //catch (Exception exc)
                //{
                //    _logService.Error("Error getting Bid info " + exc.Message, exc, null);
                //    value.BidSuccessful = false;
                //    value.ErrorMessage = "Oh my! An error occured placing your bid. Please try again.";
                //}

            }

            return value;
        }
    }
}