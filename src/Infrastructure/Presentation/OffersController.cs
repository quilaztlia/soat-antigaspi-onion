using Microsoft.AspNetCore.Mvc;

namespace Presentation.Rest
{
    [ApiController]
    //[Route("api/[controller]")] //Convention-based routing
    [Route("api/offers")]
    public class OffersController : ControllerBase
    {
        public OffersController()
        {            
        }

        [HttpGet]
        public ActionResult HealtCheck()
        {
            return Ok("HealtCheck"); //Results.();
        }
    }
}