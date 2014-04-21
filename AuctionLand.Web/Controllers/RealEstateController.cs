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
        public RealEstateController(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
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
            return View(model);
        }



	}
}