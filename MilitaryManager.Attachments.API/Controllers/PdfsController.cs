using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.DTO.Attachments;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfsController : ControllerBase
    {
        private readonly IDecreeService _decreeService;

        public PdfsController(IDecreeService decreeService)
        {
            _decreeService = decreeService;
        }

        [HttpGet("{id}")]
        public async Task<FileStreamResult> GetPdfById([FromRoute] int id)
        {
            var fileStream = await _decreeService.GetDecreePdfAsync(id);
            return new FileStreamResult(fileStream, "application/pdf");
        }

        [HttpGet("signed/{id}")]
        public async Task<FileStreamResult> GetSignedPdfById([FromRoute] int id)
        {
            var fileStream = await _decreeService.GetSignedDecreePdfAsync(id);
            return new FileStreamResult(fileStream, "application/pdf");
        }

        [HttpPut]
        public async Task<ActionResult> UploadPdfSigned([FromForm] UploadPdfSignedDTO uploadPdfSignedDTO)
        {
            await _decreeService.UploadSignedDecreeAsync(uploadPdfSignedDTO.Id, uploadPdfSignedDTO.File);
            return Ok();
        }
    }
}
