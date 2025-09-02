using Pro2.Models;
using Pro2.View_Models;

namespace Pro2.Extensions
{
    public static class MasterMenuMappingExtension
    {
        public static MasterMenuViewModel ToViewModel(this MasterMenu model)
        {
            return new MasterMenuViewModel
            {
                Id = model.Id,
                MasterMenuName = model.MasterMenuName,
                MasterMenuUrl = model.MasterMenuUrl,
                IsActive = model.IsActive
            };
        }

        public static MasterMenu ToModel(this MasterMenuViewModel viewModel)
        {
            return new MasterMenu
            {
                Id = viewModel.Id,
                MasterMenuName = viewModel.MasterMenuName,
                MasterMenuUrl = viewModel.MasterMenuUrl,
                IsActive = viewModel.IsActive
            };
        }

        public static List<MasterMenuViewModel> ToViewModelList(this List<MasterMenu> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }

        public static List<MasterMenu> ToModelList(this List<MasterMenuViewModel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }
    }
}
