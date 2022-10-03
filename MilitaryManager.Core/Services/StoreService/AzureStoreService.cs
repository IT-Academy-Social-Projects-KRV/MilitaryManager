using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services.StoreService
{
    public class AzureStoreService : IStoreService
    {
        private readonly IConfiguration _configuration;

        public AzureStoreService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task StoreDataAsync(IFormFile uploadedFile)
        {
            string connectionString = _configuration.GetValue<string>("AzureConfiguration:ConnectionString");
            string containerName = _configuration.GetValue<string>("AzureConfiguration:ContainerName");
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
