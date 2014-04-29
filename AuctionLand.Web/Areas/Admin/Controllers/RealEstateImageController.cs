using AuctionLand.Service.Implementations;
using AuctionLand.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using AuctionLand.Data.Entities;
using AuctionLand.Web.Models;
using AuctionLand.Web.Mappings;
using System.IO;
using System.Threading.Tasks;

namespace AuctionLand.Web.Areas.Admin.Controllers
{
    public class RealEstateImageController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IRealEstateService _realEstateService;
        private readonly IImageBlobStorageService _imageBlobStorageService;
        public RealEstateImageController(IImageService imageService, IRealEstateService realEstateService, IImageBlobStorageService imageBlobStorageService)
        {
            _imageService = imageService;
            _realEstateService = realEstateService;
            _imageBlobStorageService = imageBlobStorageService;
           

        }
        //
        // GET: /Admin/RealEstateImage/
        public ActionResult Index()
        {
            CloudBlobContainer blobContainer = GetCloudBlobContainer();
            List<string> blobs = new List<string>();
            foreach (var blobItem in blobContainer.ListBlobs())
            {
                blobs.Add(blobItem.Uri.ToString());
            }
            return View(blobs);
        }

        //
        // GET: /Admin/RealEstateImage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        //
        // POST: /Admin/RealEstateImage/Create
        [HttpPost]
        //public ActionResult Create(FormCollection collection)//get accept the Id and url then convert url to uri
        public ActionResult Create(RealEstateImageModel model, HttpPostedFileBase[] ImageFiles)
        {

            
            //check to see if there is a valid real estate id 
            var realEstate = _realEstateService.GetById(model.RealEstate_Id);

            if(realEstate == null)
            {
                return Json(new { error = true, errorMessage = "Invalid Real Estate Id" });
            }

            if (realEstate.RealEstateImages == null)
                realEstate.RealEstateImages = new List<RealEstateImage>();

            var realEstateImage = model.ToEntity();

            if (ImageFiles != null && ImageFiles[0] != null)
            {
                //do our blob storage
                var fileName = String.Format("{0}_{1}_{2}", realEstate.Id,Guid.NewGuid(),ImageFiles[0].FileName);
                realEstateImage.ImageUrl = SaveImageToBlobStorage(ImageFiles[0]);
                
            }else if (!String.IsNullOrEmpty(model.ImageUrl)){
                Uri imageUri;

                if(!Uri.TryCreate(model.ImageUrl,UriKind.Absolute,out imageUri))
                    return Json(new { error = true, errorMessage = "Please provide a valid image url;" });

                realEstateImage.ImageUrl =imageUri.ToString();
                
                

            }else{
                return Json(new { error = true, errorMessage = "Please select an image or provide a valid image url;" });
            }

            realEstate.RealEstateImages.Add(realEstateImage);
            _realEstateService.Update(realEstate);

            model = realEstateImage.ToModel();
            return Json(new { error = false, model });
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
        public void Edit(RealEstateImageModel model)
        {
            var realEstateImage = model.ToEntity();
            _imageService.Update(realEstateImage);
        }

        // POST: /Admin/RealEstateImage/Delete/5
        [HttpDelete]
        public void Delete(int id)
        {
            RealEstateImage realEstateImage = _imageService.GetById(id);
            // TODO: Add delete logic here
            if(realEstateImage != null)
            {
                
                _imageService.Delete(id);
                
            }
        }
        
        public Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer GetCloudBlobContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            ConfigurationManager.ConnectionStrings["AuctionLandPhotoKey"].ConnectionString);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container. 
            CloudBlobContainer container = blobClient.GetContainerReference("photos");
            // Sets the Container Public
            if (container.CreateIfNotExists())
            {
                container.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            }
            return container;

        }
        public string SaveImageToBlobStorage(HttpPostedFileBase file)
        {
            var container = GetCloudBlobContainer();
            var blob = container.GetBlockBlobReference(file.FileName);
            
            var blockDataList = new Dictionary<string, byte[]>();

            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }

            blob.UploadFromByteArray(fileData, 0, fileData.Length);
            
            //    var blockSizeInKB = 1024;

            //    var offset = 0;

            //    var index = 0;

            //    while (offset < fileData.Length)
            //    {

            //        var readLength = Math.Min(1024 * blockSizeInKB, (int)fileData.Length - offset);
            //        var blockData = new byte[readLength];

            //        offset +=  stream.Read(blockData, 0, readLength);

            //        blockDataList.Add(Convert.ToBase64String(BitConverter.GetBytes(index)), blockData);



            //        index++;

            //    }
            
            //Parallel.ForEach(blockDataList, (bi) =>
            //{

            //    blob.PutBlock(bi.Key, new MemoryStream(bi.Value), null);

            //});
            
            //blob.PutBlockList(blockDataList.Select(b => b.Key).ToArray());
            return blob.Uri.ToString();
        }
         
    }
}
