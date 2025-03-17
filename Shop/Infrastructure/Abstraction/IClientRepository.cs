using Core.Models;
using Infrastructure.Entities;

namespace Infrastructure.Abstraction
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(Guid clientId);
        Task<List<Client>> GetAllAsync();
        Task<Guid> AddAsync(Client client);
        Task<Guid> UpdateAsync(Guid Id, string fullName, DateTime birthday);
        Task<Guid> DeleteAsync(Guid clientId);
        Task<List<Client>> GetBirthdayClientsAsync(DateOnly date);
        Task<List<(Client Client, DateTime LastPurchaseDate)>> GetClientsWithRecentPurchasesAsync(int days);
    }
}
