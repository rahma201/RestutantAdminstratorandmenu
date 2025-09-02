using Microsoft.AspNetCore.Mvc;
using Pro2.Extensions;
using Pro2.Models;
using Pro2.View_Models;
using Pro2.Repositories;

namespace Pro2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionContactUController : Controller
    {
        private readonly IRepository<TransactionContactU> Repository;

        public TransactionContactUController(IRepository<TransactionContactU> repository)
        {
            Repository = repository;
        }

        public IActionResult Index(int id = 0)
        {
            var contactInfo = new TransactionContactUViewModel();

            if (id != 0)
            {
                var model = Repository.Find(id);
                if (model != null)
                    contactInfo = model.ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var viewModel = new TransactionContactUFullViewModel
            {
                TransactionContactUList = data,
                Id = contactInfo.Id,
                IsActive = contactInfo.IsActive,
                TransactionContactUsFullName = contactInfo.TransactionContactUsFullName,
                TransactionContactUsEmail = contactInfo.TransactionContactUsEmail,
                TransactionContactUsSubject = contactInfo.TransactionContactUsSubject,
                TransactionContactUsMessage = contactInfo.TransactionContactUsMessage
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TransactionContactUFullViewModel model)
        {
            var vm = new TransactionContactUViewModel
            {
                Id = model.Id,
                IsActive = model.IsActive,
                TransactionContactUsFullName = model.TransactionContactUsFullName,
                TransactionContactUsEmail = model.TransactionContactUsEmail,
                TransactionContactUsSubject = model.TransactionContactUsSubject,
                TransactionContactUsMessage = model.TransactionContactUsMessage
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

        private void Create(TransactionContactUViewModel vm)
        {
            var obj = new TransactionContactU
            {
                TransactionContactUsFullName = vm.TransactionContactUsFullName,
                TransactionContactUsEmail = vm.TransactionContactUsEmail,
                TransactionContactUsSubject = vm.TransactionContactUsSubject,
                TransactionContactUsMessage = vm.TransactionContactUsMessage,
                IsActive = vm.IsActive
            };
            Repository.Add(obj);
        }

        private void Edit(TransactionContactUViewModel vm)
        {
            var obj = new TransactionContactU
            {
                Id = vm.Id,
                TransactionContactUsFullName = vm.TransactionContactUsFullName,
                TransactionContactUsEmail = vm.TransactionContactUsEmail,
                TransactionContactUsSubject = vm.TransactionContactUsSubject,
                TransactionContactUsMessage = vm.TransactionContactUsMessage,
                IsActive = vm.IsActive
            };
            Repository.Update(obj);
        }
    }
}
