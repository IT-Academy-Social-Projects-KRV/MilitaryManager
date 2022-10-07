using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services.StoreService
{
    public interface IStoreService
    {
        Task StoreDataAsync(IFormFile uploadedFile);
    }
}
