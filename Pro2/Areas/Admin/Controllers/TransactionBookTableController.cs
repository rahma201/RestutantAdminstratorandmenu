using Microsoft.AspNetCore.Mvc;
using Pro2.Extensions;
using Pro2.Models;
using Pro2.View_Models;
using Pro2.Repositories;

namespace Pro2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionBookTableController : Controller
    {
        private readonly IRepository<TransactionBookTable> Repository;

        public TransactionBookTableController(IRepository<TransactionBookTable> repository)
        {
            Repository = repository;
        }

        public IActionResult Index(int id = 0)
        {
            var transactionBookInfo = new TransactionBookTableViewModel();

            if (id != 0)
            {
                var model = Repository.Find(id);
                if (model != null)
                    transactionBookInfo = model.ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var viewModel = new TransactionBookTableFullViewModel
            {
                TransactionBookList = data,
                Id = transactionBookInfo.Id,
                IsActive = transactionBookInfo.IsActive,
                TransactionBookTableFullName = transactionBookInfo.TransactionBookTableFullName,
                TransactionBookTableEmail = transactionBookInfo.TransactionBookTableEmail,
                TransactionBookTableMobileNumber = transactionBookInfo.TransactionBookTableMobileNumber,
                TransactionBookTableDate = transactionBookInfo.TransactionBookTableDate
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TransactionBookTableFullViewModel model)
        {
            var vm = new TransactionBookTableViewModel
            {
                Id = model.Id,
                IsActive = model.IsActive,
                TransactionBookTableFullName = model.TransactionBookTableFullName,
                TransactionBookTableEmail = model.TransactionBookTableEmail,
                TransactionBookTableMobileNumber = model.TransactionBookTableMobileNumber,
                TransactionBookTableDate = model.TransactionBookTableDate
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

        private void Create(TransactionBookTableViewModel vm)
        {
            var obj = new TransactionBookTable
            {
                TransactionBookTableFullName = vm.TransactionBookTableFullName,
                TransactionBookTableEmail = vm.TransactionBookTableEmail,
                TransactionBookTableMobileNumber = vm.TransactionBookTableMobileNumber,
                TransactionBookTableDate = vm.TransactionBookTableDate,
                IsActive = vm.IsActive
            };
            Repository.Add(obj);
        }

        private void Edit(TransactionBookTableViewModel vm)
        {
            var obj = new TransactionBookTable
            {
                Id = vm.Id,
                TransactionBookTableFullName = vm.TransactionBookTableFullName,
                TransactionBookTableEmail = vm.TransactionBookTableEmail,
                TransactionBookTableMobileNumber = vm.TransactionBookTableMobileNumber,
                TransactionBookTableDate = vm.TransactionBookTableDate,
                IsActive = vm.IsActive
            };
            Repository.Update(obj);
        }
    }
}
