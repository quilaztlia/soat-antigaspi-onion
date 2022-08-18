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
        //CHECK: Task<IActionResult> 
        public IActionResult HealtCheck() 
        {
            _logger.LogInfo("Log: HealtCheck");

            return Ok($"HealtCheck {this.GetType().Name}");
        }

        [HttpGet("/all")]
        public IActionResult GetAllContacts()
        {
            var contacts = _serviceManager
                .ContactService
                .GetAllContacts();

            return Ok(contacts);
        }

        [HttpGet("/{id}")]
        public IActionResult GetContact([FromQuery]int id)
        {
            var contact = _serviceManager
                .ContactService
                .GetContact(id);

            //NotFound without value => become null
            if (contact.Id == 0)
                return NotFound($"Contact {id} not found");
            
            return Ok(contact);
        }
    }
}