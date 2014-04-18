using AuctionLand.Service.Interfaces;
using AuctionLand.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionLand.Web.Mappings;
using AuctionLand.Data.Entities;

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
            var homeModel = new HomeViewModel();


            homeModel.FeaturedHomes = _realEstateService.GetAll().Take(3).ToList().Select(r => r.ToModel());
            homeModel.HomesForSale = _realEstateService.GetAll()
                .OrderByDescending(r => r.StartDate)
                .Take(9).ToList()
                .Select(r => r.ToModel());

            
            return View(homeModel);
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