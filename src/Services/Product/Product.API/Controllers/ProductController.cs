using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.API.Entities;
using Product.API.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Properties
        private IProductRepository _productRepository;
        private ILogger<ProductController> _logger;

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        #endregion
        #region Operations
        [HttpGet]
        [ProducesResponseType(typeof(ProductEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProductEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductEntity>> GetProduct(string id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                _logger.LogError($"Product with id : {id},hasn't been found in the database");
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductEntity), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<ProductEntity>> CreateProduct([FromBody] ProductEntity product)
        {
            await _productRepository.Create(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product); //todo: CreatedAtRoute
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductEntity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductEntity product)
        {
            return Ok(await _productRepository.Update(product));
        }


        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(ProductEntity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _productRepository.Delete(id));
        }
        #endregion
    }
}
