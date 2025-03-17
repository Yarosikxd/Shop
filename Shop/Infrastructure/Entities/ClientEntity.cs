namespace Infrastructure.Entities
{
    public class ClientEntity
    {
        public Guid Id { get;  set; }
        public string FullName { get;  set; }
        public DateTime BirthDate { get;  set; }
        public DateTime RegistrationDate { get;  set; }

        public ICollection<PurchaseEntity> Purchases { get; set; } = new List<PurchaseEntity>();
    }
}
