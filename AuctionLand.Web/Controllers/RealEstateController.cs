using AuctionLand.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionLand.Web.Controllers
{
    public class RealEstateController : Controller
    {
        readonly IRealEstateService _realEstateService;
        public RealEstateController(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }
        //
        // GET: /RealEstate/
        public ActionResult Index()
        {
           
            return View();
        }



	}
}