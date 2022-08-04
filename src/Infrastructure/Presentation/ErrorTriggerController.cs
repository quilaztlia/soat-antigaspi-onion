using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Rest
{
    [ApiController]
    [Route("api/error")]
    public class ErrorTriggerController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ErrorTriggerController(IServiceManager serviceManager) => 
            _serviceManager = serviceManager;

        [HttpGet]
        public Task TriggerException()
        {
            throw new Exception("Testing CustomExceptionHandlingMiddleware");
        }
    }
}
