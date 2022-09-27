using BusinessLogic.Services.Documents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
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

            var jsonData = @"{city:'Рівне',currentDate:'08.09.2022',decreeNumber:'777'
                            ,lastname:'Скайуокера'
                            ,name:'Люка'
                            ,middlename:'Івановича'
                            ,unitNumber:'№ 5'
                            ,unitNumberNew:'№ 6'
                            ,decreeNumber2:'17'
                            ,day:'05'
                            ,month:'липня'
                            ,year:'2022'
                            ,percent:'15'
                            ,anotherPercent:'25'
                            ,first:'01'
                            ,last:'30'
                            ,newPlace:'військової частини № 7'
                            ,father:'Вовк Євгеній Андрійович'
                            }";

            _documentGenerationService.ApplyFontResolver("/wwwroot"); //_webRootPath);

            string docPath = Path.Combine(_webRootPath, _documentExportFolder);
            var docName = _documentGenerationService.GeneratePdfDocument(docPath,
                templateName, templateData, jsonData);

            return $"https://{Request.Host}/api/attachments/find?name={docName}";
        }
    }
}