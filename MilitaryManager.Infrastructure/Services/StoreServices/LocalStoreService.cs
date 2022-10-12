using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MilitaryManager.Core.Services.StoreService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Infrastructure.Services.StoreServices
{
    public class LocalStoreService : IStoreService
    {
        private readonly string _webRootPath;
        public LocalStoreService(IHostingEnvironment webHostEnvironment)
        {
            _webRootPath = webHostEnvironment.WebRootPath;
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
