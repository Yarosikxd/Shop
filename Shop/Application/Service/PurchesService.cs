using Core.Models;
using Infrastructure.Abstraction;

namespace Application.Service
{
    public class PurchesService : IPurchesService
    {
        private readonly IPurchaseRepostory _repostory;

        public PurchesService(IPurchaseRepostory repository )
        {
            _repostory = repository;
        }

        public async Task<Guid> AddAsync(Purchase purchase)
        {
           return await _repostory.AddAsync( purchase );
        }

        public async Task<List<(string Category, int Quantity)>> GetClientPurchasedCategoriesAsync(Guid clienId)
        {
            return await _repostory.GetClientPurchasedCategoriesAsync(clienId);
        }

        public async Task<List<(Guid id, string FullName, DateTime LastPurchaseDate)>> GetClientsWithRecentPurchasesAsync(int days)
        {
            return await _repostory.GetClientsWithRecentPurchasesAsync(days);
        }
    }
}
