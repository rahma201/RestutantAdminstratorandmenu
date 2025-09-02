using Pro2.Models;
using Pro2.View_Models;

namespace Pro2.Extensions
{
    public static class MasterOfferMappingExtension
    {
        public static MasterOfferViewMdel ToViewModel(this MasterOffer model)
        {
            return new MasterOfferViewMdel
            {
                Id = model.Id,
                MasterOfferTitle = model.MasterOfferTitle,
                MasterOfferBreef = model.MasterOfferBreef,
                MasterOfferDesc = model.MasterOfferDesc,
                MasterOfferImageUrl = model.MasterOfferImageUrl,
                IsActive = model.IsActive
            };
        }

        public static MasterOffer ToModel(this MasterOfferViewMdel viewModel)
        {
            return new MasterOffer
            {
                Id = viewModel.Id,
                MasterOfferTitle = viewModel.MasterOfferTitle,
                MasterOfferBreef = viewModel.MasterOfferBreef,
                MasterOfferDesc = viewModel.MasterOfferDesc,
                MasterOfferImageUrl = viewModel.MasterOfferImageUrl,
                IsActive = viewModel.IsActive
            };
        }

        public static List<MasterOfferViewMdel> ToViewModelList(this List<MasterOffer> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }

        public static List<MasterOffer> ToModelList(this List<MasterOfferViewMdel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }
    }
}
