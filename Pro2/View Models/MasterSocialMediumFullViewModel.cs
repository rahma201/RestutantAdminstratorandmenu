namespace Pro2.View_Models
{
    public class MasterSocialMediumFullViewModel
    {
        public int Id { get; set; }

        public string MasterSocialMediaImageUrl { get; set; } = null!;

        public string MasterSocialMediaUrl { get; set; } = null!;
        public bool IsActive { get; set; }
        public List<MasterSocialMediumViewModel> MasterSociallist { get; set; }

    }
}
