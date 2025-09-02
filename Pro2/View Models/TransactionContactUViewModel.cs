

namespace Pro2.Models;

public partial class TransactionContactUViewModel 
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public string? TransactionContactUsFullName { get; set; }

    public string? TransactionContactUsEmail { get; set; }

    public string? TransactionContactUsSubject { get; set; }

    public string? TransactionContactUsMessage { get; set; }
}
