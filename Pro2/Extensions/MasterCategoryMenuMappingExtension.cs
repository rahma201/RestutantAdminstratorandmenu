using Pro2.Models;
using Pro2.View_Models;

namespace Pro2.Extensions
{
    public static class MasterCategoryMenuMappingExtension
    {
        public static MasterCategoryMenuViewModel ToViewModel(this MasterCategoryMenu model)
        {
            return new MasterCategoryMenuViewModel
            {
                Id = model.Id,
                MasterCategoryMenuName = model.MasterCategoryMenuName,
                IsActive = model.IsActive,
                MasterItemMenus = model.MasterItemMenus
            };
        }

        public static MasterCategoryMenu ToModel(this MasterCategoryMenuViewModel viewModel)
        {
            return new MasterCategoryMenu
            {
                Id = viewModel.Id,
                MasterCategoryMenuName = viewModel.MasterCategoryMenuName,
                IsActive = viewModel.IsActive,
                MasterItemMenus = viewModel.MasterItemMenus
            };
        }

        public static List<MasterCategoryMenuViewModel> ToViewModelList(this List<MasterCategoryMenu> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }

        public static List<MasterCategoryMenu> ToModelList(this List<MasterCategoryMenuViewModel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }
    }
}
