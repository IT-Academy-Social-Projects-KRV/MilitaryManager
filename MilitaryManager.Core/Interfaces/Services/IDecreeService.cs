using Microsoft.AspNetCore.Http;
using MilitaryManager.Core.DTO.Attachments;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IDecreeService
    {
        Task<DecreeDTO> GenerateDecreeAsync(string wwwroot, int templateId, string name, string number, string jsonData);
        Task<IEnumerable<DecreeDTO>> GetDecreesAsync();
        Task<DecreeDTO> GetDecreeByIdAsync(int id);
        Task<FileStream> GetDecreePdfAsync(int id);
        Task<FileStream> GetSignedDecreePdfAsync(int id);
        Task<IEnumerable<DecreeDTO>> GetDecreesByNameAsync(string name);
        Task UploadSignedDecreeAsync(int id, IFormFile sign);
        Task<DecreeDTO> UpdateDecreeAsync(UpdateDecreeDTO decreeDTO);
        Task<DecreeDTO> CompleteDecreeAsync(int id);
        Task<DecreeDTO> DeleteDecreeAsync(int id);
    }
}
