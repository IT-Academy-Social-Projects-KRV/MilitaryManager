using Microsoft.AspNetCore.Http;

namespace MilitaryManager.Attachments.API.Services.StoreService
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
