using AuctionLand.Service.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AuctionLand.Service.Implementations
{
    public class ImageBlobStorageService :IImageBlobStorageService
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

        public string SaveImageToBlobStorage(string fileName, Stream stream)
        {
            var container = GetCloudBlobContainer();
            var blob = container.GetBlockBlobReference(fileName);
            
            var blockDataList = new Dictionary<string, byte[]>();



            var blockSizeInKB = 1024;

            var offset = 0;

            var index = 0;

            while (offset < stream.Length)
            {

                var readLength = Math.Min(1024 * blockSizeInKB, (int)stream.Length - offset);
                var blockData = new byte[readLength];

                offset += stream.Read(blockData, 0, readLength);

                blockDataList.Add(Convert.ToBase64String(BitConverter.GetBytes(index)), blockData);



                index++;

            }
            Parallel.ForEach(blockDataList, (bi) =>
            {

                blob.PutBlock(bi.Key, new MemoryStream(bi.Value), null);

            });

            blob.PutBlockList(blockDataList.Select(b => b.Key).ToArray());
            blob.UploadFromStream(stream);
            return blob.Uri.ToString();
        }
    }
}
