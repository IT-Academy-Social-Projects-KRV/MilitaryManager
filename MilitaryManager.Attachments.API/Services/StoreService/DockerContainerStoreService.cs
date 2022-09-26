using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Services.StoreService
{
    public class DockerContainerStoreService : IStoreService
    {
        private readonly IConfiguration _configuration;

        public DockerContainerStoreService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task StoreDataAsync(IFormFile uploadedFile)
        {
            string connectionString = _configuration.GetValue<string>("DockerAzureConfiguration:ConnectionString");

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            string containerName = _configuration.GetValue<string>("DockerAzureConfiguration:ContainerName");

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            if (!containerClient.Exists())
            {
                containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
            }

            string localPath = "";
            string localFilePath = Path.Combine(localPath, uploadedFile.FileName);


         //   string fileName = "quickstart" + Guid.NewGuid().ToString() + ".txt";
         //   string localFilePath = Path.Combine(localPath, fileName);

            //await System.IO.File.WriteAllTextAsync(localFilePath, "Hello, World!");

           // BlobClient blobClient = containerClient.GetBlobClient(fileName);

            BlobClient blobClient = containerClient.GetBlobClient(uploadedFile.FileName);

            await blobClient.UploadAsync(localFilePath, true);
        }
    }
}
