using CVproject.Extensions;
using CVproject.Models;
using CVproject.Repositories;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CVproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FullMasterServicesController : Controller
    {
        IRepository<MasterServices> ServicesRepository;

        public FullMasterServicesController(IRepository<MasterServices> servicesRepository)
        {
            ServicesRepository=servicesRepository;
        }

        public IActionResult Index()
        {
            var data = ServicesRepository.View();
            var dataVM = data.ToListViewModel();

            var obj = new MasterFullServicesViewModel { 
                MasterServicesViewModels = dataVM,
            };
            return View(obj);
        }



        [HttpPost]
        public IActionResult Save(MasterFullServicesViewModel model)
        {
            if (model.Id == 0)
            {
                Creat(model);
            }
            else
            {
                Edit(model);
            }
            return RedirectToAction(nameof(Index));


        }

        public void Creat(MasterFullServicesViewModel model)
        {
            var obj = new MasterServices
            {
                Icon = model.Icon,
                Title = model.Title,    
                Description = model.Description,

            };
            ServicesRepository.Add(obj);


        }

        public void Edit(MasterFullServicesViewModel model)
        {
            var obj = new MasterServices
            {
                Icon = model.Icon,
                Title = model.Title,
                Description = model.Description,
                Id = model.Id
            };
            ServicesRepository.Update(model.Id, obj);

        }

        public IActionResult Delete(MasterFullServicesViewModel model)
        {
            ServicesRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            ServicesRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }

    }
}
