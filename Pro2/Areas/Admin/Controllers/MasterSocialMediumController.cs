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

    public class MasterSocialMediumController : Controller
    {
         IRepository<MasterSocialMedium> Repository;

        public MasterSocialMediumController(IRepository<MasterSocialMedium> repository)
        {
            Repository = repository;
        }

        public IActionResult Index(int id = 0)
        {
            var info = new MasterSocialMediumViewModel();

            if (id != 0)
            {
                info = Repository.Find(id).ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var vm = new MasterSocialMediumFullViewModel
            {
                MasterSociallist = data,
                Id = info.Id,
                MasterSocialMediaImageUrl = info.MasterSocialMediaImageUrl,
                MasterSocialMediaUrl = info.MasterSocialMediaUrl,
                IsActive = info.IsActive
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MasterSocialMediumFullViewModel model)
        {
            try
            {
                var vm = new MasterSocialMediumViewModel
                {
                    Id = model.Id,
                    MasterSocialMediaImageUrl = model.MasterSocialMediaImageUrl,
                    MasterSocialMediaUrl = model.MasterSocialMediaUrl,
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
                model.MasterSociallist = Repository.View().ToViewModelList();
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

        private void Create(MasterSocialMediumViewModel vm)
        {
            var entity = new MasterSocialMedium
            {
                MasterSocialMediaImageUrl = vm.MasterSocialMediaImageUrl,
                MasterSocialMediaUrl = vm.MasterSocialMediaUrl,
                IsActive = vm.IsActive
            };

            Repository.Add(entity);
        }

        private void Edit(MasterSocialMediumViewModel vm)
        {
            var entity = new MasterSocialMedium
            {
                Id = vm.Id,
                MasterSocialMediaImageUrl = vm.MasterSocialMediaImageUrl,
                MasterSocialMediaUrl = vm.MasterSocialMediaUrl,
                IsActive = vm.IsActive
            };

            Repository.Update(entity);
        }
    }
}
