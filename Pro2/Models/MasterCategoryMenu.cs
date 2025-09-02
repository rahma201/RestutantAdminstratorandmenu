

namespace Pro2.Models;

public partial class MasterCategoryMenu : BaseEntity
{

    public string? MasterCategoryMenuName { get; set; }

    public virtual ICollection<MasterItemMenu> MasterItemMenus { get; set; } = new List<MasterItemMenu>();
}
