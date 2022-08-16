using LoggerService.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Rest
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ICustomLoggerManager _logger;
        private readonly IServiceManager _serviceManager;

        public ContactsController(ICustomLoggerManager logger, IServiceManager serviceManager) {
            _logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet("/healthCheck")]
        //CHECK;  Task<IActionResult> 
        public async Task<ActionResult> HealtCheck()
        {
            _logger.LogInfo("HealtCheck-1");
            return Ok("HealtCheck");
        }

        [HttpGet("/all")]
        public /*async*/ IActionResult GetAllContacts()
        {
            var contacts = _serviceManager
                .ContactService
                .GetAllContacts();

            return Ok(contacts);
        }

        [HttpGet("/{id}")]
        public IActionResult GetContact([FromQuery]int id)
        {
            var contact = _serviceManager.ContactService.GetContact(id);
            
            return Ok(contact);
        }
    }
}