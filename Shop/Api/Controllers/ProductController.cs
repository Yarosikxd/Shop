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
            try
            {
                var product = await _service.GetAllAsync();
                return Ok(product);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            
        }

        [HttpPost("CreateProduct")] 
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest request)
        {
            try
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
            catch (Exception ex) 
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            
        }

    }
}
