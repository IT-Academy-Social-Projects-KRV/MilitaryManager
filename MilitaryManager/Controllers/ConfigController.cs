using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MilitaryManager.Models;
using System.Threading.Tasks;

namespace MilitaryManager.Controllers
{
	[Route("api/[controller]")]
	public class ConfigController
	{
		private AppConfiguration _options;

		public ConfigController(IOptions<AppConfiguration> options)
		{
			_options = options.Value;
		}

		/// <summary>
		/// Get test
		/// </summary>
		/// <returns>Collection of records</returns>
		[HttpGet]
		public virtual async Task<ActionResult> GetAll()
		{
			return new JsonResult(_options);
		}
	}
}
