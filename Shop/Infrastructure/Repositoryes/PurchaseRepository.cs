using Core.Models;
using Infrastructure.Abstraction;
using Infrastructure.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositoryes
{
    public class PurchaseRepository : IPurchaseRepostory
    {
        private readonly DataBaseDbContext _context;

        public PurchaseRepository(DataBaseDbContext context)
        {
            _context = context;
           
        }
        public async Task<Guid> AddAsync(Purchase purchase)
        {
            var purchaseEntity = new PurchaseEntity
            {
                Id = purchase.Id,
                Date = purchase.Date,
                TotalAmount = purchase.TotalAmount,
                ClientId = purchase.ClientId
            };

            await _context.Purchases.AddAsync(purchaseEntity);
            await _context.SaveChangesAsync();

            return purchaseEntity.Id;
        }

        public async Task<List<(string Category, int Quantity)>> GetClientPurchasedCategoriesAsync(Guid clienId)
        {
            return await _context.Purchases
                    .Where(p => p.ClientId == clienId)
                    .SelectMany(p => p.PurchaseItems)  
                    .GroupBy(pi => pi.Product.Category) 
                    .Select(g => new
                    {
                        Category = g.Key,
                        Quantity = g.Sum(pi => pi.Quantity)  
                    })
                    .ToListAsync()
                    .ContinueWith(task => task.Result.Select(c => (c.Category, c.Quantity)).ToList());
        }

        public async Task<List<(Guid id, string FullName, DateTime LastPurchaseDate)>> GetClientsWithRecentPurchasesAsync(int days)
        {
            var cutoffDate = DateTime.UtcNow.AddDays(-days);

            var result = await _context.Purchases
                .Where(p => p.Date >= cutoffDate)
                .GroupBy(p => p.Client)
                .Select(g => new
                {
                    Id = g.Key.Id,
                    FullName = g.Key.FullName,
                    LastPurchaseDate = g.Max(p => p.Date)
                })
                .ToListAsync();

            return result.Select(r => (id: r.Id, FullName: r.FullName, LastPurchaseDate: r.LastPurchaseDate)).ToList();
        }


    }
}
