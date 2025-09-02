namespace Pro2.View_Models
{
    public class MasterContactUsInformationFullViewModel
    {
        public int Id { get; set; }

        public string? MasterContactUsInformationIdesc { get; set; }

        public string? MasterContactUsInformationImageUrl { get; set; }

        public string? MasterContactUsInformationRedirect { get; set; }
        public IFormFile? MasterContactUsInformationImageFile { get; set; }

        public bool IsActive { get; set; }
        public List<MasterContactUsInformationViewModel> MasterContactUsInformationlist { get; set; }

    }
}
