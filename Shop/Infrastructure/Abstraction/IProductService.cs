using Core.Models;

namespace Infrastructure.Abstraction
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Guid> AddAsync(Product product);
    }
}
