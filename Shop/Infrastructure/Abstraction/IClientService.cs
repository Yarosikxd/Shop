using Core.Models;

namespace Infrastructure.Abstraction
{
    public interface IClientService
    {
        Task<List<Client>> GetAllAsync();
        Task<Guid> AddAsync(Client client);
        Task<List<Client>> GetBirthdayClientsAsync(DateOnly date);
        Task<List<(Client Client, DateTime LastPurchaseDate)>> GetClientsWithRecentPurchasesAsync(int days);
    }
}
