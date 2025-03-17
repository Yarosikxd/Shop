using System.ComponentModel.DataAnnotations;

namespace Api.Contracts.Clients
{
    public record ClientBirthdayRequest
    (
        [Required] DateOnly Date
    );
    
}
