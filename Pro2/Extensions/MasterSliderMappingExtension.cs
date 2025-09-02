using Pro2.Models;
using Pro2.View_Models;

namespace Pro2.Extensions
{
    public static class MasterSliderMappingExtension
    {
        public static MasterSliderViewModel ToViewModel(this MasterSlider model)
        {
            return new MasterSliderViewModel
            {
                Id = model.Id,
                MasterSliderTitle = model.MasterSliderTitle,
                MasterSliderBreef = model.MasterSliderBreef,
                MasterSliderDesc = model.MasterSliderDesc,
                MasterSliderUrl = model.MasterSliderUrl,
                IsActive = model.IsActive
            };
        }

        public static MasterSlider ToModel(this MasterSliderViewModel viewModel)
        {
            return new MasterSlider
            {
                Id = viewModel.Id,
                MasterSliderTitle = viewModel.MasterSliderTitle,
                MasterSliderBreef = viewModel.MasterSliderBreef,
                MasterSliderDesc = viewModel.MasterSliderDesc,
                MasterSliderUrl = viewModel.MasterSliderUrl,
                IsActive = viewModel.IsActive
            };
        }

        public static List<MasterSliderViewModel> ToViewModelList(this List<MasterSlider> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }

        public static List<MasterSlider> ToModelList(this List<MasterSliderViewModel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }
    }
}
