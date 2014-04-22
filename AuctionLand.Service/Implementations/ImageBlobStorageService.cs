using AuctionLand.Service.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionLand.Service.Implementations
{
    class ImageBlobStorageService :IImageBlobStorageService
    {
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
            
            
            // Retrieve reference to a blob named "myphotos".
            //CloudBlockBlob blockBlob = container.GetBlockBlobReference("myphotos");
            //blockBlob.UploadText(url);
            return container;

        }
    }
}
