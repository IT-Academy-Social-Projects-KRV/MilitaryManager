using Microsoft.AspNetCore.Http;
using MilitaryManager.Core.DTO.Attachments;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IDecreeService
    {
        Task<DecreeDTO> GenerateDecreeAsync(int templateId, string name, string jsonData);
        Task<IEnumerable<DecreeDTO>> GetDecreesAsync();
        Task<DecreeDTO> GetDecreeByIdAsync(int id);
        Task<FileStream> GetDecreePdfAsync(int id);
        Task<IEnumerable<DecreeDTO>> GetDecreesByNameAsync(string name);
        Task UploadSignedDecreeAsync(int id, IFormFile sign);
        Task<DecreeDTO> DeleteDecreeAsync(int id);
    }
}
