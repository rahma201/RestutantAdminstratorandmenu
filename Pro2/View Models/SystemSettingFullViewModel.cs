namespace Pro2.View_Models
{
    public class SystemSettingFullViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string? SystemSettingLogoImageUrl { get; set; }
        public IFormFile? SystemSettingLogoImageFile { get; set; }

        public string? SystemSettingCopyright { get; set; }

        public string? SystemSettingWelcomeNoteTitle { get; set; }

        public string? SystemSettingWelcomeNoteBreef { get; set; }

        public string? SystemSettingWelcomeNoteDesc { get; set; }

        public string? SystemSettingWelcomeNoteUrl { get; set; }


        public string? SystemSettingLogoImageUrl2 { get; set; }
        public IFormFile? SystemSettingLogoImageFile2 { get; set; }

        public string? SystemSettingWelcomeNoteImageUrl { get; set; }
        public IFormFile? SystemSettingWelcomeNoteImageFile { get; set; }

        public List<SystemSettingViewModel> SystemSettinglist { get; set; }

    }
}
