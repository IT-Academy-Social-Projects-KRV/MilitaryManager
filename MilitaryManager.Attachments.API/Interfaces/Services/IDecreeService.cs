using Microsoft.AspNetCore.Http;
using MilitaryManager.Attachments.API.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Interfaces.Services
{
    public interface IDecreeService
    {
        Task<Decree> GenerateDocument(int templateId, string name, string jsonData);
        Task<IEnumerable<Decree>> GetDocuments();
        Task<Decree> GetDocumentById(int documentId);
        Task<FileStream> GetDocumentPdf(int documentId);
        Task<IEnumerable<Decree>> GetDocumentsByName(string documentName);
        Task UploadSignedDocument(int documentId, IFormFile signedDocument);
        Task DeleteDocument(int documentId);
    }
}
