using BusinessLogic.Services.Documents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MilitaryManager.Attachments.API.Entities;
using MilitaryManager.Attachments.API.Interfaces;
using MilitaryManager.Attachments.API.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Services
{
    public class DecreeService : IDecreeService
    {
        private IUnitOfWork _unitOfWork;
        private readonly ITemplateService _templateService;
        private readonly IDocumentGenerationService _documentGenerationService;
        private readonly string _webRootPath;
        private readonly string _documentExportFolder;

        public DecreeService(IUnitOfWork unitOfWork,
                             ITemplateService templateService,
                             IDocumentGenerationService documentGenerationService,
                             IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _templateService = templateService;
            _documentGenerationService = documentGenerationService;
            _webRootPath = hostingEnvironment.WebRootPath;
            _documentExportFolder = "documents";
        }

        public async Task<Decree> GenerateDocument(int templateId, string name, string jsonData)
        {
            var template = await _unitOfWork.TemplateRepository.FindById(templateId);

            var cleanJsonData = string.Join("", Regex.Split(jsonData, @"(?:\r\n|\n|\r|\s)"));

            var templateData = await _templateService.GetTemplateDataByIdAsync(templateId);

            var exportPath = Path.Combine(_webRootPath, _documentExportFolder).Replace("\\", "/");

            _documentGenerationService.ApplyFontResolver(_webRootPath);
            var docName = _documentGenerationService.GeneratePdfDocument(exportPath, template.Name, templateData, cleanJsonData);

            var dbPath = Path.Combine(_documentExportFolder, docName).Replace("\\", "/");

            var decree = new Decree()
            {
                Name = name,
                Path = dbPath,
                PathSigned = null,
                //TODO: add UserId from token - User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                CreatedBy = "testId",
                TimeStamp = DateTime.Now,
                TemplateId = templateId,
                StatusId = 1
            };
            
            await _unitOfWork.DecreeRepository.Create(decree);
            await _unitOfWork.SaveChangesAsync();

            return decree;
        }

        public async Task<IEnumerable<Decree>> GetDocuments()
        {
            return await _unitOfWork.DecreeRepository.Get();
        }

        public async Task<Decree> GetDocumentById(int documentId)
        {
            return await _unitOfWork.DecreeRepository.FindById(documentId);
        }

        public async Task<FileStream> GetDocumentPdf(int documentId)
        {
            var decree = await _unitOfWork.DecreeRepository.FindById(documentId);
            return new FileStream(Path.Combine(_webRootPath, decree.Path).Replace("\\", "/"), FileMode.Open);
        }

        public Task<IEnumerable<Decree>> GetDocumentsByName(string documentName)
        {
            throw new System.NotImplementedException();
        }

        public async Task UploadSignedDocument(int documentId, IFormFile signedDocument)
        {
            var decree = await GetDocumentById(documentId);
            var docName = $"{DateTime.Now.Ticks}.pdf";
            var exportPath = Path.Combine(_webRootPath, _documentExportFolder, docName).Replace("\\", "/");

            using (var stream = new FileStream(exportPath, FileMode.Create))
            {
                signedDocument.CopyTo(stream);
            }

            var dbPath = Path.Combine(_documentExportFolder, docName).Replace("\\", "/");

            //TODO: change status to -> Signed
            decree.PathSigned = dbPath;
            await _unitOfWork.SaveChangesAsync();
        }

        public Task DeleteDocument(int documentId)
        {
            throw new System.NotImplementedException();
        }
    }
}
