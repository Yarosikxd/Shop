namespace Api.Contracts.Clients
{
    public record ClientResponse
    (
        Guid Id,
        string FullName,
        DateTime Birthday,
        DateTime RegistrationDate
    ); 
}
