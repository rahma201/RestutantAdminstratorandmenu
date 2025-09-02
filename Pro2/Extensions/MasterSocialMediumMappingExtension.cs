using Pro2.Models;
using Pro2.View_Models;

namespace Pro2.Extensions
{
    public static class MasterSocialMediumMappingExtension
    {
        public static MasterSocialMediumViewModel ToViewModel(this MasterSocialMedium model)
        {
            return new MasterSocialMediumViewModel
            {
                Id = model.Id,
                MasterSocialMediaImageUrl = model.MasterSocialMediaImageUrl,
                MasterSocialMediaUrl = model.MasterSocialMediaUrl,
                IsActive = model.IsActive
            };
        }

        public static MasterSocialMedium ToModel(this MasterSocialMediumViewModel viewModel)
        {
            return new MasterSocialMedium
            {
                Id = viewModel.Id,
                MasterSocialMediaImageUrl = viewModel.MasterSocialMediaImageUrl,
                MasterSocialMediaUrl = viewModel.MasterSocialMediaUrl,
                IsActive = viewModel.IsActive
            };
        }

        public static List<MasterSocialMediumViewModel> ToViewModelList(this List<MasterSocialMedium> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }

        public static List<MasterSocialMedium> ToModelList(this List<MasterSocialMediumViewModel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }
    }
}
