using Core.Models;

namespace Infrastructure.Abstraction
{
    public interface IPurchesService
    {
        Task<Guid> AddAsync(Purchase purchase);
        Task<List<(Guid id, string FullName, DateTime LastPurchaseDate)>> GetClientsWithRecentPurchasesAsync(int days);
        Task<List<(string Category, int Quantity)>> GetClientPurchasedCategoriesAsync(Guid clienId);

    }
}
