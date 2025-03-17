namespace Core.Models
{
    public class Client
    {
        private Client(Guid id, string fullName, DateTime birthDate, DateTime registrationDate)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            RegistrationDate = registrationDate;
        }

        public Guid Id { get;  set; } = Guid.NewGuid();
        public string FullName { get;  set; }
        public DateTime BirthDate { get;  set; }
        public DateTime RegistrationDate { get;  set; }

        public List<Purchase> Purchases { get; set; } = new List<Purchase>();

        public static Client Create(Guid id, string fullName, DateTime birthDate)
        {
            return new Client(Guid.NewGuid(), fullName, birthDate, DateTime.UtcNow);
        }
    }

}
