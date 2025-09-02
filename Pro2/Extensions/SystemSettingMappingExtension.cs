using Pro2.Models;
using Pro2.View_Models;

namespace Pro2.Extensions
{
    public static class SystemSettingMappingExtension
    {
        public static SystemSettingViewModel ToViewModel(this SystemSetting model)
        {
            return new SystemSettingViewModel
            {
                Id = model.Id,
                IsActive = model.IsActive,
                SystemSettingLogoImageUrl = model.SystemSettingLogoImageUrl,
                SystemSettingCopyright = model.SystemSettingCopyright,
                SystemSettingWelcomeNoteTitle = model.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteBreef = model.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = model.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteUrl = model.SystemSettingWelcomeNoteUrl,
                SystemSettingLogoImageUrl2 = model.SystemSettingLogoImageUrl2,
                SystemSettingWelcomeNoteImageUrl = model.SystemSettingWelcomeNoteImageUrl
            };
        }

        public static SystemSetting ToModel(this SystemSettingViewModel viewModel)
        {
            return new SystemSetting
            {
                Id = viewModel.Id,
                IsActive = viewModel.IsActive,
                SystemSettingLogoImageUrl = viewModel.SystemSettingLogoImageUrl,
                SystemSettingCopyright = viewModel.SystemSettingCopyright,
                SystemSettingWelcomeNoteTitle = viewModel.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteBreef = viewModel.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = viewModel.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteUrl = viewModel.SystemSettingWelcomeNoteUrl,
                SystemSettingLogoImageUrl2 = viewModel.SystemSettingLogoImageUrl2,
                SystemSettingWelcomeNoteImageUrl = viewModel.SystemSettingWelcomeNoteImageUrl
            };
        }

        public static List<SystemSettingViewModel> ToViewModelList(this List<SystemSetting> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }

        public static List<SystemSetting> ToModelList(this List<SystemSettingViewModel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }
    }
}
