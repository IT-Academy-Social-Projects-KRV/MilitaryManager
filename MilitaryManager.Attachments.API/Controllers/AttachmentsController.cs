using BusinessLogic.Services.Documents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using MilitaryManager.Core.Interfaces.Services;
using Newtonsoft.Json;

namespace MilitaryManager.Attachments.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttachmentsController : ControllerBase
    {
        private readonly IDocumentGenerationService _documentGenerationService;
        private readonly string _webRootPath;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly string _documentExportFolder;

        private readonly IUnitService _unitService;

        public AttachmentsController(IWebHostEnvironment hostingEnvironment,
            IDocumentGenerationService service,
            ILogger<WeatherForecastController> logger,
            IUnitService UnitService)
        {
            _documentGenerationService = service;
            _webRootPath = hostingEnvironment.WebRootPath;
            _logger = logger;
            _documentExportFolder = "documents";

            _unitService = UnitService;
        }

        [HttpGet]
        [Route("find")]
        public FileStreamResult GetDocument([FromQuery] string name)
        {
            string path = Path.Combine(_webRootPath, _documentExportFolder, name);
            FileStream fileStream = new FileStream(path, FileMode.Open);

            return new FileStreamResult(fileStream, "application/pdf");
        }

        [HttpGet]
        [Route("generate")]
        public string GenerateNewDocument()
        {
            var documentTemplatesPath = Path.Combine(_webRootPath, "data", "document_templates");

            var templateName = "template_02";
            string templateData = null;
            try
            {
                string path = Path.Combine(documentTemplatesPath, $"{templateName}.xml");
                templateData = System.IO.File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Template for {templateName} document is not available");
            }

            var unit = _unitService.GetUnitAsync(5).Result;
            var obj = new { lastName = unit.LastName, firstName = unit.FirstName };
            var jsonData = JsonConvert.SerializeObject(obj);

            _documentGenerationService.ApplyFontResolver("/wwwroot"); //_webRootPath);

            string docPath = Path.Combine(_webRootPath, _documentExportFolder);

            var docName = _documentGenerationService.GeneratePdfDocument(docPath,
                templateName, templateData, jsonData);

            return $"https://{Request.Host}/api/attachments/find?name={docName}";
        }
    }
}