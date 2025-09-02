using Pro2.Models;
using Pro2.View_Models;

namespace Pro2.Extensions
{
    public static class MasterPartnerMappingExtension
    {
        public static MasterPartnerViewModel ToViewModel(this MasterPartner model)
        {
            return new MasterPartnerViewModel
            {
                Id = model.Id,
                MasterPartnerName = model.MasterPartnerName,
                MasterPartnerLogoImageUrl = model.MasterPartnerLogoImageUrl,
                MasterPartnerWebsiteUrl = model.MasterPartnerWebsiteUrl,
                IsActive = model.IsActive
            };
        }

        public static MasterPartner ToModel(this MasterPartnerViewModel viewModel)
        {
            return new MasterPartner
            {
                Id = viewModel.Id,
                MasterPartnerName = viewModel.MasterPartnerName,
                MasterPartnerLogoImageUrl = viewModel.MasterPartnerLogoImageUrl,
                MasterPartnerWebsiteUrl = viewModel.MasterPartnerWebsiteUrl,
                IsActive = viewModel.IsActive
            };
        }

        public static List<MasterPartnerViewModel> ToViewModelList(this List<MasterPartner> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }

        public static List<MasterPartner> ToModelList(this List<MasterPartnerViewModel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }
    }
}
