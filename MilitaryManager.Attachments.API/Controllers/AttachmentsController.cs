using BusinessLogic.Services.Documents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        public AttachmentsController(
            IWebHostEnvironment hostingEnvironment,
            IDocumentGenerationService service,
            ILogger<WeatherForecastController> logger)
        {
            _documentGenerationService = service;
            _webRootPath = hostingEnvironment.WebRootPath;
            _logger = logger;
            _documentExportFolder = "documents";
        }

        [HttpGet(Name="find")]
        [Route("find")]
        public FileStreamResult GetDocument([FromQuery] string name)
        {
            FileStream fileStream = new FileStream($"{_webRootPath}\\{_documentExportFolder}\\{name}", FileMode.Open);

            return new FileStreamResult(fileStream, "application/pdf");
        }

        // GET: GetTemplates

        [HttpPost]
        [Route("generate")]
        public IActionResult GenerateNewDocument([FromQuery] string templateName)
        {
            var documentTemplatesPath = $"{_webRootPath}/data/document_templates";

            // reads raw json body and removes special symbols
            Request.EnableBuffering();
            Request.Body.Seek(0, SeekOrigin.Begin);
            string jsonRawData = new StreamReader(HttpContext.Request.Body).ReadToEnd();

            string cleanData = string.Join("", Regex.Split(jsonRawData, @"(?:\r\n|\n|\r|\s)"));

            string templateData = null;
            try
            {
                templateData = System.IO.File.ReadAllText($"{documentTemplatesPath}/{templateName}.xml");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Template for {templateName} document is not available");
            }

            _documentGenerationService.ApplyFontResolver(_webRootPath);
            var docName = _documentGenerationService.GeneratePdfDocument($"{_webRootPath}/{_documentExportFolder}", templateName, templateData, cleanData);

            return CreatedAtRoute("find", new { name = docName }, docName);
        }
    }
}
