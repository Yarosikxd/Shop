using AutoMapper;
using Core.Models;
using Infrastructure.Abstraction;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositoryes
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataBaseDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(DataBaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(Product product)
        {
            var productEntity = new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Article = product.Article,
                Price = product.Price
            };

            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return productEntity.Id;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var productEntity = await _context.Products.ToListAsync();
            return productEntity.Select(p => _mapper.Map<Product>(p)).ToList();
        }
    }
}
