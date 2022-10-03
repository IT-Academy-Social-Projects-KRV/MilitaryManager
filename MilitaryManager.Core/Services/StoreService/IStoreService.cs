using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public interface IStoreService
    {
        Task StoreDataAsync(IFormFile uploadedFile);
    }
}
