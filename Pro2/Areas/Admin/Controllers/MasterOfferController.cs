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

    public class MasterOfferController : Controller
    {
         IRepository<MasterOffer> Repository;
         IFileHelper FileHelper;

        public MasterOfferController(IRepository<MasterOffer> repository, IFileHelper fileHelper)
        {
            Repository = repository;
            FileHelper = fileHelper;
        }

        public IActionResult Index(int id = 0)
        {
            var offerInfo = new MasterOfferViewMdel();

            if (id != 0)
            {
                offerInfo = Repository.Find(id).ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var vm = new MasterOfferFullViewMdel
            {
                MasterOfferlist = data,
                Id = offerInfo.Id,
                MasterOfferTitle = offerInfo.MasterOfferTitle,
                MasterOfferBreef = offerInfo.MasterOfferBreef,
                MasterOfferDesc = offerInfo.MasterOfferDesc,
                MasterOfferImageFile = null,
                MasterOfferImageUrl = offerInfo.MasterOfferImageUrl,
                IsActive = offerInfo.IsActive
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MasterOfferFullViewMdel model)
        {
            try
            {
                var vm = new MasterOfferViewMdel
                {
                    Id = model.Id,
                    MasterOfferTitle = model.MasterOfferTitle,
                    MasterOfferBreef = model.MasterOfferBreef,
                    MasterOfferDesc = model.MasterOfferDesc,
                    MasterOfferImageFile = model.MasterOfferImageFile,
                    MasterOfferImageUrl = model.MasterOfferImageUrl,
                    IsActive = model.IsActive
                };

                if (vm.Id == 0)
                {
                    var imageName = FileHelper.SaveImage(model.MasterOfferImageFile, "", "MasterOfferImages");
                    if (imageName != "Error")
                    {
                        model.MasterOfferImageUrl = imageName;
                        vm.MasterOfferImageUrl = imageName;
                    }
                    else
                    {
                        model.MasterOfferlist = Repository.View().ToViewModelList();
                        ModelState.AddModelError("", "Error");
                        return View(model);
                    }

                    Create(vm);
                }
                else
                {
                    if (model.MasterOfferImageFile != null)
                    {
                        var imageName = FileHelper.SaveImage(model.MasterOfferImageFile, model.MasterOfferImageUrl, "MasterOfferImages");
                        if (imageName != "Error")
                        {
                            model.MasterOfferImageUrl = imageName;
                            vm.MasterOfferImageUrl = imageName;
                        }
                        else
                        {
                            model.MasterOfferlist = Repository.View().ToViewModelList();
                            ModelState.AddModelError("", "Error.");
                            return View(model);
                        }
                    }

                    Edit(vm);
                }

                return RedirectToAction("Index", new { id = string.Empty });
            }
            catch
            {
                model.MasterOfferlist = Repository.View().ToViewModelList();
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

        private void Create(MasterOfferViewMdel vm)
        {
            var imageName = FileHelper.SaveImage(vm.MasterOfferImageFile, vm.MasterOfferImageUrl, "MasterOfferImages");

            var entity = new MasterOffer
            {
                MasterOfferTitle = vm.MasterOfferTitle,
                MasterOfferBreef = vm.MasterOfferBreef,
                MasterOfferDesc = vm.MasterOfferDesc,
                MasterOfferImageUrl = imageName,
                IsActive = vm.IsActive
            };

            Repository.Add(entity);
        }

        private void Edit(MasterOfferViewMdel vm)
        {
            var imageName = FileHelper.SaveImage(vm.MasterOfferImageFile, vm.MasterOfferImageUrl, "MasterOfferImages");

            var entity = new MasterOffer
            {
                Id = vm.Id,
                MasterOfferTitle = vm.MasterOfferTitle,
                MasterOfferBreef = vm.MasterOfferBreef,
                MasterOfferDesc = vm.MasterOfferDesc,
                MasterOfferImageUrl = imageName,
                IsActive = vm.IsActive
            };

            Repository.Update(entity);
        }
    }
}
