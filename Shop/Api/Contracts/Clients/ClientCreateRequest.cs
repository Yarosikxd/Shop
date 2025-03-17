using System.ComponentModel.DataAnnotations;

namespace Api.Contracts.Clients
{
    public record ClientCreateRequest
    (
        [Required] string FullName,
        [Required] DateTime Birthday
    );
}
