using Pro2.Models;

namespace Pro2.View_Models
{
    public class MasterCategoryMenuFullViewModel
    {
        public int Id { get; set; }

        public string? MasterCategoryMenuName { get; set; }

        public virtual ICollection<MasterItemMenu> MasterItemMenus { get; set; } = new List<MasterItemMenu>();
        public bool IsActive { get; set; }
        public List<MasterCategoryMenuViewModel> MasterCategoryMenulist { get; set; }

    }
}
