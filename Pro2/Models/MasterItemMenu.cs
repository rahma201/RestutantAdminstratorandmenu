

namespace Pro2.Models;

public partial class MasterItemMenu : BaseEntity
{

    public int? MasterCategoryMenuId { get; set; }

    public string? MasterItemMenuTitle { get; set; }

    public string? MasterItemMenuBreef { get; set; }

    public string? MasterItemMenuDesc { get; set; }

    public decimal? MasterItemMenuPrice { get; set; }

    public string? MasterItemMenuImageUrl { get; set; }

    public DateTime? MasterItemMenuDate { get; set; }

    public virtual MasterCategoryMenu? MasterCategoryMenu { get; set; }
}
