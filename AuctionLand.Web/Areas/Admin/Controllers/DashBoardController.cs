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

namespace AuctionLand.Web.Areas.Admin.Controllers
{
    public class DashBoardController : Controller
    {
        private AuctionLandDbContext db = new AuctionLandDbContext();

        // GET: /Admin/DashBoard/
        public ActionResult Index()
        {
            return View(db.RealEstates.ToList());
        }

        // GET: /Admin/DashBoard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realestate = db.RealEstates.Find(id);
            if (realestate == null)
            {
                return HttpNotFound();
            }
            return View(realestate);
        }

        // GET: /Admin/DashBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/DashBoard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,YearBuilt,Summary,EstateSize,LotSize,Bedrooms,Bathrooms,ListingStatusId,Featured,ListingTypeId,OccupancyStatusId,RealEstateTypeId,Street,City,State,Zip,Location,StartDate,EndDate,StartingBid,EndingBid,BidIncrement")] RealEstate realestate)
        {
            if (ModelState.IsValid)
            {
                db.RealEstates.Add(realestate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(realestate);
        }

        // GET: /Admin/DashBoard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realestate = db.RealEstates.Find(id);
            if (realestate == null)
            {
                return HttpNotFound();
            }
            return View(realestate);
        }

        // POST: /Admin/DashBoard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,YearBuilt,Summary,EstateSize,LotSize,Bedrooms,Bathrooms,ListingStatusId,Featured,ListingTypeId,OccupancyStatusId,RealEstateTypeId,Street,City,State,Zip,Location,StartDate,EndDate,StartingBid,EndingBid,BidIncrement")] RealEstate realestate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realestate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(realestate);
        }

        // GET: /Admin/DashBoard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realestate = db.RealEstates.Find(id);
            if (realestate == null)
            {
                return HttpNotFound();
            }
            return View(realestate);
        }

        // POST: /Admin/DashBoard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RealEstate realestate = db.RealEstates.Find(id);
            db.RealEstates.Remove(realestate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
