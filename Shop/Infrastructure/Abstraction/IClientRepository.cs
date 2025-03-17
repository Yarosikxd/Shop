using Core.Models;
using Infrastructure.Entities;

namespace Infrastructure.Abstraction
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllAsync();
        Task<Guid> AddAsync(Client client);
        Task<List<Client>> GetBirthdayClientsAsync(DateOnly date);
        Task<List<(Client Client, DateTime LastPurchaseDate)>> GetClientsWithRecentPurchasesAsync(int days);
    }
}
