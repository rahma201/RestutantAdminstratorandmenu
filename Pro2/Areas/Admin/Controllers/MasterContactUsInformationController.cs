using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pro2.Extensions;
using Pro2.Helpers.File;
using Pro2.Models;
using Pro2.Repositories;
using Pro2.View_Models;

namespace Pro2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class MasterContactUsInformationController : Controller
    {
        IRepository<MasterContactUsInformation> Repository;
        IFileHelper FileHelper;

        public MasterContactUsInformationController(
            IRepository<MasterContactUsInformation> repository,
            IFileHelper fileHelper)
        {
            Repository = repository;
            FileHelper = fileHelper;
        }

        public IActionResult Index(int id = 0)
        {
            var info = new MasterContactUsInformationViewModel();

            if (id != 0)
            {
                info = Repository.Find(id).ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var vm = new MasterContactUsInformationFullViewModel
            {
                Id = info.Id,
                MasterContactUsInformationIdesc = info.MasterContactUsInformationIdesc,
                MasterContactUsInformationImageFile = null,
                MasterContactUsInformationImageUrl = info.MasterContactUsInformationImageUrl,
                MasterContactUsInformationRedirect = info.MasterContactUsInformationRedirect,
                IsActive = info.IsActive,
                MasterContactUsInformationlist = data
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MasterContactUsInformationFullViewModel model)
        {
            try
            {
                var vm = new MasterContactUsInformationViewModel
                {
                    Id = model.Id,
                    MasterContactUsInformationIdesc = model.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = model.MasterContactUsInformationRedirect,
                    MasterContactUsInformationImageFile = model.MasterContactUsInformationImageFile,
                    MasterContactUsInformationImageUrl = model.MasterContactUsInformationImageUrl,
                    IsActive = model.IsActive
                };

                if (vm.Id == 0)
                {
                    var imageName = FileHelper.SaveImage(model.MasterContactUsInformationImageFile, "", "MasterContactImages");
                    if (imageName != "Error")
                    {
                        vm.MasterContactUsInformationImageUrl = imageName;
                    }
                    else
                    {
                        model.MasterContactUsInformationlist = Repository.View().ToViewModelList();
                        ModelState.AddModelError("", "حدث خطأ أثناء رفع الصورة.");
                        return View(model);
                    }

                    Create(vm);
                }
                else
                {
                    if (model.MasterContactUsInformationImageFile != null)
                    {
                        var imageName = FileHelper.SaveImage(model.MasterContactUsInformationImageFile, model.MasterContactUsInformationImageUrl, "MasterContactImages");
                        if (imageName != "Error")
                        {
                            vm.MasterContactUsInformationImageUrl = imageName;
                        }
                        else
                        {
                            model.MasterContactUsInformationlist = Repository.View().ToViewModelList();
                            ModelState.AddModelError("", "حدث خطأ أثناء تعديل الصورة.");
                            return View(model);
                        }
                    }

                    Edit(vm);
                }

                return RedirectToAction("Index", new { id = string.Empty });
            }
            catch
            {
                model.MasterContactUsInformationlist = Repository.View().ToViewModelList();
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

        private void Create(MasterContactUsInformationViewModel vm)
        {
            var imageName = FileHelper.SaveImage(vm.MasterContactUsInformationImageFile, vm.MasterContactUsInformationImageUrl, "MasterContactImages");

            var entity = new MasterContactUsInformation
            {
                MasterContactUsInformationIdesc = vm.MasterContactUsInformationIdesc,
                MasterContactUsInformationRedirect = vm.MasterContactUsInformationRedirect,
                MasterContactUsInformationImageUrl = imageName,
                IsActive = vm.IsActive
            };

            Repository.Add(entity);
        }

        private void Edit(MasterContactUsInformationViewModel vm)
        {
            var imageName = FileHelper.SaveImage(vm.MasterContactUsInformationImageFile, vm.MasterContactUsInformationImageUrl, "MasterContactImages");

            var entity = new MasterContactUsInformation
            {
                Id = vm.Id,
                MasterContactUsInformationIdesc = vm.MasterContactUsInformationIdesc,
                MasterContactUsInformationRedirect = vm.MasterContactUsInformationRedirect,
                MasterContactUsInformationImageUrl = imageName,
                IsActive = vm.IsActive
            };

            Repository.Update(entity);
        }
    }
}
