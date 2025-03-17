using System.ComponentModel.DataAnnotations;

namespace Api.Contracts.Products
{
    public record CreateProductRequest
    (
        [Required] string Name,
        [Required] string Caterogy,
        [Required] string Article,
        [Required] decimal Price
    );
}
