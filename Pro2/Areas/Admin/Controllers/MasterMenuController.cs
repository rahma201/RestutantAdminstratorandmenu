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

    public class MasterMenuController : Controller
    {
        private readonly IRepository<MasterMenu> Repository;

        public MasterMenuController(IRepository<MasterMenu> repository)
        {
            Repository = repository;
        }

        public IActionResult Index(int id = 0)
        {
            var menuInfo = new MasterMenuViewModel();

            if (id != 0)
            {
                menuInfo = Repository.Find(id).ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var vm = new MasterMenuFullViewModel
            {
                MasterMenulist = data,
                Id = menuInfo.Id,
                MasterMenuName = menuInfo.MasterMenuName,
                MasterMenuUrl = menuInfo.MasterMenuUrl,
                IsActive = menuInfo.IsActive
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MasterMenuFullViewModel model)
        {
            try
            {
                var vm = new MasterMenuViewModel
                {
                    Id = model.Id,
                    MasterMenuName = model.MasterMenuName,
                    MasterMenuUrl = model.MasterMenuUrl,
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
                model.MasterMenulist = Repository.View().ToViewModelList();
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

        private void Create(MasterMenuViewModel vm)
        {
            var entity = new MasterMenu
            {
                MasterMenuName = vm.MasterMenuName,
                MasterMenuUrl = vm.MasterMenuUrl,
                IsActive = vm.IsActive
            };

            Repository.Add(entity);
        }

        private void Edit(MasterMenuViewModel vm)
        {
            var entity = new MasterMenu
            {
                Id = vm.Id,
                MasterMenuName = vm.MasterMenuName,
                MasterMenuUrl = vm.MasterMenuUrl,
                IsActive = vm.IsActive
            };

            Repository.Update(entity);
        }
    }
}
