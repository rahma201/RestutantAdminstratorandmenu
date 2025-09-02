using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pro2.Extensions;
using Pro2.Helpers.File;
using Pro2.Models;
using Pro2.Repositories;
using Pro2.View_Models;

namespace Pro2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class MasterItemMenuController : Controller
    {
        IRepository<MasterItemMenu> Repository;
        IRepository<MasterCategoryMenu> CategoryRepository;
        IFileHelper FileHelper;

        public MasterItemMenuController(IRepository<MasterItemMenu> repository, IRepository<MasterCategoryMenu> categoryRepository, IFileHelper fileHelper)
        {
            Repository = repository;
            CategoryRepository = categoryRepository;
            FileHelper = fileHelper;
        }

        public IActionResult Index(int id = 0)
        {
            var itemInfo = new MasterItemMenuViewModel();

            if (id != 0)
            {
                itemInfo = Repository.Find(id).ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var vm = new MasterItemMenuFullViewModel
            {
                MasterItemMenulist = data,
                Id = itemInfo.Id,
                MasterItemMenuTitle = itemInfo.MasterItemMenuTitle,
                MasterItemMenuBreef = itemInfo.MasterItemMenuBreef,
                MasterItemMenuDesc = itemInfo.MasterItemMenuDesc,
                MasterItemMenuPrice = itemInfo.MasterItemMenuPrice,
                MasterItemMenuImageFile = null,
                MasterItemMenuImageUrl = itemInfo.MasterItemMenuImageUrl,
                MasterItemMenuDate = itemInfo.MasterItemMenuDate ?? DateTime.Now,
                MasterCategoryMenuId = itemInfo.MasterCategoryMenuId,
                IsActive = itemInfo.IsActive,
                MasterCategoryMenuList = new SelectList(CategoryRepository.View(), "Id", "MasterCategoryMenuName")
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MasterItemMenuFullViewModel model)
        {
            try
            {
                var vm = new MasterItemMenuViewModel
                {
                    Id = model.Id,
                    MasterItemMenuTitle = model.MasterItemMenuTitle,
                    MasterItemMenuBreef = model.MasterItemMenuBreef,
                    MasterItemMenuDesc = model.MasterItemMenuDesc,
                    MasterItemMenuPrice = model.MasterItemMenuPrice,
                    MasterItemMenuImageFile = model.MasterItemMenuImageFile,
                    MasterItemMenuImageUrl = model.MasterItemMenuImageUrl,
                    MasterItemMenuDate = model.MasterItemMenuDate,
                    MasterCategoryMenuId = model.MasterCategoryMenuId,
                    IsActive = model.IsActive
                };

                if (vm.Id == 0)
                {
                    var imageName = FileHelper.SaveImage(model.MasterItemMenuImageFile, "", "MasterItemImages");
                    if (imageName != "Error")
                    {
                        model.MasterItemMenuImageUrl = imageName;
                    }
                    else
                    {
                        model.MasterCategoryMenuList = new SelectList(CategoryRepository.View(), "Id", "MasterCategoryMenuName");
                        model.MasterItemMenulist = Repository.View().ToViewModelList();
                        ModelState.AddModelError("", "Error");
                        return View(model);
                    }
                    Create(vm);
                }
                else
                {
                    if (model.MasterItemMenuImageFile != null)
                    {
                        var imageName = FileHelper.SaveImage(model.MasterItemMenuImageFile, model.MasterItemMenuImageUrl, "MasterItemImages");
                        if (imageName != "Error")
                        {
                            model.MasterItemMenuImageUrl = imageName;
                            vm.MasterItemMenuImageUrl = imageName;
                        }
                        else
                        {
                            model.MasterCategoryMenuList = new SelectList(CategoryRepository.View(), "Id", "MasterCategoryMenuName");
                            model.MasterItemMenulist = Repository.View().ToViewModelList();
                            ModelState.AddModelError("", "خطأ في رفع الصورة.");
                            return View(model);
                        }
                    }
                    Edit(vm);
                }

                return RedirectToAction("Index", new { id = string.Empty });
            }
            catch
            {
                model.MasterCategoryMenuList = new SelectList(CategoryRepository.View(), "Id", "MasterCategoryMenuName");
                model.MasterItemMenulist = Repository.View().ToViewModelList();
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

        private void Create(MasterItemMenuViewModel vm)
        {
            var imageName = FileHelper.SaveImage(vm.MasterItemMenuImageFile, vm.MasterItemMenuImageUrl, "MasterItemImages");

            var obj = new MasterItemMenu
            {
                MasterItemMenuTitle = vm.MasterItemMenuTitle,
                MasterItemMenuBreef = vm.MasterItemMenuBreef,
                MasterItemMenuDesc = vm.MasterItemMenuDesc,
                MasterItemMenuPrice = vm.MasterItemMenuPrice,
                MasterItemMenuImageUrl = imageName,
                MasterItemMenuDate = vm.MasterItemMenuDate ?? DateTime.Now,
                MasterCategoryMenuId = vm.MasterCategoryMenuId,
                IsActive = vm.IsActive
            };

            Repository.Add(obj);
        }

        private void Edit(MasterItemMenuViewModel vm)
        {
            var imageName = FileHelper.SaveImage(vm.MasterItemMenuImageFile, vm.MasterItemMenuImageUrl, "MasterItemImages");

            var obj = new MasterItemMenu
            {
                Id = vm.Id,
                MasterItemMenuTitle = vm.MasterItemMenuTitle,
                MasterItemMenuBreef = vm.MasterItemMenuBreef,
                MasterItemMenuDesc = vm.MasterItemMenuDesc,
                MasterItemMenuPrice = vm.MasterItemMenuPrice,
                MasterItemMenuImageUrl = vm.MasterItemMenuImageUrl,
                MasterItemMenuDate = vm.MasterItemMenuDate ?? DateTime.Now,
                MasterCategoryMenuId = vm.MasterCategoryMenuId,
                IsActive = vm.IsActive
            };

            Repository.Update(obj);
        }
    }
}
