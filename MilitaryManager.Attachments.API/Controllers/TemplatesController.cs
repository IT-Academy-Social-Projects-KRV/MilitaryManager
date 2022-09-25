using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Exceptions;
using MilitaryManager.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateService _templateService;

        public TemplatesController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<ActionResult<IEnumerable<Template>>> Get()
        {
            try
            {
                var templates = await _templateService.GetTemplatesAsync();
                return Ok(templates);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
