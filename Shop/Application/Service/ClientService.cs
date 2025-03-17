using Core.Models;
using Infrastructure.Abstraction;

namespace Application.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> AddAsync(Client client)
        {
            return await _repository.AddAsync(client);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<Client>> GetBirthdayClientsAsync(DateOnly date)
        {
            return await _repository.GetBirthdayClientsAsync(date);
        }

        public async Task<List<(Client Client, DateTime LastPurchaseDate)>> GetClientsWithRecentPurchasesAsync(int days)
        {
            return await _repository.GetClientsWithRecentPurchasesAsync(days);
        }
    }
}
