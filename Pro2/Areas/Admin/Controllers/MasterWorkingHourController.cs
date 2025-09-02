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

    public class MasterWorkingHourController : Controller
    {
         IRepository<MasterWorkingHour> Repository;

        public MasterWorkingHourController(IRepository<MasterWorkingHour> repository)
        {
            Repository = repository;
        }

        public IActionResult Index(int id = 0)
        {
            var info = new MasterWorkingHourViewMdel();

            if (id != 0)
            {
                info = Repository.Find(id).ToViewModel();
            }

            var data = Repository.View().ToViewModelList();

            var vm = new MasterWorkingHourFullViewMdel
            {
                MasterWorkingHourlist = data,
                Id = info.Id,
                MasterWorkingHoursIdName = info.MasterWorkingHoursIdName,
                MasterWorkingHoursIdTimeFormTo = info.MasterWorkingHoursIdTimeFormTo,
                IsActive = info.IsActive
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MasterWorkingHourFullViewMdel model)
        {
            try
            {
                var vm = new MasterWorkingHourViewMdel
                {
                    Id = model.Id,
                    MasterWorkingHoursIdName = model.MasterWorkingHoursIdName,
                    MasterWorkingHoursIdTimeFormTo = model.MasterWorkingHoursIdTimeFormTo,
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
                model.MasterWorkingHourlist = Repository.View().ToViewModelList();
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

        private void Create(MasterWorkingHourViewMdel vm)
        {
            var entity = new MasterWorkingHour
            {
                MasterWorkingHoursIdName = vm.MasterWorkingHoursIdName,
                MasterWorkingHoursIdTimeFormTo = vm.MasterWorkingHoursIdTimeFormTo,
                IsActive = vm.IsActive
            };

            Repository.Add(entity);
        }

        private void Edit(MasterWorkingHourViewMdel vm)
        {
            var entity = new MasterWorkingHour
            {
                Id = vm.Id,
                MasterWorkingHoursIdName = vm.MasterWorkingHoursIdName,
                MasterWorkingHoursIdTimeFormTo = vm.MasterWorkingHoursIdTimeFormTo,
                IsActive = vm.IsActive
            };

            Repository.Update(entity);
        }
    }
}
