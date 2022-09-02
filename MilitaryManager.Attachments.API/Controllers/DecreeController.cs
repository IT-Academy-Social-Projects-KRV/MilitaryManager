using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Attachments.API.Entities;
using MilitaryManager.Attachments.API.Interfaces.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecreeController : ControllerBase
    {
        private readonly IDecreeService _decreeService;

        public DecreeController(IDecreeService decreeService)
        {
            _decreeService = decreeService;
        }

        [HttpPost]
        [Route("generate")]
        public async Task<ActionResult> GenerateDocument([FromQuery] int templateId, [FromQuery] string name)
        {
            Request.EnableBuffering();
            Request.Body.Seek(0, SeekOrigin.Begin);
            string jsonRawData = new StreamReader(HttpContext.Request.Body).ReadToEnd();
            //TODO: return DecreeDTO, to avoid recursion
            var decree = await _decreeService.GenerateDocument(templateId, name, jsonRawData);
            return CreatedAtRoute(nameof(GetById), new { documentId = decree.Id }, decree);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Decree>>> Get()
        {
            var decrees = await _decreeService.GetDocuments();
            return Ok(decrees);
        }

        [HttpGet("{documentId}", Name = nameof(GetById))]
        public async Task<ActionResult<Decree>> GetById([FromRoute] int documentId)
        {
            var decree = await _decreeService.GetDocumentById(documentId);
            return Ok(decree);
        }

        [HttpGet("pdf/{documentId}")]
        public async Task<FileStreamResult> GetPdfById([FromRoute] int documentId)
        {
            var fileStream = await _decreeService.GetDocumentPdf(documentId);
            return new FileStreamResult(fileStream, "application/pdf");
        }

        [HttpPost]
        [Route("pdf/upload/{documentId}")]
        public async Task<ActionResult> UploadPdfSigned([FromRoute] int documentId)
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            await _decreeService.UploadSignedDocument(documentId, file);
            return Ok();
        }
    }
}
