using Microsoft.AspNetCore.Mvc;

namespace Presentation
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        public ContactsController()
        {

        }

        [HttpGet]
        public ActionResult HealtCheck()
        {
            return Ok("HealtCheck");
        }
    }
}