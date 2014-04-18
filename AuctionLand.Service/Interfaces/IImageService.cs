using AuctionLand.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Service.Interfaces
{
    interface IImageService
    {
        RealEstateImage GetById(int id);

        IQueryable<RealEstateImage> Query(int RealEstateId);
        void Update(RealEstateImage realEstateImage);
        void Create(RealEstateImage realEstateImage);
        void Delete(int id);
        IQueryable<RealEstateImage> GetAll();
        bool ImageExists(int id);
    }
}
