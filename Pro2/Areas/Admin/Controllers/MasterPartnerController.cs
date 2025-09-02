using Microsoft.AspNetCore.Mvc;
using Pro2.Models;
using Pro2.Repositories;
using Pro2.Helpers.File;
using Pro2.View_Models;
using Pro2.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Pro2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class MasterPartnerController : Controller
    {
        IRepository<MasterPartner> Repository;
        IFileHelper FileHelper;

        public MasterPartnerController(IRepository<MasterPartner> repository, IFileHelper fileHelper)
        {
            Repository = repository;
            FileHelper = fileHelper;
        }

        public IActionResult Index(int id = 0)
        {
            var partnerInfo = new MasterPartnerViewModel();

            if (id != 0)
            {
                partnerInfo = Repository.Find(id).ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var vm = new MasterPartnerFullViewModel
            {
                MasterPartnerlist = data,
                Id = partnerInfo.Id,
                MasterPartnerName = partnerInfo.MasterPartnerName,
                MasterPartnerLogoImageUrl = partnerInfo.MasterPartnerLogoImageUrl,
                MasterPartnerWebsiteUrl = partnerInfo.MasterPartnerWebsiteUrl,
                IsActive = partnerInfo.IsActive
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MasterPartnerFullViewModel model)
        {
            try
            {
                var vm = new MasterPartnerViewModel
                {
                    Id = model.Id,
                    MasterPartnerName = model.MasterPartnerName,
                    MasterPartnerLogoImageFile = model.MasterPartnerLogoImageFile,
                    MasterPartnerLogoImageUrl = model.MasterPartnerLogoImageUrl,
                    MasterPartnerWebsiteUrl = model.MasterPartnerWebsiteUrl,
                    IsActive = model.IsActive
                };

                if (vm.Id == 0)
                {
                    var imageName = FileHelper.SaveImage(model.MasterPartnerLogoImageFile, "", "MasterPartnerImages");
                    if (imageName != "Error")
                    {
                        model.MasterPartnerLogoImageUrl = imageName;
                        vm.MasterPartnerLogoImageUrl = imageName;
                    }
                    else
                    {
                        model.MasterPartnerlist = Repository.View().ToViewModelList();
                        ModelState.AddModelError("", "خطأ أثناء رفع الصورة.");
                        return View(model);
                    }

                    Create(vm);
                }
                else
                {
                    if (model.MasterPartnerLogoImageFile != null)
                    {
                        var imageName = FileHelper.SaveImage(model.MasterPartnerLogoImageFile, model.MasterPartnerLogoImageUrl, "MasterPartnerImages");
                        if (imageName != "Error")
                        {
                            model.MasterPartnerLogoImageUrl = imageName;
                            vm.MasterPartnerLogoImageUrl = imageName;
                        }
                        else
                        {
                            model.MasterPartnerlist = Repository.View().ToViewModelList();
                            ModelState.AddModelError("", "خطأ أثناء تحديث الصورة.");
                            return View(model);
                        }
                    }

                    Edit(vm);
                }

                return RedirectToAction("Index", new { id = string.Empty });
            }
            catch
            {
                model.MasterPartnerlist = Repository.View().ToViewModelList();
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

        private void Create(MasterPartnerViewModel vm)
        {
            var imageName = FileHelper.SaveImage(vm.MasterPartnerLogoImageFile, vm.MasterPartnerLogoImageUrl, "MasterPartnerImages");

            var entity = new MasterPartner
            {
                MasterPartnerName = vm.MasterPartnerName,
                MasterPartnerLogoImageUrl = imageName,
                MasterPartnerWebsiteUrl = vm.MasterPartnerWebsiteUrl,
                IsActive = vm.IsActive
            };

            Repository.Add(entity);
        }

        private void Edit(MasterPartnerViewModel vm)
        {
            var imageName = FileHelper.SaveImage(vm.MasterPartnerLogoImageFile, vm.MasterPartnerLogoImageUrl, "MasterPartnerImages");

            var entity = new MasterPartner
            {
                Id = vm.Id,
                MasterPartnerName = vm.MasterPartnerName,
                MasterPartnerLogoImageUrl = imageName,
                MasterPartnerWebsiteUrl = vm.MasterPartnerWebsiteUrl,
                IsActive = vm.IsActive
            };

            Repository.Update(entity);
        }
    }
}
