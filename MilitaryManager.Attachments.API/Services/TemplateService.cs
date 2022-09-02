using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MilitaryManager.Attachments.API.Entities;
using MilitaryManager.Attachments.API.Exceptions;
using MilitaryManager.Attachments.API.Interfaces;
using MilitaryManager.Attachments.API.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ITemplateService> _logger;
        private readonly string _webRootPath;

        public TemplateService(IUnitOfWork unitOfWork, 
                               ILogger<ITemplateService> logger,
                               IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _webRootPath = hostingEnvironment.WebRootPath;
        }

        public async Task<IEnumerable<Template>> GetTemplatesAsync()
        {
            return await _unitOfWork.TemplateRepository.Get();
        }

        public async Task<string> GetTemplateDataByIdAsync(int id)
        {
            var template = await _unitOfWork.TemplateRepository.FindById(id);
            try
            {
                return File.ReadAllText(Path.Combine(_webRootPath, template.Path));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Template for {template.Name} document is not available");
                throw new NotFoundException($"Template for {template.Name} document is not available");
            }
        }
    }
}
