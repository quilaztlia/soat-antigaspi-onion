using Microsoft.AspNetCore.Mvc;

namespace Presentation.Rest
{
    [ApiController]
    //[Route("api/[]")]
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