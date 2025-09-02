using Pro2.Models;

namespace Pro2.Extensions
{
    public static class TransactionNewsletterMappingExtension
    {
        public static TransactionNewsletterViewModel ToViewModel(this TransactionNewsletter model)
        {
            return new TransactionNewsletterViewModel
            {
                Id = model.Id,
                IsActive = model.IsActive,
                TransactionNewsletterEmail = model.TransactionNewsletterEmail
            };
        }

        public static TransactionNewsletter ToModel(this TransactionNewsletterViewModel viewModel)
        {
            return new TransactionNewsletter
            {
                Id = viewModel.Id,
                IsActive = viewModel.IsActive,
                TransactionNewsletterEmail = viewModel.TransactionNewsletterEmail
            };
        }

        public static List<TransactionNewsletter> ToModelList(this List<TransactionNewsletterViewModel> viewModels)
        {
            return viewModels.Select(x => x.ToModel()).ToList();
        }

        public static List<TransactionNewsletterViewModel> ToViewModelList(this List<TransactionNewsletter> models)
        {
            return models.Select(x => x.ToViewModel()).ToList();
        }
    }
}
