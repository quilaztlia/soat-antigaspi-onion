using Contracts;
using LoggerService.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Rest
{
    [ApiController]
    //[Route("api/[controller]")] //Convention-based routing
    [Route("api/offers")]
    public class OffersController : ControllerBase
    {
        private readonly ICustomLoggerManager _logger;
        private readonly IServiceManager _serviceManager;

        public OffersController(ICustomLoggerManager logger, IServiceManager serviceManager)
        {
            _logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet("healthCheck")]
        public ActionResult HealtCheck()
        {
            return Ok("HealtCheck"); 
        }

        [HttpPost]
        public IActionResult CreateOffer([FromBody] OfferCreationRequest offer)
        {
            //CHECK: Logic a decaler dans le service ??
            //CHECK: (offer == null) ?
            if (offer is null || !ModelState.IsValid)
            {
                _logger.LogWarn($"Incorrect call {offer?.ToString()}");

                return BadRequest("Offer request is incorrect");
            }
            var offerCreated = _serviceManager
                                .OfferService
                                .CreateOffer(offer);

            //CHECK: I cant do this bcs EF? Or how I do it?
            //if(offerCreated.Id == default) {                     
            //    return StatusCode(StatusCodes.Status500InternalServerError, "InternalServerError: Offer not created");
            //}

            //CHECK: why CreatedAtRoute & not Ok(offerCreated);
            var created = CreatedAtRoute("OfferById", offerCreated);
            
            return created;
        }

        [HttpGet("{id}", Name ="GetOfferById")]
        public IActionResult GetOfferById([FromHeader]Guid id)
        {
            var offer = _serviceManager
                            .OfferService
                            .GetOfferById(id);
            if (offer.Id != id)            
                return NotFound($"Offer id: {id} not found");
            
            return Ok(offer);
        }

        [HttpGet("/all", Name = "all")]
        public IActionResult GetAllOffers()
        {
            var offers = _serviceManager
                .OfferService
                .GetAllOffers();

            return Ok(offers);
        }
    }
}