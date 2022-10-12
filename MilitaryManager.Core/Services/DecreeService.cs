using AutoMapper;
using BusinessLogic.Services.Documents;
using Microsoft.AspNetCore.Http;
using MilitaryManager.Core.DTO.Attachments;
using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Entities.SignedPdfEntity;
using MilitaryManager.Core.Entities.StatusEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Enums;
using MilitaryManager.Core.Exceptions;
using MilitaryManager.Core.Interfaces;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
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
        protected readonly IDocumentGenerationService _documentGenerationService;
        protected readonly IMapper _mapper;
        protected readonly IStoreService _storeService;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _documentExportFolder;

        public DecreeService(IRepository<Decree, int> decreeRepository,
                             IRepository<Template, int> templateRepository,
                             IRepository<Status, int> statusRepository,
                             IRepository<SignedPdf, int> signedPdfRepository,
                             IDocumentGenerationService documentGenerationService,
                             IMapper mapper,
                             IStoreService storeService,
                             IHttpContextAccessor httpContextAccessor)
        {
            _decreeRepository = decreeRepository;
            _templateRepository = templateRepository;
            _statusRepository = statusRepository;
            _signedPdfRepository = signedPdfRepository;
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
            await _signedPdfRepository.SaveChangesAcync();
            await _decreeRepository.SaveChangesAcync();
        }

        public async Task<DecreeDTO> UpdateDecreeAsync(UpdateDecreeDTO decreeDTO)
        {
            var decree = await _decreeRepository.GetByKeyAsync(decreeDTO.Id);
            decree.Name = decreeDTO.Name;
            await _decreeRepository.SaveChangesAcync();
            return _mapper.Map<DecreeDTO>(decree);
        }

        public async Task<DecreeDTO> CompleteDecreeAsync(int id)
        {
            var decree = await _decreeRepository.GetByKeyAsync(id);
            decree.StatusId = (int)DecreeStatus.COMPLETED;
            await _decreeRepository.SaveChangesAcync();
            return _mapper.Map<DecreeDTO>(decree);
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
