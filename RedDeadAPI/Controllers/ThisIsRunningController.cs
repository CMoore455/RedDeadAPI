using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Controllers
{
	[ApiExplorerSettings(IgnoreApi = true)]
	[ApiController]
	[Route("[controller]")]
	public class ThisIsRunningController : ControllerBase
	{
		public ThisIsRunningController()
		{
		}
		
		[HttpGet]
		public ActionResult<ThisIsRunning> Get()
		{

			return new ThisIsRunning();
		}
	}
}
