using Pro2.Models;

namespace Pro2.View_Models
{
    public class TransactionNewsletterFullViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string? TransactionNewsletterEmail { get; set; }
        public List<TransactionNewsletterViewModel> TransactionNewsletterList { get; set; }


    }
}
