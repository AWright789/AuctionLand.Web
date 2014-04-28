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

         public ActionResult SearchHomes(string searchBy, string search)
        {
            var homeModel = new HomeViewModel();

            if (searchBy == "City")
            {
                return View(homeModel.HomesForSale.Where(x => x.City == search || search == null).ToList());
            }
            else
            {
                return View(homeModel.HomesForSale.Where(x => x.State.StartsWith(search) || search ==null).ToList());
            }
        }

        public ActionResult Results()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Search(RealEstateSearchModel model)
        //{
        //    var realEstateProperties = _realEstateService.Query(null, null, null, null, null, null, null, null, null, null,null);

        //    return View();
        //}
    }
}