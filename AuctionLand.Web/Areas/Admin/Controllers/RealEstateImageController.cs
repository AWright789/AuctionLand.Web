using AuctionLand.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionLand.Web.Areas.Admin.Controllers
{
    public class RealEstateImageController : Controller
    {
        private IImageService _imageService;
        public RealEstateImageController(IImageService imageService)
        {
            _imageService = imageService;
        }
        //
        // GET: /Admin/RealEstateImage/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/RealEstateImage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/RealEstateImage/Create
        public ActionResult Create()
        {   
            return View();
        }

        //
        // POST: /Admin/RealEstateImage/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/RealEstateImage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/RealEstateImage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/RealEstateImage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/RealEstateImage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
