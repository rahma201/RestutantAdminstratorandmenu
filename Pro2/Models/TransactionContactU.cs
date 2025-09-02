namespace Pro2.Models
{
    public class TransactionContactU :BaseEntity
    {
        public string? TransactionContactUsFullName { get; set; }

        public string? TransactionContactUsEmail { get; set; }

        public string? TransactionContactUsSubject { get; set; }

        public string? TransactionContactUsMessage { get; set; }
    }
}
