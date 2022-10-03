using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Services.StoreService
{
    public class StoreService
    {
        private IStoreService _storeService;
        public StoreService(IStoreService storeService)
        {
            _storeService = storeService;
        }
        public void StoreData(IFormFile uploadedFile)
        {
            _storeService.StoreDataAsync(uploadedFile);
        }
    }
}
