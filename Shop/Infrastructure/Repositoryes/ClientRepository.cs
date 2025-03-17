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
            try 
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
            catch (Exception ex)
            {
                throw new Exception("Faiid to create new Client", ex);
            } 
        }

        public async Task<List<Client>> GetAllAsync()
        {
            try
            {
                var clientEntity = await _context.Clients.ToListAsync();
                return clientEntity.Select(c => _mapper.Map<Client>(c)).ToList();
            }
            catch (Exception ex) 
            {
                throw new Exception("Fail to ger all Clients", ex);
            }
        }

        public async Task<List<Client>> GetBirthdayClientsAsync(DateOnly date)
        {
            try
            {
                var clientEntities = await _context.Clients
                    .Where(c => c.BirthDate.Month == date.Month && c.BirthDate.Day == date.Day)
                    .ToListAsync();

                return clientEntities.Select(c => _mapper.Map<Client>(c)).ToList();
            }
            catch (Exception ex) 
            {
                throw new Exception("Fail", ex);
            }
           
        }

        public async Task<List<(Client Client, DateTime LastPurchaseDate)>> GetClientsWithRecentPurchasesAsync(int days)
        {
            try
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
            catch (Exception ex) 
            {
                throw new Exception("Fail", ex);
            }
            
        }
    }
}
