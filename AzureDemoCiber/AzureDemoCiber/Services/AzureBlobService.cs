using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureDemoCiber.Services
{
    public class AzureBlobService
    {
        public async Task<string> UploadAsync(string containerName, Stream inputStream)
        {
            var container = GetBlobContainer(containerName);
            var id = Guid.NewGuid().ToString();
            var blob = container.GetBlockBlobReference(id);
            await blob.UploadFromStreamAsync(inputStream);
            return blob.Uri.ToString();
        }

        public IEnumerable<string> GetUrls(string containerName)
        {
            var container = GetBlobContainer(containerName);
            return container.ListBlobs().OfType<CloudBlockBlob>().OrderBy(x => x.Properties.LastModified).Select(x => x.Uri.ToString());
        }

        public async Task DeleteBlobAsync(string containerName, string id)
        {
            var container = GetBlobContainer(containerName);
            var blob = container.GetBlockBlobReference(id);
            await blob.DeleteAsync();
        }

        private static CloudBlobContainer GetBlobContainer(string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("images-" + containerName.ToLower());
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            return container;
        }
    }
}