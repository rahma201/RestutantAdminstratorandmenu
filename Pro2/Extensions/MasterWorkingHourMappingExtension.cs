using Pro2.Models;
using Pro2.View_Models;

namespace Pro2.Extensions
{
    public static class MasterWorkingHourMappingExtension
    {
        public static MasterWorkingHourViewMdel ToViewModel(this MasterWorkingHour model)
        {
            return new MasterWorkingHourViewMdel
            {
                Id = model.Id,
                MasterWorkingHoursIdName = model.MasterWorkingHoursIdName,
                MasterWorkingHoursIdTimeFormTo = model.MasterWorkingHoursIdTimeFormTo,
                IsActive = model.IsActive
            };
        }

        public static MasterWorkingHour ToModel(this MasterWorkingHourViewMdel viewModel)
        {
            return new MasterWorkingHour
            {
                Id = viewModel.Id,
                MasterWorkingHoursIdName = viewModel.MasterWorkingHoursIdName,
                MasterWorkingHoursIdTimeFormTo = viewModel.MasterWorkingHoursIdTimeFormTo,
                IsActive = viewModel.IsActive
            };
        }

        public static List<MasterWorkingHourViewMdel> ToViewModelList(this List<MasterWorkingHour> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }

        public static List<MasterWorkingHour> ToModelList(this List<MasterWorkingHourViewMdel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }
    }
}
