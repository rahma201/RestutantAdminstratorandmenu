using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pro2.Models;
using Pro2.Repositories;
using Pro2.View_Models;
using Pro2.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Pro2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterCategoryMenuController : Controller
    {
        IRepository<MasterCategoryMenu> Repository;

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> repository)
        {
            Repository = repository;
        }

        public IActionResult Index(int id )
        {
            var MasterCategoryInfo = new MasterCategoryMenuViewModel();

            if (id != 0)
            {
                MasterCategoryInfo = Repository.Find(id).ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var obj = new MasterCategoryMenuFullViewModel
            {
                MasterCategoryMenulist = data,
                Id = MasterCategoryInfo.Id,
                MasterCategoryMenuName = MasterCategoryInfo.MasterCategoryMenuName,
                MasterItemMenus = MasterCategoryInfo.MasterItemMenus,
                IsActive = MasterCategoryInfo.IsActive
            };

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MasterCategoryMenuFullViewModel model)
        {
            var vm = new MasterCategoryMenuViewModel
            {
                Id = model.Id,
                MasterCategoryMenuName = model.MasterCategoryMenuName,
                MasterItemMenus = model.MasterItemMenus,
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFullAction(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("Index", new { id = string.Empty });
        }

        private void Create(MasterCategoryMenuViewModel vm)
        {
            var obj = new MasterCategoryMenu
            {
                MasterCategoryMenuName = vm.MasterCategoryMenuName,
                IsActive = vm.IsActive,
                MasterItemMenus = vm.MasterItemMenus
            };

            Repository.Add(obj);
        }

        private void Edit(MasterCategoryMenuViewModel vm)
        {
            var obj = new MasterCategoryMenu
            {
                Id = vm.Id,
                MasterCategoryMenuName = vm.MasterCategoryMenuName,
                IsActive = vm.IsActive,
                MasterItemMenus = vm.MasterItemMenus
            };

            Repository.Update(obj);
        }
    }
}