using Pro2.Models;
using Pro2.View_Models;

namespace Pro2.Extensions
{
    public static class MasterServiceMappingExtension
    {
        public static MasterServiceViewModel ToViewModel(this MasterService model)
        {
            return new MasterServiceViewModel
            {
                Id = model.Id,
                MasterServicesTitle = model.MasterServicesTitle,
                MasterServicesDesc = model.MasterServicesDesc,
                MasterServicesImag = model.MasterServicesImag,
                IsActive = model.IsActive
            };
        }

        public static MasterService ToModel(this MasterServiceViewModel viewModel)
        {
            return new MasterService
            {
                Id = viewModel.Id,
                MasterServicesTitle = viewModel.MasterServicesTitle,
                MasterServicesDesc = viewModel.MasterServicesDesc,
                MasterServicesImag = viewModel.MasterServicesImag,
                IsActive = viewModel.IsActive
            };
        }

        public static List<MasterServiceViewModel> ToViewModelList(this List<MasterService> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }

        public static List<MasterService> ToModelList(this List<MasterServiceViewModel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }
    }
}
