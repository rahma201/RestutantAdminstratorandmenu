namespace Pro2.View_Models
{
    public class MasterServiceFullViewModel
    {

        public int Id { get; set; }

        public string? MasterServicesTitle { get; set; }

        public string? MasterServicesDesc { get; set; }

        public string? MasterServicesImag { get; set; }

        public bool IsActive { get; set; }
        public List<MasterServiceViewModel> MasterServicelist { get; set; }

    }
}
