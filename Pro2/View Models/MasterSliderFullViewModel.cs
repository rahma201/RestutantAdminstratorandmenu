namespace Pro2.View_Models
{
    public class MasterSliderFullViewModel
    {
        public int Id { get; set; }

        public string? MasterSliderTitle { get; set; }

        public string? MasterSliderBreef { get; set; }

        public string? MasterSliderDesc { get; set; }

        public string? MasterSliderUrl { get; set; }

        public bool IsActive { get; set; }

        public List<MasterSliderViewModel> MasterSliderlist { get; set; }

    }
}
