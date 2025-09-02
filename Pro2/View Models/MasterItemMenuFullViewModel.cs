using Microsoft.AspNetCore.Mvc.Rendering;
using Pro2.Models;

namespace Pro2.View_Models
{
    public class MasterItemMenuFullViewModel
    {

        public int Id { get; set; }

        public int? MasterCategoryMenuId { get; set; }

        public string? MasterItemMenuTitle { get; set; }

        public string? MasterItemMenuBreef { get; set; }

        public string? MasterItemMenuDesc { get; set; }

        public decimal? MasterItemMenuPrice { get; set; }

        public string? MasterItemMenuImageUrl { get; set; }
        public IFormFile? MasterItemMenuImageFile { get; set; }


        public DateTime? MasterItemMenuDate { get; set; }

        public virtual MasterCategoryMenu? MasterCategoryMenu { get; set; }

        public bool IsActive { get; set; }
        public SelectList MasterCategoryMenuList { get; set; }

        public List<MasterItemMenuViewModel> MasterItemMenulist { get; set; }

    }
}
