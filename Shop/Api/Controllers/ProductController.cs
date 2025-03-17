using Api.Contracts.Products;
using Core.Models;
using Infrastructure.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProdutsAsync()
        {
            var product = await _service.GetAllAsync();
            return Ok(product);
        }

        [HttpPost("CreateProduct")] 
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest request)
        {
            var product = Product.Create(
                Guid.NewGuid(),
                request.Name,
                request.Caterogy,
                request.Article,
                request.Price);

            var productId = await _service.AddAsync(product);
            return Ok(productId);
        }

    }
}
