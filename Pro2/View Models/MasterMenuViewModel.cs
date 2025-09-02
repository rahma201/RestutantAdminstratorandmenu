namespace Pro2.View_Models
{
    public class MasterMenuViewModel
    {
        public int Id { get; set; }
        public string MasterMenuName { get; set; } = null!;

        public string MasterMenuUrl { get; set; } = null!;

        public bool IsActive { get; set; }

    }
}
