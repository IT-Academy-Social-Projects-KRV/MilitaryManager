using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MilitaryManager.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Infrastructure.Services.StoreServices
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

            if (uploadedFile != null)
            {
                BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
                using (var stream = new MemoryStream())
                {
                    await uploadedFile.CopyToAsync(stream);
                    stream.Position = 0;
                    await container.UploadBlobAsync(uploadedFile.FileName, stream);
                }

            }
        }
    }
}
