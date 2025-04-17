using CVproject.Extensions;
using CVproject.Helpers.File;
using CVproject.Models;
using CVproject.Repositories;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CVproject.Areas.Admin.Controllers
{
        [Area("Admin")]
        [Authorize]
    public class FullMasterEducationController : Controller
    {
        IRepository<MasterEducation> EducationRepository;

        public FullMasterEducationController(IRepository<MasterEducation> educationRepository)
        {
            EducationRepository=educationRepository;
        }



        public IActionResult Index()
        {
            var data = EducationRepository.View();
            var datapVm = data.ToListViewModel();

            var obj = new MasterFullEducationViewModel
            {
                MasterEducationViewModelss = datapVm,
            };

            return View(obj);
        }



        [HttpPost]
        public IActionResult Save(MasterFullEducationViewModel model)
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

        public void Creat(MasterFullEducationViewModel model)
        {
    
            var obj = new MasterEducation
            {
                Major = model.Major,
                Description = model.Description,
                Place = model.Place,
                StartDate = model.StartDate,
                EndDate =model.IsCurrent==true? null: model.EndDate,
                IsExperience = model.IsExperience,
                IsCurrent = model.IsCurrent,

            };

            EducationRepository.Add(obj);

          


        }

        public void Edit(MasterFullEducationViewModel model)
        {

            var obj = new MasterEducation
            {
                Id = model.Id,             
                Major = model.Major,
                Description = model.Description,
                Place = model.Place,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsExperience = model.IsExperience,
                IsCurrent = model.IsCurrent,
            };

            EducationRepository.Update(model.Id, obj);

          


        }

        public IActionResult Delete(MasterFullEducationViewModel model)
        {
            EducationRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            EducationRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }















    }
}
