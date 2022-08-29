using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Services.StoreService
{
    public class AzureStoreService : IAzureStoreService
    {
        private readonly string _connectionString = "DefaultEndpointsProtocol=https;AccountName=militarymanager;" +
            "AccountKey=C/yu8u+EAak7iTH73rUCUj+2NZr6NNgFRPtFPGnJtPYvpZfaW9QJopXd/Xh0HrmzakkWyw/28hss+AStsgfKVg==;EndpointSuffix=core.windows.net";
        private readonly string _containerName = "documents";
        public async Task StoreData(IFormFile uploadedFile)
        {
            if(uploadedFile != null)
            {
                BlobContainerClient container = new BlobContainerClient(_connectionString, _containerName);
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
