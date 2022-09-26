using AutoMapper;
using BusinessLogic.Services.Documents;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.Internal;
using MilitaryManager.Core.DTO.Attachments;
using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Interfaces;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class DecreeService : IDecreeService
    {
        protected readonly IRepository<Decree, int> _decreeRepository;
        protected readonly IRepository<Template, int> _templateRepository;
        protected readonly ITemplateService _templateService;
        protected readonly IDocumentGenerationService _documentGenerationService;
        protected readonly IMapper _mapper;
        protected readonly IStoreService _storeService;
        private readonly string _documentExportFolder;

        public DecreeService(IRepository<Decree, int> decreeRepository,
                             IRepository<Template, int> templateRepository,
                             ITemplateService templateService,
                             IDocumentGenerationService documentGenerationService,
                             IMapper mapper,
                             IStoreService storeService)
        {
            _decreeRepository = decreeRepository;
            _templateRepository = templateRepository;
            _documentGenerationService = documentGenerationService;
            _mapper = mapper;
            _storeService = storeService;
            _documentExportFolder = "documents";
        }

        public async Task<DecreeDTO> GenerateDecreeAsync(string wwwroot, int templateId, string name, string jsonData)
        {
            var template = await _templateRepository.GetByKeyAsync(templateId);

            var cleanJsonData = string.Join("", Regex.Split(jsonData, @"(?:\r\n|\n|\r|\s)"));

            string templateData = null;
            using (StreamReader reader = new StreamReader(await _storeService.RetrieveDataAsync(template.Path)))
            {
                templateData = reader.ReadToEnd();
            }

            var exportPath = Path.Combine(wwwroot, _documentExportFolder).Replace("\\", "/");

            _documentGenerationService.ApplyFontResolver(wwwroot);
            //TODO: Maybe make new method GeneratePdfDocumentFile, that returns IFormFile
            var bytesFile = _documentGenerationService.GeneratePdfDocumentFile(exportPath, null, templateData, cleanJsonData);
            //TODO: заглушка, GeneratePdfDocument має повернути FormFile pdf
            //var pdfFile = new FormFile(new MemoryStream(), 0, 0, "test", "test");

            //var dbPath = Path.Combine(_documentExportFolder, docName).Replace("\\", "/");
            string path = null;
            using (var ms = new MemoryStream(bytesFile))
            {
                var pdfFile = new FormFile(ms, 0, bytesFile.Length, "test", "tester");
                path = await _storeService.StoreDataAsync(pdfFile);
            }

            var decree = new Decree()
            {
                Name = name,
                Path = path,
                //TODO: add UserId from token - User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                CreatedBy = "testId",
                TimeStamp = DateTime.Now,
                TemplateId = templateId,
                StatusId = 1
            };
            
            await _decreeRepository.AddAsync(decree);
            await _decreeRepository.SaveChangesAcync();

            return _mapper.Map<DecreeDTO>(decree);
        }

        public async Task<IEnumerable<DecreeDTO>> GetDecreesAsync()
        {
            var decrees = await _decreeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DecreeDTO>>(decrees);
        }

        public async Task<DecreeDTO> GetDecreeByIdAsync(int id)
        {
            var decree = await _decreeRepository.GetByKeyAsync(id);
            return _mapper.Map<DecreeDTO>(decree);
        }

        public async Task<FileStream> GetDecreePdfAsync(int id)
        {
            var decree = await _decreeRepository.GetByKeyAsync(id);
            return await _storeService.RetrieveDataAsync(decree.Path);
        }

        public async Task<IEnumerable<DecreeDTO>> GetDecreesByNameAsync(string name)
        {
            var specification = new Decrees.DecreesByName(name);
            var decrees = await _decreeRepository.GetListBySpecAsync(specification);
            return _mapper.Map<IEnumerable<DecreeDTO>>(decrees);
        }

        public async Task UploadSignedDecreeAsync(int id, IFormFile sign)
        {
            var decree = await GetDecreeByIdAsync(id);

            var path = await _storeService.StoreDataAsync(sign);

            //TODO: change status to -> Signed
            decree.PathSigned = path;
            await _decreeRepository.SaveChangesAcync();
        }

        public async Task<DecreeDTO> DeleteDecreeAsync(int id)
        {
            var decree = new Decree() { Id = id };
            var deleteDecree = await _decreeRepository.DeleteAsync(decree);
            await _decreeRepository.SaveChangesAcync();

            return _mapper.Map<DecreeDTO>(deleteDecree);
        }
    }
}
