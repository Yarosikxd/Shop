using Core.Models;
using Infrastructure.Entities;

namespace Infrastructure.Abstraction
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Guid> AddAsync(Product product); 
    }
}
