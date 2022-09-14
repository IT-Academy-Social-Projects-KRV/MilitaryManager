using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Services.StoreService
{
    public class LocalStoreService : IStoreService
    {
        private readonly string _webRootPath;
        public LocalStoreService(string webRootPath)
        {
            _webRootPath = webRootPath;
        }
        public async Task StoreDataAsync(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = "/documents/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_webRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
            }
        }
    }
}
