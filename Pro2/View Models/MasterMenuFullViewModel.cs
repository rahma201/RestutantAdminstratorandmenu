namespace Pro2.View_Models
{
    public class MasterMenuFullViewModel
    {
        public int Id { get; set; }
        public string MasterMenuName { get; set; } = null!;

        public string MasterMenuUrl { get; set; } = null!;

        public bool IsActive { get; set; }

        public List<MasterMenuViewModel> MasterMenulist { get; set; }

    }
}

