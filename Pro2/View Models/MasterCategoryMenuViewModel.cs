using Pro2.Models;

namespace Pro2.View_Models
{
    public class MasterCategoryMenuViewModel
    {
        public int Id { get; set; }

        public string? MasterCategoryMenuName { get; set; }

        public virtual ICollection<MasterItemMenu> MasterItemMenus { get; set; } = new List<MasterItemMenu>();
        public bool IsActive { get; set; }

    }
}
