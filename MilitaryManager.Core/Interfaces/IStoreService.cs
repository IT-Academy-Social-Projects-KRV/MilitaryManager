using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces
{
    public interface IStoreService
    {
        /// <summary>
        /// Save file in storage
        /// </summary>
        /// <returns>Stored path.</returns>
        Task<string> StoreDataAsync(IFormFile uploadedFile);

        /// <summary>
        /// Get the file from storage
        /// </summary>
        /// <returns>Filestream of file.</returns>
        Task<FileStream> RetrieveDataAsync(string path);

    }
}
