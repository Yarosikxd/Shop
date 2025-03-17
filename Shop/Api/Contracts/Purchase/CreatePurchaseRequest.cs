using System.ComponentModel.DataAnnotations;

namespace Api.Contracts.Purchase
{
    public record CreatePurchaseRequest
    (
        [Required] decimal TotalAmount,
        [Required] Guid ClientId
    );
    
}
