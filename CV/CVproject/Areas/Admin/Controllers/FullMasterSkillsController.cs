using CVproject.Extensions;
using CVproject.Helpers.File;
using CVproject.Models;
using CVproject.Repositories;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CVproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FullMasterSkillsController : Controller
    {
        IRepository<MasterSkills> SkillsRepository;

        public FullMasterSkillsController(IRepository<MasterSkills> skillsRepository)
        {
            SkillsRepository=skillsRepository;
        }

        public IActionResult Index()
        {
            var data = SkillsRepository.View();
            var dataVm = data.ToListViewModel();

            var obj = new MasterFullSkillsViewModel { 
                
                MasterSkillsViewModelss = dataVm,
            
            };

            return View(obj);
        }






        [HttpPost]
        public IActionResult Save(MasterFullSkillsViewModel model)
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




        public void Creat(MasterFullSkillsViewModel model)
        {
            
            var obj = new MasterSkills
            {
                Title = model.Title,
                Type = model.Type,  
                Percentage = model.Percentage,
               

            };

            SkillsRepository.Add(obj);

        }
        public void Edit(MasterFullSkillsViewModel model)
        {
           

            var obj = new MasterSkills
            {
                Id = model.Id,
                Title = model.Title,
                Type = model.Type,
                Percentage = model.Percentage,


            };
            SkillsRepository.Update(model.Id, obj);


        }

        public IActionResult Delete(MasterFullSkillsViewModel model)
        {
            SkillsRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            SkillsRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }














    }
}
