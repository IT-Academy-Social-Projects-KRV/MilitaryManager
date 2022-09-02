using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Attachments.API.Entities;
using MilitaryManager.Attachments.API.Exceptions;
using MilitaryManager.Attachments.API.Interfaces.Services;
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

        [HttpGet]
        [Route("data/{Id}")]
        public async Task<ActionResult<string>> GetData([FromRoute] int Id)
        {
            try
            {
                var templateData = await _templateService.GetTemplateDataByIdAsync(Id);
                return Ok(templateData);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
