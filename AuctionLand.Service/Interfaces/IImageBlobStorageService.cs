using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AuctionLand.Service.Interfaces
{
    interface IImageBlobStorageService
    {
        CloudBlobContainer GetCloudBlobContainer();
    }
}
