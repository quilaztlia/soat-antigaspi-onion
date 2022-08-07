using LoggerService.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Rest
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IServiceManager _serviceManager;

        public ContactsController(ILoggerManager logger, IServiceManager serviceManager) {
            _logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        //CHECK;  Task<IActionResult> 
        public async Task<ActionResult> HealtCheck()
        {
            _logger.LogInfo("HealtCheck-1");
            return Ok("HealtCheck");
        }
    }
}