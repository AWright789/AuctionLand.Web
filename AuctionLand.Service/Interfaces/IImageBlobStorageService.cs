using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;


namespace AuctionLand.Service.Interfaces
{
    public interface IImageBlobStorageService
    {
        CloudBlobContainer GetCloudBlobContainer();

        string SaveImageToBlobStorage(string fileName, Stream stream);
    }
}
