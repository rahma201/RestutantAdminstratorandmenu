using Pro2.Models;
using Pro2.View_Models;

namespace Pro2.Extensions
{
    public static class TransactionBookTableMappingExtension
    {
        public static TransactionBookTableViewModel ToViewModel(this TransactionBookTable model)
        {
            return new TransactionBookTableViewModel
            {
                Id = model.Id,
                IsActive = model.IsActive,
                TransactionBookTableFullName = model.TransactionBookTableFullName,
                TransactionBookTableEmail = model.TransactionBookTableEmail,
                TransactionBookTableMobileNumber = model.TransactionBookTableMobileNumber,
                TransactionBookTableDate = model.TransactionBookTableDate
            };
        }

        public static TransactionBookTable ToModel(this TransactionBookTableViewModel viewModel)
        {
            return new TransactionBookTable
            {
                Id = viewModel.Id,
                IsActive = viewModel.IsActive,
                TransactionBookTableFullName = viewModel.TransactionBookTableFullName,
                TransactionBookTableEmail = viewModel.TransactionBookTableEmail,
                TransactionBookTableMobileNumber = viewModel.TransactionBookTableMobileNumber,
                TransactionBookTableDate = viewModel.TransactionBookTableDate
            };
        }

        public static List<TransactionBookTable> ToModelList(this List<TransactionBookTableViewModel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }

        public static List<TransactionBookTableViewModel> ToViewModelList(this List<TransactionBookTable> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }
    }
}
