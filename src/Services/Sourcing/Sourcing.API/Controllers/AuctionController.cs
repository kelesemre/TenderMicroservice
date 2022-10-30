using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sourcing.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private ILogger<AuctionController> _logger;

        public AuctionController(ILogger<AuctionController> logger)
        {
            _logger = logger;
        }

    }
}
