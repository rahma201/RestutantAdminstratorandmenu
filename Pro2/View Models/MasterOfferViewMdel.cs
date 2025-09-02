namespace Pro2.View_Models
{
    public class MasterOfferViewMdel
    {
        public int Id { get; set; }

        public string? MasterOfferTitle { get; set; }

        public string? MasterOfferBreef { get; set; }

        public string? MasterOfferDesc { get; set; }

        public string? MasterOfferImageUrl { get; set; }
        public IFormFile? MasterOfferImageFile { get; set; }

        public bool IsActive { get; set; }

    }
}
