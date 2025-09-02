using Pro2.Models;

namespace Pro2.Extensions
{
    public static class TransactionContactUsMappingExtension
    {
        public static TransactionContactUViewModel ToViewModel(this TransactionContactU model)
        {
            return new TransactionContactUViewModel
            {
                Id = model.Id,
                IsActive = model.IsActive,
                TransactionContactUsFullName = model.TransactionContactUsFullName,
                TransactionContactUsEmail = model.TransactionContactUsEmail,
                TransactionContactUsSubject = model.TransactionContactUsSubject,
                TransactionContactUsMessage = model.TransactionContactUsMessage
            };
        }

        public static TransactionContactU ToModel(this TransactionContactUViewModel viewModel)
        {
            return new TransactionContactU
            {
                Id = viewModel.Id,
                IsActive = viewModel.IsActive,
                TransactionContactUsFullName = viewModel.TransactionContactUsFullName,
                TransactionContactUsEmail = viewModel.TransactionContactUsEmail,
                TransactionContactUsSubject = viewModel.TransactionContactUsSubject,
                TransactionContactUsMessage = viewModel.TransactionContactUsMessage
            };
        }

        public static List<TransactionContactU> ToModelList(this List<TransactionContactUViewModel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }

        public static List<TransactionContactUViewModel> ToViewModelList(this List<TransactionContactU> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }
    }
}
