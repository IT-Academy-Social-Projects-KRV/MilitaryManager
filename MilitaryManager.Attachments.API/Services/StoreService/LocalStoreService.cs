using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Services.StoreService
{
    public class LocalStoreService : ILocalStoreService
    {
        private readonly string _webRootPath;
        public LocalStoreService(IWebHostEnvironment hostingEnvironment)
        {
            _webRootPath = hostingEnvironment.WebRootPath;
        }
        public async Task StoreData(IFormFile uploadedFile)
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
