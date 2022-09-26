using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.DTO.Attachments;
using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Interfaces.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecreesController : ControllerBase
    {
        private readonly IDecreeService _decreeService;
        private readonly string _webRootPath;

        public DecreesController(IDecreeService decreeService,
                                IWebHostEnvironment hostingEnvironment)
        {
            _decreeService = decreeService;
            _webRootPath = hostingEnvironment.WebRootPath;
        }

        [HttpPost]
        [Route("generate")]
        public async Task<ActionResult> GenerateDecree([FromQuery] int templateId, [FromQuery] string name)
        {
            Request.EnableBuffering();
            Request.Body.Seek(0, SeekOrigin.Begin);
            string jsonRawData = new StreamReader(HttpContext.Request.Body).ReadToEnd();
            var decree = await _decreeService.GenerateDecreeAsync(_webRootPath, templateId, name, jsonRawData);
            return CreatedAtRoute(nameof(GetById), new { id = decree.Id }, decree);
        }

        [HttpGet]
        [Route("collection")]
        public async Task<ActionResult<IEnumerable<DecreeDTO>>> Get()
        {
            var decrees = await _decreeService.GetDecreesAsync();
            return Ok(decrees);
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        public async Task<ActionResult<Decree>> GetById([FromRoute] int id)
        {
            var decree = await _decreeService.GetDecreeByIdAsync(id);
            return Ok(decree);
        }

        [HttpGet("collection/byName/{documentName}")]
        public async Task<ActionResult<IEnumerable<DecreeDTO>>> GetByName([FromRoute] string name)
        {
            var decrees = await _decreeService.GetDecreesByNameAsync(name);
            return Ok(decrees);
        }

        [HttpGet("pdf/{documentId}")]
        public async Task<FileStreamResult> GetPdfById([FromRoute] int id)
        {
            var fileStream = await _decreeService.GetDecreePdfAsync(id);
            return new FileStreamResult(fileStream, "application/pdf");
        }

        [HttpPost]
        [Route("pdf/upload/{documentId}")]
        public async Task<ActionResult> UploadPdfSigned([FromRoute] int id)
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            await _decreeService.UploadSignedDecreeAsync(id, file);
            return Ok();
        }
    }
}
