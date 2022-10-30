using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sourcing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private ILogger<AuctionController> _logger;

        public BidController(ILogger<AuctionController> logger)
        {
            _logger = logger;
        }
    }
}
