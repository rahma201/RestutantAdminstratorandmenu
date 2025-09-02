using Pro2.Models;
using Pro2.View_Models;

namespace Pro2.Extensions
{
    public static class MasterItemMenuMappingExtension
    {
        public static MasterItemMenuViewModel ToViewModel(this MasterItemMenu model)
        {
            return new MasterItemMenuViewModel
            {
                Id = model.Id,
                MasterCategoryMenuId = model.MasterCategoryMenuId,
                MasterItemMenuTitle = model.MasterItemMenuTitle,
                MasterItemMenuBreef = model.MasterItemMenuBreef,
                MasterItemMenuDesc = model.MasterItemMenuDesc,
                MasterItemMenuPrice = model.MasterItemMenuPrice,
                MasterItemMenuImageUrl = model.MasterItemMenuImageUrl,
                MasterItemMenuDate = model.MasterItemMenuDate,
                MasterCategoryMenu = model.MasterCategoryMenu,
                IsActive = model.IsActive
            };
        }

        public static MasterItemMenu ToModel(this MasterItemMenuViewModel viewModel)
        {
            return new MasterItemMenu
            {
                Id = viewModel.Id,
                MasterCategoryMenuId = viewModel.MasterCategoryMenuId,
                MasterItemMenuTitle = viewModel.MasterItemMenuTitle,
                MasterItemMenuBreef = viewModel.MasterItemMenuBreef,
                MasterItemMenuDesc = viewModel.MasterItemMenuDesc,
                MasterItemMenuPrice = viewModel.MasterItemMenuPrice,
                MasterItemMenuImageUrl = viewModel.MasterItemMenuImageUrl,
                MasterItemMenuDate = viewModel.MasterItemMenuDate,
                MasterCategoryMenu = viewModel.MasterCategoryMenu,
                IsActive = viewModel.IsActive
            };
        }

        public static List<MasterItemMenuViewModel> ToViewModelList(this List<MasterItemMenu> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }

        public static List<MasterItemMenu> ToModelList(this List<MasterItemMenuViewModel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }
    }
}
