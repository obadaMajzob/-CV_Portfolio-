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
    public class FullMasterFactsController : Controller
    {
        IRepository<MasterFacts> FactsRepository;

        public FullMasterFactsController(IRepository<MasterFacts> factsRepository)
        {
            FactsRepository=factsRepository;
        }

        public IActionResult Index()
        {

            var data = FactsRepository.View();
            var dataVm = data.ToListViewModel();

            var obj = new MasterFullFactsViewModel
            {
                MasterFactsViewModels=dataVm,
            };
            return View(obj);

        }

        [HttpPost]
        public IActionResult Save(MasterFullFactsViewModel model)
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

        public void Creat(MasterFullFactsViewModel model)
        {
            var obj = new MasterFacts
            {
                text = model.text,
                Icon = model.Icon,
                Numper = model.Numper,  
            };
            FactsRepository.Add(obj);


        }

        public void Edit(MasterFullFactsViewModel model)
        {
            var obj = new MasterFacts
            {
                text = model.text,
                Icon = model.Icon,
                Numper = model.Numper,
                Id = model.Id
            };
            FactsRepository.Update(model.Id, obj);

        }



        public IActionResult Delete(MasterFullFactsViewModel model)
        {
            FactsRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            FactsRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }








    }
}
