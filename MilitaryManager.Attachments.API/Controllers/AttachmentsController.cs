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

        public AttachmentsController(IWebHostEnvironment hostingEnvironment, IDocumentGenerationService service,
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
            FileStream fileStream = new FileStream($@"{_webRootPath}/{_documentExportFolder}/{name}", FileMode.Open);

            return new FileStreamResult(fileStream, "application/pdf");
        }

        [HttpGet]
        [Route("generate")]
        public string GenerateNewDocument()
        {
            var documentTemplatesPath = $@"{_webRootPath}/data/document_templates";

            var templateName = "template_02";
            string templateData = null;
            try
            {
                templateData = System.IO.File.ReadAllText($@"{documentTemplatesPath}/{templateName}.xml");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Template for {templateName} document is not available");
            }

            //var jsonData = "{\"city\":\"Рівне\",\"currentDate\":\"08.09.2022\",\"decreeNumber\":\"777\"}";
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
}";

           

            _documentGenerationService.ApplyFontResolver("/wwwroot"); //_webRootPath);
            var docName = _documentGenerationService.GeneratePdfDocument($@"{_webRootPath}/{_documentExportFolder}",
                templateName, templateData, jsonData);

            return $"https://{Request.Host}/api/attachments/find?name={docName}";
        }
    }
}