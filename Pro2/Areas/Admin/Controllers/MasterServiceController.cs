using Microsoft.AspNetCore.Mvc;
using Pro2.Models;
using Pro2.Repositories;
using Pro2.View_Models;
using Pro2.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Pro2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class MasterServiceController : Controller
    {
         IRepository<MasterService> Repository;

        public MasterServiceController(IRepository<MasterService> repository)
        {
            Repository = repository;
        }

        public IActionResult Index(int id = 0)
        {
            var serviceInfo = new MasterServiceViewModel();

            if (id != 0)
            {
                serviceInfo = Repository.Find(id).ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var vm = new MasterServiceFullViewModel
            {
                MasterServicelist = data,
                Id = serviceInfo.Id,
                MasterServicesTitle = serviceInfo.MasterServicesTitle,
                MasterServicesDesc = serviceInfo.MasterServicesDesc,
                IsActive = serviceInfo.IsActive
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MasterServiceFullViewModel model)
        {
            try
            {
                var vm = new MasterServiceViewModel
                {
                    Id = model.Id,
                    MasterServicesTitle = model.MasterServicesTitle,
                    MasterServicesDesc = model.MasterServicesDesc,
                    IsActive = model.IsActive
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
            catch
            {
                model.MasterServicelist = Repository.View().ToViewModelList();
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFullAction(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("Index", new { id = string.Empty });
        }

        private void Create(MasterServiceViewModel vm)
        {
            var entity = new MasterService
            {
                MasterServicesTitle = vm.MasterServicesTitle,
                MasterServicesDesc = vm.MasterServicesDesc,
                IsActive = vm.IsActive
            };

            Repository.Add(entity);
        }

        private void Edit(MasterServiceViewModel vm)
        {
            var entity = new MasterService
            {
                Id = vm.Id,
                MasterServicesTitle = vm.MasterServicesTitle,
                MasterServicesDesc = vm.MasterServicesDesc,
                IsActive = vm.IsActive
            };

            Repository.Update(entity);
        }
    }
}
