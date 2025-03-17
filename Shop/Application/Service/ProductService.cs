using Core.Models;
using Infrastructure.Abstraction;

namespace Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> AddAsync(Product product)
        {
           return await _repository.AddAsync(product);
        }

        public async Task<List<Product>> GetAllAsync()
        {
          return await _repository.GetAllAsync();
        }
    }
}
