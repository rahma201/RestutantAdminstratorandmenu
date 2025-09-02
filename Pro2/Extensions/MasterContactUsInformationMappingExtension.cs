using Pro2.Models;
using Pro2.View_Models;

namespace Pro2.Extensions
{
    public static class MasterContactUsInformationMappingExtension
    {
        public static MasterContactUsInformationViewModel ToViewModel(this MasterContactUsInformation model)
        {
            return new MasterContactUsInformationViewModel
            {
                Id = model.Id,
                MasterContactUsInformationIdesc = model.MasterContactUsInformationIdesc,
                MasterContactUsInformationImageUrl = model.MasterContactUsInformationImageUrl,
                MasterContactUsInformationRedirect = model.MasterContactUsInformationRedirect,
                IsActive = model.IsActive
            };
        }

        public static MasterContactUsInformation ToModel(this MasterContactUsInformationViewModel viewModel)
        {
            return new MasterContactUsInformation
            {
                Id = viewModel.Id,
                MasterContactUsInformationIdesc = viewModel.MasterContactUsInformationIdesc,
                MasterContactUsInformationImageUrl = viewModel.MasterContactUsInformationImageUrl,
                MasterContactUsInformationRedirect = viewModel.MasterContactUsInformationRedirect,
                IsActive = viewModel.IsActive
            };
        }

        public static List<MasterContactUsInformationViewModel> ToViewModelList(this List<MasterContactUsInformation> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }

        public static List<MasterContactUsInformation> ToModelList(this List<MasterContactUsInformationViewModel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }
    }
}
