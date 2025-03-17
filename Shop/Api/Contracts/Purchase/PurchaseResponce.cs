namespace Api.Contracts.Purchase
{
    public record PurchaseResponce
    (
        Guid Id,
        DateTime Date,
        decimal TotalAmount,
        Guid ClientId
    );
}
