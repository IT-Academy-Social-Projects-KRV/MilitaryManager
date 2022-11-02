using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MilitaryManager.Core.Services.StoreService;
using System.IO;
using System.Threading.Tasks;

namespace MilitaryManager.Infrastructure.Services.StoreServices
{
    public class AzureStoreService : IStoreService
    {
        private readonly IConfiguration _configuration;

        public AzureStoreService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> StoreDataAsync(IFormFile uploadedFile)
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

                return container.Uri.ToString() + uploadedFile.FileName;
            }

            return string.Empty;
        }
    }
}
