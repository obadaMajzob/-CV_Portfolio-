using CVproject.Extensions;
using CVproject.Helpers.File;
using CVproject.Models;
using CVproject.Repositories;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;

namespace CVproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FullMasterPortfolioController : Controller
    {
        IRepository<MasterPortfolio> PortfolioRepository;
        IRepository<MasterCategoryPortfolio> CategoryRepository;
        IFileHelper FileHelper;

        public FullMasterPortfolioController(IRepository<MasterPortfolio> portfolioRepository, IRepository<MasterCategoryPortfolio> categoryRepository, IFileHelper fileHelper)
        {
            PortfolioRepository=portfolioRepository;
            CategoryRepository=categoryRepository;
            FileHelper=fileHelper;
        }

        public IActionResult Index()
        {
            var data = PortfolioRepository.View();
            var datapVm = data.ToListViewModel();

            var category = CategoryRepository.View();
            foreach (var item in datapVm)
            {

                item.Category = CategoryRepository.Find(item.MasterCategoryPortfolioId);

            }

            var obj = new MasterFullPortfolioViewModel
            {

                MasterPortfolioViewModelss = datapVm,
                ListOfCategory = new SelectList(category , "Id", "CategoryName")

            };
            return View(obj);
        }





        [HttpPost]
        public IActionResult Index(MasterFullPortfolioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var data = PortfolioRepository.View();
                var datapVm = data.ToListViewModel();

                var category = CategoryRepository.View();
                foreach (var item in datapVm)
                {

                    item.Category = CategoryRepository.Find(item.MasterCategoryPortfolioId);

                }

                var obj = new MasterFullPortfolioViewModel
                {

                    MasterPortfolioViewModelss = datapVm,
                    ListOfCategory = new SelectList(category, "Id", "CategoryName")

                };
                model.ListOfCategory = obj.ListOfCategory;
                model.MasterPortfolioViewModelss = obj.MasterPortfolioViewModelss;
                ModelState.AddModelError("", "find extension is not allowed 1 ");
                return View(model);
            }

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


        public void Creat(MasterFullPortfolioViewModel model)
        {
        
          
            try
            {
                var imageOneName = FileHelper.SaveImage(model.ImageOneFile, "", "Images");
                var imageTwoName = FileHelper.SaveImage(model.ImageTwoFile, "", "Images");
                if (imageOneName != "Error" && imageTwoName != "Error")
                {
                var obj = new MasterPortfolio
                {

                    Icon = model.Icon,
                    Description = model.Description,
                    MasterCategoryPortfolioId = model.MasterCategoryPortfolioId,
                    ImageOneURL = imageOneName,
                    ImageTwoURL = imageTwoName,

                };
                    PortfolioRepository.Add(obj);
                }
             }
            catch (Exception)
            {

                throw;
            }
            

        }


        public void Edit(MasterFullPortfolioViewModel model)
        {
            
            var imageOneName = FileHelper.SaveImage(model.ImageOneFile, model.ImageOneURL, "Images");
            var imageTwoName = FileHelper.SaveImage(model.ImageTwoFile, model.ImageTwoURL, "Images");

            var obj = new MasterPortfolio
            {
                Id = model.Id,
                Icon = model.Icon,
                Description = model.Description,
                MasterCategoryPortfolioId = model.MasterCategoryPortfolioId,
                ImageOneURL = imageOneName,
                ImageTwoURL = imageTwoName,

            };
            if (imageOneName != "Error" && imageTwoName != "Error")
            {
                PortfolioRepository.Update(model.Id, obj);

            }

        }


        public IActionResult Delete(MasterFullPortfolioViewModel model)
        {
            PortfolioRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            PortfolioRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }













    }
}
