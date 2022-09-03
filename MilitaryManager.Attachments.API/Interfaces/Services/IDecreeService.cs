using Microsoft.AspNetCore.Http;
using MilitaryManager.Attachments.API.DTO;
using MilitaryManager.Attachments.API.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Interfaces.Services
{
    public interface IDecreeService
    {
        Task<DecreeDTO> GenerateDocument(int templateId, string name, string jsonData);
        Task<IEnumerable<DecreeDTO>> GetDocuments();
        Task<DecreeDTO> GetDocumentById(int documentId);
        Task<FileStream> GetDocumentPdf(int documentId);
        Task<IEnumerable<DecreeDTO>> GetDocumentsByName(string documentName);
        Task UploadSignedDocument(int documentId, IFormFile signedDocument);
        Task DeleteDocument(int documentId);
    }
}
