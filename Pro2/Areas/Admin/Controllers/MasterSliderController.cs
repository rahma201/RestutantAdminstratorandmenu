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

    public class MasterSliderController : Controller
    {
       IRepository<MasterSlider> Repository;
       IFileHelper FileHelper;

        public MasterSliderController(IRepository<MasterSlider> repository, IFileHelper fileHelper)
        {
            Repository = repository;
            FileHelper = fileHelper;
        }

        public IActionResult Index(int id )
        {
            var sliderInfo = new MasterSliderViewModel();

            if (id != 0)
            {
                sliderInfo = Repository.Find(id).ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var vm = new MasterSliderFullViewModel
            {
                MasterSliderlist = data,
                Id = sliderInfo.Id,
                MasterSliderTitle = sliderInfo.MasterSliderTitle,
                MasterSliderBreef = sliderInfo.MasterSliderBreef,
                MasterSliderDesc = sliderInfo.MasterSliderDesc,
                MasterSliderUrl = sliderInfo.MasterSliderUrl,
                IsActive = sliderInfo.IsActive
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MasterSliderFullViewModel model)
        {
            try
            {
                var vm = new MasterSliderViewModel
                {
                    Id = model.Id,
                    MasterSliderTitle = model.MasterSliderTitle,
                    MasterSliderBreef = model.MasterSliderBreef,
                    MasterSliderDesc = model.MasterSliderDesc,
                    MasterSliderUrl = model.MasterSliderUrl,
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
                model.MasterSliderlist = Repository.View().ToViewModelList();
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

        private void Create(MasterSliderViewModel vm)
        {
            var entity = new MasterSlider
            {
                MasterSliderTitle = vm.MasterSliderTitle,
                MasterSliderBreef = vm.MasterSliderBreef,
                MasterSliderDesc = vm.MasterSliderDesc,
                MasterSliderUrl = vm.MasterSliderUrl,
                IsActive = vm.IsActive
            };

            Repository.Add(entity);
        }

        private void Edit(MasterSliderViewModel vm)
        {
            var entity = new MasterSlider
            {
                Id = vm.Id,
                MasterSliderTitle = vm.MasterSliderTitle,
                MasterSliderBreef = vm.MasterSliderBreef,
                MasterSliderDesc = vm.MasterSliderDesc,
                MasterSliderUrl = vm.MasterSliderUrl,
                IsActive = vm.IsActive
            };

            Repository.Update(entity);
        }
    }
}
