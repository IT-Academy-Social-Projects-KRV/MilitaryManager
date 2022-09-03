using AutoMapper;
using BusinessLogic.Services.Documents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MilitaryManager.Attachments.API.DTO;
using MilitaryManager.Attachments.API.Entities;
using MilitaryManager.Attachments.API.Interfaces;
using MilitaryManager.Attachments.API.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly IMapper _mapper;
        private readonly string _documentExportFolder;

        public DecreeService(IUnitOfWork unitOfWork,
                             ITemplateService templateService,
                             IDocumentGenerationService documentGenerationService,
                             IWebHostEnvironment hostingEnvironment,
                             IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _templateService = templateService;
            _documentGenerationService = documentGenerationService;
            _webRootPath = hostingEnvironment.WebRootPath;
            _mapper = mapper;
            _documentExportFolder = "documents";
        }

        public async Task<DecreeDTO> GenerateDocument(int templateId, string name, string jsonData)
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

            return _mapper.Map<Decree, DecreeDTO>(decree);
        }

        public async Task<IEnumerable<DecreeDTO>> GetDocuments()
        {
            var decrees = await _unitOfWork.DecreeRepository.Get();
            return decrees.Select(_mapper.Map<Decree, DecreeDTO>);
        }

        public async Task<DecreeDTO> GetDocumentById(int documentId)
        {
            var decree = await _unitOfWork.DecreeRepository.FindById(documentId);
            return _mapper.Map<Decree, DecreeDTO>(decree);
        }

        public async Task<FileStream> GetDocumentPdf(int documentId)
        {
            var decree = await _unitOfWork.DecreeRepository.FindById(documentId);
            return new FileStream(Path.Combine(_webRootPath, decree.Path).Replace("\\", "/"), FileMode.Open);
        }

        public async Task<IEnumerable<DecreeDTO>> GetDocumentsByName(string documentName)
        {
            var decrees = await _unitOfWork.DecreeRepository.GetDecreesByName(documentName);
            return decrees.Select(_mapper.Map<Decree, DecreeDTO>);
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

        public async Task DeleteDocument(int documentId)
        {
            await _unitOfWork.DecreeRepository.Remove(documentId);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
