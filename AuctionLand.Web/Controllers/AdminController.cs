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

namespace AuctionLand.Web.Controllers
{
    public class AdminController : Controller
    {
        private AuctionLandDbContext db = new AuctionLandDbContext();

        // GET: /Admin/
        public ActionResult Index()
        {
            var realestate = db.RealEstate.Include(r => r.Address).Include(r => r.AuctionInfo);
            return View(realestate.ToList());
        }

        // GET: /Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realestate = db.RealEstate.Find(id);
            if (realestate == null)
            {
                return HttpNotFound();
            }
            return View(realestate);
        }

        // GET: /Admin/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.RealEstateAddress, "Id", "Street");
            ViewBag.Id = new SelectList(db.RealEstateAuction, "Id", "Id");
            return View();
        }

        // POST: /Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,YearBuilt,Summary,EstateSize,LotSize,Bedrooms,Bathrooms,ListingStatusId,Featured,ListingTypeId,OccupancyStatusId,RealEstateTypeId")] RealEstate realestate)
        {
            if (ModelState.IsValid)
            {
                db.RealEstate.Add(realestate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.RealEstateAddress, "Id", "Street", realestate.Id);
            ViewBag.Id = new SelectList(db.RealEstateAuction, "Id", "Id", realestate.Id);
            return View(realestate);
        }

        // GET: /Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realestate = db.RealEstate.Find(id);
            if (realestate == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.RealEstateAddress, "Id", "Street", realestate.Id);
            ViewBag.Id = new SelectList(db.RealEstateAuction, "Id", "Id", realestate.Id);
            return View(realestate);
        }

        // POST: /Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,YearBuilt,Summary,EstateSize,LotSize,Bedrooms,Bathrooms,ListingStatusId,Featured,ListingTypeId,OccupancyStatusId,RealEstateTypeId")] RealEstate realestate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realestate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.RealEstateAddress, "Id", "Street", realestate.Id);
            ViewBag.Id = new SelectList(db.RealEstateAuction, "Id", "Id", realestate.Id);
            return View(realestate);
        }

        // GET: /Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realestate = db.RealEstate.Find(id);
            if (realestate == null)
            {
                return HttpNotFound();
            }
            return View(realestate);
        }

        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RealEstate realestate = db.RealEstate.Find(id);
            db.RealEstate.Remove(realestate);
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
