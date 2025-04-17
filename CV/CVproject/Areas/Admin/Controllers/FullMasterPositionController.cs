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
    public class FullMasterPositionController : Controller
    {
        IRepository<MasterPosition> PositionRepository;

        public FullMasterPositionController(IRepository<MasterPosition> positionRepository)
        {
            PositionRepository=positionRepository;
        }

        public IActionResult Index()
        {
            var data = PositionRepository.View();
            var dataVm = data.ToListViewModel();

            var obj = new MasterFullPositionViewModel { 
                
                MasterPositionViewModelss = dataVm,

            };
            return View(obj);
        }


        [HttpPost]
        public IActionResult Save(MasterFullPositionViewModel model)
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

        public void Creat(MasterFullPositionViewModel model)
        {
            var obj = new MasterPosition
            {
                Name = model.Name,
            };
            PositionRepository.Add(obj);


        }
        public void Edit(MasterFullPositionViewModel model)
        {
            var obj = new MasterPosition
            {               
                Id = model.Id,
                Name = model.Name,  
            };
            PositionRepository.Update(model.Id, obj);

        }

        public IActionResult Delete(MasterFullPositionViewModel model)
        {
            PositionRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            PositionRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }



    }
}
