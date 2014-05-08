using AuctionLand.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionLand.Web.Mappings;

namespace AuctionLand.Web.Controllers
{
    public class RealEstateController : Controller
    {
        readonly IRealEstateService _realEstateService;
        readonly IBidService _bidService;
         
        public RealEstateController(IRealEstateService realEstateService, IBidService bidService)
        {
            _realEstateService = realEstateService;
            _bidService = bidService;
        }
        //
        // GET: /RealEstate/
        public ActionResult Index(int id)
        {
            var realEstate = _realEstateService.GetById(id);
            if (realEstate == null)
            {
                RedirectToAction("Index", "Home");
            }

            var model = realEstate.ToModel();
            var maxBid = _bidService.GetMaxBid(id);
            if (maxBid != null)
            {

                model.MaxBid = maxBid.ToModel();
            }
            
            return View(model);
        }
        
        public ActionResult BidTest()
        {
            return View();
        }




	}
}