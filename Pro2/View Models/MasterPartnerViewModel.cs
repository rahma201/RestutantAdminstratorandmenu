namespace Pro2.View_Models
{
    public class MasterPartnerViewModel
    {
        public int Id { get; set; }

        public string? MasterPartnerName { get; set; }

        public string? MasterPartnerLogoImageUrl { get; set; }
        public IFormFile? MasterPartnerLogoImageFile { get; set; }

        public string? MasterPartnerWebsiteUrl { get; set; }

        public bool IsActive { get; set; }

    }
}
