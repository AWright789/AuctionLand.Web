using AuctionLand.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionLand.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IRealEstateService _realEstateService;
        public HomeController(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Search()
        {
            var realEstateProperties = _realEstateService.Query(null, null, null, null, null, null, null, null, null, null);

            return View();
        }
    }
}