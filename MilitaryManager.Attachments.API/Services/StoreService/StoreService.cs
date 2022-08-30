using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Services.StoreService
{
    public class StoreService
    {
        public IStoreService Store { private get; set; }
        public StoreService(IStoreService storeService)
        {
            Store = storeService;
        }
        public void StoreData(IFormFile uploadedFile)
        {
           Store.StoreData(uploadedFile);
        }
    }
}
