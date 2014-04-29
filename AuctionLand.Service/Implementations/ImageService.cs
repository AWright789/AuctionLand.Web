using AuctionLand.Data.Entities;
using AuctionLand.Data.Entities.DAL;
using AuctionLand.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AuctionLand.Service.Implementations
{
    public class ImageService : IImageService
    {
        private IAuctionLandDbContext _db;
        
            
        public ImageService(IAuctionLandDbContext db)
        {
            _db = db;
        }
        public Data.Entities.RealEstateImage GetById(int id)
        {
            return _db.RealEstateImages.Find(id);
        }

        public IQueryable<Data.Entities.RealEstateImage> Query(int RealEstateId)
        {
            return _db.RealEstateImages.Where(r =>
                (r.RealEstate.Id == RealEstateId || RealEstateId == null));
                
        }
        public void Update(Data.Entities.RealEstateImage realEstateImage)
        {
            _db.Entry(realEstateImage).State = System.Data.Entity.EntityState.Modified;
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(realEstateImage.Id))
                {
                    //return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        public void Create(Data.Entities.RealEstateImage realEstateImage)
        {
            _db.RealEstateImages.Add(realEstateImage);
        
            _db.SaveChanges();
        }
        
        public void Delete(int id)
        {
            RealEstateImage realestateImage = _db.RealEstateImages.Find(id);
            if (realestateImage == null)
            {
                //return NotFound();
            }
            else
            {
                _db.RealEstateImages.Remove(realestateImage);
                _db.SaveChanges();
            }
        }

        public IQueryable<Data.Entities.RealEstateImage> GetAll()
        {
            return _db.RealEstateImages;
        }

        public bool ImageExists(int id)
        {
            return _db.RealEstateImages.Count(e => e.Id == id) > 0;
        }
        
    }
}
