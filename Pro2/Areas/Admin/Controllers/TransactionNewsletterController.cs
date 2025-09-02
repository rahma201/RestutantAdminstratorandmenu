using Microsoft.AspNetCore.Mvc;
using Pro2.Extensions;
using Pro2.Models;
using Pro2.View_Models;
using Pro2.Repositories;

namespace Pro2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionNewsletterController : Controller
    {
        private readonly IRepository<TransactionNewsletter> Repository;

        public TransactionNewsletterController(IRepository<TransactionNewsletter> repository)
        {
            Repository = repository;
        }

        public IActionResult Index(int id = 0)
        {
            var newsletterInfo = new TransactionNewsletterViewModel();

            if (id != 0)
            {
                var model = Repository.Find(id);
                if (model != null)
                    newsletterInfo = model.ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var viewModel = new TransactionNewsletterFullViewModel
            {
                TransactionNewsletterList = data,
                Id = newsletterInfo.Id,
                IsActive = newsletterInfo.IsActive,
                TransactionNewsletterEmail = newsletterInfo.TransactionNewsletterEmail
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TransactionNewsletterFullViewModel model)
        {
            var vm = new TransactionNewsletterViewModel
            {
                Id = model.Id,
                IsActive = model.IsActive,
                TransactionNewsletterEmail = model.TransactionNewsletterEmail
            };

            if (vm.Id == 0)
            {
                Create(vm);
            }
            else
            {
                Edit(vm);
            }

            return RedirectToAction("Index", new { id = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFullAction(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("Index", new { id = string.Empty });
        }

        private void Create(TransactionNewsletterViewModel vm)
        {
            var obj = new TransactionNewsletter
            {
                TransactionNewsletterEmail = vm.TransactionNewsletterEmail,
                IsActive = vm.IsActive
            };
            Repository.Add(obj);
        }

        private void Edit(TransactionNewsletterViewModel vm)
        {
            var obj = new TransactionNewsletter
            {
                Id = vm.Id,
                TransactionNewsletterEmail = vm.TransactionNewsletterEmail,
                IsActive = vm.IsActive
            };
            Repository.Update(obj);
        }
    }
}
