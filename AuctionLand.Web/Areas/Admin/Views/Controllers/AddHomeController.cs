using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuctionLand.Data.Entities;
using AuctionLand.Data.Entities.DAL;
using AuctionLand.Service.Interfaces;

namespace AuctionLand.Web.Areas.Admin.Views.Controllers
{
    public class RealEstateController : Controller
    {
        private IRealEstateService _realEstateService;

        public RealEstateController(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }
        // GET: /Admin/AddHome/
        public ActionResult Index()
        {
            return View(_realEstateService.GetAll().ToList());
        }

        // GET: /Admin/AddHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realestate = _realEstateService.GetById(id.Value);
            if (realestate == null)
            {
                return HttpNotFound();
            }
            return View(realestate);
        }

        // GET: /Admin/AddHome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/AddHome/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,YearBuilt,Summary,EstateSize,LotSize,Bedrooms,Bathrooms,ListingStatusId,Featured,ListingTypeId,OccupancyStatusId,RealEstateTypeId,Street,City,State,Zip,Location,StartDate,EndDate,StartingBid,EndingBid,BidIncrement")] RealEstate realestate)
        {
            if (ModelState.IsValid)
            {
                _realEstateService.Create(realestate);
                
                return RedirectToAction("Index");
            }

            return View(realestate);
        }

        // GET: /Admin/AddHome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realestate = _realEstateService.GetById(id.Value);
            if (realestate == null)
            {
                return HttpNotFound();
            }
            return View(realestate);
        }

        // POST: /Admin/AddHome/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,YearBuilt,Summary,EstateSize,LotSize,Bedrooms,Bathrooms,ListingStatusId,Featured,ListingTypeId,OccupancyStatusId,RealEstateTypeId,Street,City,State,Zip,Location,StartDate,EndDate,StartingBid,EndingBid,BidIncrement")] RealEstate realestate)
        {
            if (ModelState.IsValid)
            {
                _realEstateService.Update(realestate);
                
                return RedirectToAction("Index");
            }
            return View(realestate);
        }

        // GET: /Admin/AddHome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realestate = _realEstateService.GetById(id.Value);
            if (realestate == null)
            {
                return HttpNotFound();
            }
            return View(realestate);
        }

        // POST: /Admin/AddHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RealEstate realestate = _realEstateService.GetById(id);
            if(_realEstateService.RealEstateExists(id))
            {
                _realEstateService.Delete(id);
            }
            return RedirectToAction("Index");
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
