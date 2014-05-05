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
    [RequireHttps]
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

            homeModel.FeaturedHomes = _realEstateService.GetAll().Where(r => (r.Featured == true))
                .Take(3).ToList()
                .Select(r => r.ToModel());

            homeModel.HomesForSale = _realEstateService.GetAll().Where(r => (r.Featured == false))
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

         public ActionResult SearchResults(RealEstateSearchModel model)
        {

           // var searchResults = _realEstateService.Query(model.City, model.State, model.Zip, model.MinBedrooms, model.MinBaths, model.MinBidPrice, model.MaxBidPrice, model.RealEstateTypeId, null, null, null);
           // ORIGINAL KEEP AS BACKUP var searchResults = _realEstateService.theQuery(model.City, model.State, model.Zip, model.MinBedrooms);

            var searchResults = _realEstateService.theQuery(model.City, model.State, model.Zip, model.MinBedrooms);

            var models = searchResults.ToList().Select(r => r.ToModel());

            return PartialView("_SearchResults", models);

        }

        public ActionResult Filters()
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