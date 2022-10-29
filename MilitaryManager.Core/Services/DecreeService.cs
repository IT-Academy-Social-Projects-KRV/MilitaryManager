using AutoMapper;
using BusinessLogic.Services.Documents;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MilitaryManager.Core.DTO.Attachments;
using MilitaryManager.Core.Entities.DecreeDataEntity;
using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.Entities.SignedPdfEntity;
using MilitaryManager.Core.Entities.StatusEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Entities.TemplatePlaceholderEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Enums;
using MilitaryManager.Core.Exceptions;
using MilitaryManager.Core.Interfaces;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using MilitaryManager.Core.Services.ExecuteDecreeService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class DecreeService : IDecreeService
    {
        protected readonly IRepository<Decree, int> _decreeRepository;
        protected readonly IRepository<Template, int> _templateRepository;
        protected readonly IRepository<Status, int> _statusRepository;
        protected readonly IRepository<SignedPdf, int> _signedPdfRepository;
        protected readonly IRepository<DecreeData, int> _decreeDataRepository;
        private readonly IRepository<Division, int> _divisionRepository;
        private readonly IRepository<Unit, int> _unitRepository;
        protected readonly IDocumentGenerationService _documentGenerationService;
        protected readonly IMapper _mapper;
        protected readonly IStoreService _storeService;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _documentExportFolder;

        public DecreeService(IRepository<Decree, int> decreeRepository,
                             IRepository<Template, int> templateRepository,
                             IRepository<Status, int> statusRepository,
                             IRepository<SignedPdf, int> signedPdfRepository,
                             IRepository<DecreeData, int> decreeDataRepository,
                             IRepository<Division, int> divisionRepository,
                             IRepository<Unit, int> unitRepository,
                             IDocumentGenerationService documentGenerationService,
                             IMapper mapper,
                             IStoreService storeService,
                             IHttpContextAccessor httpContextAccessor)
        {
            _decreeRepository = decreeRepository;
            _templateRepository = templateRepository;
            _statusRepository = statusRepository;
            _signedPdfRepository = signedPdfRepository;
            _decreeDataRepository = decreeDataRepository;
            _divisionRepository = divisionRepository;
            _unitRepository = unitRepository;
            _documentGenerationService = documentGenerationService;
            _mapper = mapper;
            _storeService = storeService;
            _httpContextAccessor = httpContextAccessor;
            _documentExportFolder = "documents";
        }

        public async Task<DecreeDTO> GenerateDecreeAsync(string wwwroot, int templateId, string name, string number, string jsonData)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var template = await _templateRepository.GetByKeyAsync(templateId);
            var status = await _statusRepository.GetByKeyAsync((int)DecreeStatus.CREATED);

            string templateData = null;
            using (StreamReader reader = new StreamReader(await _storeService.RetrieveDataAsync(template.Path)))
            {
                templateData = reader.ReadToEnd();
            }

            var exportPath = Path.Combine(wwwroot, _documentExportFolder).Replace("\\", "/");

            _documentGenerationService.ApplyFontResolver(wwwroot);
            var bytesFile = _documentGenerationService.GeneratePdfDocumentFile(exportPath, null, templateData, jsonData);
            string path = null;
            using (var ms = new MemoryStream(bytesFile))
            {
                var pdfFile = new FormFile(ms, 0, bytesFile.Length, "name", "fileName");
                path = await _storeService.StoreDataAsync(pdfFile);
            }

            var decree = new Decree()
            {
                Name = name,
                Path = path,
                DecreeNumber = number,
                CreatedBy = userId,
                TimeStamp = DateTime.Now,
                TemplateId = templateId,
                StatusId = (int)DecreeStatus.CREATED
            };
            
            await _decreeRepository.AddAsync(decree);
            await _decreeRepository.SaveChangesAcync();

            List<TemplatePlaceholder> placeholderList = new TemplatePlaceholder().GetTemplatePlaceholders()
                .Where(x => x.TemplateId == templateId)
                .ToList();

            List<DecreeData> decreeDatas = new List<DecreeData>();
            var modelValues = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
            foreach (var keyValuePair in modelValues)
            {
                var decreeData = new DecreeData()
                {
                    Value = keyValuePair.Value,
                    DecreeId = decree.Id,
                    TemplatePlaceholderId = placeholderList.FirstOrDefault(x => x.Name == keyValuePair.Key).Id
                };
                decreeDatas.Add(decreeData);
            };
            await _decreeDataRepository.AddRangeAsync(decreeDatas);
            await _decreeDataRepository.SaveChangesAcync();

            return _mapper.Map<DecreeDTO>(decree);
        }

        public async Task<IEnumerable<DecreeDTO>> GetDecreesAsync()
        {
            var specification = new Decrees.DetailDecreesList();
            var decrees = await _decreeRepository.GetListBySpecAsync(specification);
            return _mapper.Map<IEnumerable<DecreeDTO>>(decrees);
        }

        public async Task<DecreeDTO> GetDecreeByIdAsync(int id)
        {
            var specification = new Decrees.DetailDecreeById(id);
            var decree = await _decreeRepository.GetListBySpecAsync(specification);
            return _mapper.Map<DecreeDTO>(decree.FirstOrDefault());
        }

        public async Task<FileStream> GetDecreePdfAsync(int id)
        {
            var decree = await _decreeRepository.GetByKeyAsync(id);
            if (decree.StatusId == (int)DecreeStatus.CREATED)
            {
                decree.StatusId = (int)DecreeStatus.DOWNLOADED;
                await _decreeRepository.SaveChangesAcync();
            }
            return await _storeService.RetrieveDataAsync(decree.Path);
        }

        public async Task<FileStream> GetSignedDecreePdfAsync(int id)
        {
            var decree = await _signedPdfRepository.GetByKeyAsync(id);
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
            var decree = await _decreeRepository.GetByKeyAsync(id);
            var signedPdf = await _signedPdfRepository.GetByKeyAsync(id);

            if (signedPdf == null)
            {
                signedPdf = new SignedPdf() { Id = id };
                await _signedPdfRepository.AddAsync(signedPdf);
            }

            var path = await _storeService.StoreDataAsync(sign);

            signedPdf.Path = path;

            decree.StatusId = (int)DecreeStatus.SIGNED;

            try
            {
                await _signedPdfRepository.SaveChangesAcync();
                await _decreeRepository.SaveChangesAcync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var exceptionEntry = ex.Entries.Single();
                var databaseEntry = exceptionEntry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    throw new NotFoundException($"Decree with id {id} not found");
                }
                exceptionEntry.OriginalValues.SetValues(databaseEntry);
                await _signedPdfRepository.SaveChangesAcync();
                await _decreeRepository.SaveChangesAcync();
            }  
        }

        public async Task<DecreeDTO> UpdateDecreeAsync(UpdateDecreeDTO decreeDTO)
        {
            var decree = await _decreeRepository.GetByKeyAsync(decreeDTO.Id);
            decree.Name = decreeDTO.Name;
            await ConcurrencyCheck(decreeDTO.Id);
            return _mapper.Map<DecreeDTO>(decree);
        }

        public async Task<DecreeDTO> CompleteDecreeAsync(int id)
        {
            var decree = await _decreeRepository.GetByKeyAsync(id);
            decree.StatusId = (int)DecreeStatus.COMPLETED;
            await new DecreeExecutor(_decreeDataRepository, _divisionRepository, _unitRepository).ExecuteOperation(decree.TemplateId, decree.Id);
            await ConcurrencyCheck(id);
            return _mapper.Map<DecreeDTO>(decree);
        }

        private async Task ConcurrencyCheck(int id)
        {
            try
            {
                await _decreeRepository.SaveChangesAcync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var exceptionEntry = ex.Entries.Single();
                var databaseEntry = exceptionEntry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    throw new NotFoundException($"Decree with id {id} not found");
                }
                exceptionEntry.OriginalValues.SetValues(databaseEntry);

                await _decreeRepository.SaveChangesAcync();
            }
        }

        public async Task<DecreeDTO> DeleteDecreeAsync(int id)
        {
            var decree = await _decreeRepository.GetByKeyAsync(id);
            if (decree == null)
            {
                throw new NotFoundException($"Decree with id {id} not found");
            }
            var deleteDecree = await _decreeRepository.DeleteAsync(decree);
            await _decreeRepository.SaveChangesAcync();

            return _mapper.Map<DecreeDTO>(deleteDecree);
        }
    }  
}
