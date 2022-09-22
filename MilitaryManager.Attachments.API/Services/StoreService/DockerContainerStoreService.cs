using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Services.StoreService
{
    public class DockerContainerStoreService : IStoreService
    {
        public async Task StoreDataAsync(IFormFile uploadedFile)
        {
            string connectionString = "DefaultEndpointsProtocol=http;BlobEndpoint=http://host.docker.internal:11002/militarymanager;AccountName=militarymanager;AccountKey=C/yu8u+EAak7iTH73rUCUj+2NZr6NNgFRPtFPGnJtPYvpZfaW9QJopXd/Xh0HrmzakkWyw/28hss+AStsgfKVg==";


            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            //Create a unique name for the container
            string containerName = "azure-blob-storage321321312311114";

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            if (!containerClient.Exists())
            {
                containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
            }
            // Create a local file in the ./data/ directory for uploading and downloading
            string localPath = "";
            string fileName = "quickstart" + Guid.NewGuid().ToString() + ".txt";
            string localFilePath = Path.Combine(localPath, fileName);

            // Write text to the file
            await File.WriteAllTextAsync(localFilePath, "Hello, World!");

            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

            // Upload data from the local file
            await blobClient.UploadAsync(localFilePath, true);
        }
    }
}
