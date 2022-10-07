using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.DTO.Attachments;
using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Interfaces.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpGet]
        [Route("collection")]
        public async Task<ActionResult<IEnumerable<DecreeDTO>>> Get()
        {
            var decrees = await _decreeService.GetDecreesAsync();
            return Ok(decrees);
        }

        [HttpGet("collection/byName/{name}")]
        public async Task<ActionResult<IEnumerable<DecreeDTO>>> GetByName([FromRoute] string name)
        {
            var decrees = await _decreeService.GetDecreesByNameAsync(name);
            return Ok(decrees);
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        public async Task<ActionResult<Decree>> GetById([FromRoute] int id)
        {
            var decree = await _decreeService.GetDecreeByIdAsync(id);
            return Ok(decree);
        }

        [HttpPost]
        public async Task<ActionResult> GenerateDecree()
        {
            Request.EnableBuffering();
            Request.Body.Seek(0, SeekOrigin.Begin);
            string jsonData = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            int templateId;
            string decreeName;
            var modelValues = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
            try
            {
                templateId = (int)(long)modelValues["templateId"];
                modelValues.Remove("templateId");
                decreeName = (string)modelValues["decreeName"];
                modelValues.Remove("decreeName");
            }
            catch (Exception)
            {
                return BadRequest("Request body should include \"templateId\" and \"decreeName\" fields. The rest fields for template data");
            }
            jsonData = JsonConvert.SerializeObject(modelValues);
            var decree = await _decreeService.GenerateDecreeAsync(_webRootPath, templateId, decreeName, jsonData);
            return CreatedAtRoute(nameof(GetById), new { id = decree.Id }, decree);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDecree([FromBody] UpdateDecreeDTO decreeDTO)
        {
            var decree = await _decreeService.UpdateDecreeAsync(decreeDTO);
            return Ok(decree);
        }

        [HttpPut("complete/{id}")]
        public async Task<ActionResult> CompleteDecree([FromRoute] int id)
        {
            var decree = await _decreeService.CompleteDecreeAsync(id);
            return Ok(decree);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDecree([FromRoute] int id)
        {
            var decree = await _decreeService.DeleteDecreeAsync(id);
            return Ok(decree);
        }
    }
}
