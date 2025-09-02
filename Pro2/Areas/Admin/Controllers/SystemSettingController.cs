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

    public class SystemSettingController : Controller
    {
         IRepository<SystemSetting> Repository;
         IFileHelper FileHelper;

        public SystemSettingController(IRepository<SystemSetting> repository, IFileHelper fileHelper)
        {
            Repository = repository;
            FileHelper = fileHelper;
        }

        public IActionResult Index(int id = 0)
        {
            var info = new SystemSettingViewModel();

            if (id != 0)
                info = Repository.Find(id).ToViewModel();

            var vm = new SystemSettingFullViewModel
            {
                SystemSettinglist = Repository.View().ToViewModelList(),
                Id = info.Id,
                IsActive = info.IsActive,
                SystemSettingLogoImageUrl = info.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = info.SystemSettingLogoImageUrl2,
                SystemSettingWelcomeNoteImageUrl = info.SystemSettingWelcomeNoteImageUrl,
                SystemSettingCopyright = info.SystemSettingCopyright,
                SystemSettingWelcomeNoteTitle = info.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteBreef = info.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = info.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteUrl = info.SystemSettingWelcomeNoteUrl
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SystemSettingFullViewModel model)
        {
            try
            {
                // حفظ الصور
                if (model.SystemSettingLogoImageFile != null)
                {
                    var logoName = FileHelper.SaveImage(model.SystemSettingLogoImageFile, model.SystemSettingLogoImageUrl, "SystemSettingImages");
                    if (logoName != "Error") model.SystemSettingLogoImageUrl = logoName;
                    else return HandleImageError(model, "خطأ أثناء رفع الشعار.");
                }

                if (model.SystemSettingLogoImageFile2 != null)
                {
                    var logo2Name = FileHelper.SaveImage(model.SystemSettingLogoImageFile2, model.SystemSettingLogoImageUrl2, "SystemSettingImages");
                    if (logo2Name != "Error") model.SystemSettingLogoImageUrl2 = logo2Name;
                    else return HandleImageError(model, "خطأ أثناء رفع الشعار الثاني.");
                }

                if (model.SystemSettingWelcomeNoteImageFile != null)
                {
                    var noteImg = FileHelper.SaveImage(model.SystemSettingWelcomeNoteImageFile, model.SystemSettingWelcomeNoteImageUrl, "SystemSettingImages");
                    if (noteImg != "Error") model.SystemSettingWelcomeNoteImageUrl = noteImg;
                    else return HandleImageError(model, "خطأ أثناء رفع صورة الترحيب.");
                }

                var vm = new SystemSettingViewModel
                {
                    Id = model.Id,
                    IsActive = model.IsActive,
                    SystemSettingLogoImageUrl = model.SystemSettingLogoImageUrl,
                    SystemSettingLogoImageUrl2 = model.SystemSettingLogoImageUrl2,
                    SystemSettingWelcomeNoteImageUrl = model.SystemSettingWelcomeNoteImageUrl,
                    SystemSettingCopyright = model.SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = model.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = model.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = model.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteUrl = model.SystemSettingWelcomeNoteUrl
                };

                if (vm.Id == 0)
                    Create(vm);
                else
                    Edit(vm);

                return RedirectToAction("Index");
            }
            catch
            {
                model.SystemSettinglist = Repository.View().ToViewModelList();
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFullAction(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("Index");
        }

        private void Create(SystemSettingViewModel vm)
        {
            var entity = new SystemSetting
            {
                IsActive = vm.IsActive,
                SystemSettingLogoImageUrl = vm.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = vm.SystemSettingLogoImageUrl2,
                SystemSettingWelcomeNoteImageUrl = vm.SystemSettingWelcomeNoteImageUrl,
                SystemSettingCopyright = vm.SystemSettingCopyright,
                SystemSettingWelcomeNoteTitle = vm.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteBreef = vm.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = vm.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteUrl = vm.SystemSettingWelcomeNoteUrl
            };

            Repository.Add(entity);
        }

        private void Edit(SystemSettingViewModel vm)
        {
            var entity = new SystemSetting
            {
                Id = vm.Id,
                IsActive = vm.IsActive,
                SystemSettingLogoImageUrl = vm.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = vm.SystemSettingLogoImageUrl2,
                SystemSettingWelcomeNoteImageUrl = vm.SystemSettingWelcomeNoteImageUrl,
                SystemSettingCopyright = vm.SystemSettingCopyright,
                SystemSettingWelcomeNoteTitle = vm.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteBreef = vm.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = vm.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteUrl = vm.SystemSettingWelcomeNoteUrl
            };

            Repository.Update(entity);
        }

        private IActionResult HandleImageError(SystemSettingFullViewModel model, string message)
        {
            model.SystemSettinglist = Repository.View().ToViewModelList();
            ModelState.AddModelError("", message);
            return View(model);
        }
    }
}
