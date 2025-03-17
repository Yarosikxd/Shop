using AutoMapper;
using Core.Models;
using Infrastructure.Abstraction;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositoryes
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataBaseDbContext _context;
        private readonly IMapper _mapper;

        public ClientRepository(DataBaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(Client client)
        {
            var clientEntity = new ClientEntity
            {
                Id = client.Id,
                FullName = client.FullName,
                BirthDate = client.BirthDate,
                RegistrationDate = client.RegistrationDate
            };

            await _context.Clients.AddAsync(clientEntity);
            await _context.SaveChangesAsync();

            return clientEntity.Id;
        }

        public async Task<Guid> DeleteAsync(Guid clientId)
        {
           var clientEntity = await _context.Clients.FindAsync(clientId);
            if (clientEntity != null) 
            {
                _context.Clients.Remove(clientEntity);
                await _context.SaveChangesAsync();
            }

            return clientEntity.Id;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            var clientEntity = await _context.Clients.ToListAsync();
            return clientEntity.Select(c => _mapper.Map<Client>(c)).ToList();
        }

        public async Task<List<Client>> GetBirthdayClientsAsync(DateOnly date)
        {
            var clientEntities = await _context.Clients
            .Where(c => c.BirthDate.Month == date.Month && c.BirthDate.Day == date.Day)
            .ToListAsync();

            return clientEntities.Select(c => _mapper.Map<Client>(c)).ToList();
        }

        public async Task<Client> GetByIdAsync(Guid clientId)
        {
            ClientEntity clientEntity = await _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == clientId);

            Client client = _mapper.Map<Client>(clientEntity);

            return client;
        }

        public async Task<List<(Client Client, DateTime LastPurchaseDate)>> GetClientsWithRecentPurchasesAsync(int days)
        {
            var cutoffDate = DateTime.UtcNow.AddDays(-days); 

            return await _context.Set<Client>()
                .Where(c => c.Purchases.Any(p => p.Date >= cutoffDate)) 
                .Select(c => new
                {
                    Client = c,
                    LastPurchaseDate = c.Purchases.Max(p => p.Date) 
                })
                .ToListAsync()
                .ContinueWith(task =>
                    task.Result.Select(x => (x.Client, x.LastPurchaseDate)).ToList() 
                );
        }


        public async Task<Guid> UpdateAsync(Guid id, string fullName, DateTime birthday)
        {
            var clientEntity = await _context.Clients.FindAsync(id);
            if (clientEntity != null)
            {
                clientEntity.FullName = fullName;
                clientEntity.BirthDate = birthday;
                await _context.SaveChangesAsync();
            }

            return id;
        }
    }
}
