namespace Pro2.View_Models
{
    public class MasterContactUsInformationViewModel
    {

        public int Id { get; set; }

        public string? MasterContactUsInformationIdesc { get; set; }

        public string? MasterContactUsInformationImageUrl { get; set; }

        public string? MasterContactUsInformationRedirect { get; set; }
        public IFormFile? MasterContactUsInformationImageFile { get; set; }

        public bool IsActive { get; set; }

    }
}
