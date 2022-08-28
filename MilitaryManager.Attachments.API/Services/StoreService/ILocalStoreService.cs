using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Services.StoreService
{
    public interface ILocalStoreService
    {
         Task StoreData(IFormFile uploadedFile);
    }
}
