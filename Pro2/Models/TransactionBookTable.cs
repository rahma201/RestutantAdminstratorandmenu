namespace Pro2.Models
{
    public class TransactionBookTable :BaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string? TransactionBookTableFullName { get; set; }

        public string? TransactionBookTableEmail { get; set; }

        public string? TransactionBookTableMobileNumber { get; set; }

        public DateTime? TransactionBookTableDate { get; set; }
    }
}
