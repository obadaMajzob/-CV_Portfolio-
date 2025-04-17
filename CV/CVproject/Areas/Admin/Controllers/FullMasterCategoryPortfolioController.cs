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
    public class FullMasterCategoryPortfolioController : Controller
    {
        IRepository<MasterCategoryPortfolio> CategoryPortfolioRepository;

        public FullMasterCategoryPortfolioController(IRepository<MasterCategoryPortfolio> categoryPortfolioRepository)
        {
            CategoryPortfolioRepository=categoryPortfolioRepository;
        }


        public IActionResult Index()
        {
            var data = CategoryPortfolioRepository.View();
            var dataVm = data.ToListViewModel();

            var obj = new MasterFullCategoryPortfolioViewModel
            {

                MasterCategoryPortfolioViewModelss = dataVm,

            };
            return View(obj);
        }


        [HttpPost]
        public IActionResult Save(MasterFullCategoryPortfolioViewModel model)
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

        public void Creat(MasterFullCategoryPortfolioViewModel model)
        {
            var obj = new MasterCategoryPortfolio
            {
                CategoryName = model.CategoryName,
            };
            CategoryPortfolioRepository.Add(obj);

        }


        public void Edit(MasterFullCategoryPortfolioViewModel model)
        {
            var obj = new MasterCategoryPortfolio
            {
                Id = model.Id,
                CategoryName = model.CategoryName,
            };
            CategoryPortfolioRepository.Update(model.Id, obj);

        }


        public IActionResult Delete(MasterFullCategoryPortfolioViewModel model)
        {
            CategoryPortfolioRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            CategoryPortfolioRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }





    }
}
