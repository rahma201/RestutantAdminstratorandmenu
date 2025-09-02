using Pro2.Models;

namespace Pro2.View_Models
{
    public class TransactionContactUFullViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string? TransactionContactUsFullName { get; set; }

        public string? TransactionContactUsEmail { get; set; }

        public string? TransactionContactUsSubject { get; set; }

        public string? TransactionContactUsMessage { get; set; }
        public List<TransactionContactUViewModel> TransactionContactUList { get; set; }

    }
}
