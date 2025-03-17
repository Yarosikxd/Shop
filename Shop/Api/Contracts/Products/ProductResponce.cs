namespace Api.Contracts.Products
{
    public record ProductResponce
    (
        Guid Id,
        string Name,
        string Category,
        string Article,
        decimal Price
    );
}
