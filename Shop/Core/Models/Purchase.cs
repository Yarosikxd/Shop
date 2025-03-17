namespace Core.Models
{
    public class Purchase
    {

        private Purchase(Guid id, DateTime date, decimal totalAmount, Guid clientId)
        {
            Id = id;
            Date = date;
            TotalAmount = totalAmount;
            ClientId = clientId;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public List<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

        public static Purchase Create(Guid Id, decimal totalAmount, Guid clientId)
        {
            return new Purchase(Guid.NewGuid(), DateTime.UtcNow,  totalAmount,  clientId);
        }
    }
}
