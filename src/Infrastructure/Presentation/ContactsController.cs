using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Rest
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ContactsController(IServiceManager serviceManager) =>
            _serviceManager = serviceManager;

        [HttpGet]
        //CHECK;  Task<IActionResult> 
        public async Task<ActionResult> HealtCheck()
        {
            return Ok("HealtCheck");
        }
    }
}