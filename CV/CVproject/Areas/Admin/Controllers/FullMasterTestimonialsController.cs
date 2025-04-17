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
    public class FullMasterTestimonialsController : Controller
    {
        IRepository<MasterTestimonials> TestimonialsRepository;
        IFileHelper FileHelper;

        public FullMasterTestimonialsController(IRepository<MasterTestimonials> testimonialsRepository, IFileHelper fileHelper)
        {
            TestimonialsRepository=testimonialsRepository;
            FileHelper=fileHelper;
        }

        public IActionResult Index()
        {
            var data = TestimonialsRepository.View();
            var datapVm = data.ToListViewModel();

            var obj = new MasterFullTestimonialsViewModel
            {
                MasterTestimonialsViewModels = datapVm,
            };

            return View(obj);
        }



        [HttpPost]
        public IActionResult Save(MasterFullTestimonialsViewModel model)
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


        public void Creat(MasterFullTestimonialsViewModel model)
        {
            var imageName = FileHelper.SaveImage(model.ImageFile, "", "Images");

            var obj = new MasterTestimonials
            {
                Name = model.Name,
                bio = model.bio,
                Position = model.Position,
                ImageURL = imageName,

            };
            if (imageName != "Error")
            {
                TestimonialsRepository.Add(obj);
            }


        }


        public void Edit(MasterFullTestimonialsViewModel model)
        {
            var imageName = FileHelper.SaveImage(model.ImageFile, model.ImageURL, "Images");

            var obj = new MasterTestimonials
            {
                Id = model.Id,
                Name = model.Name,
                bio = model.bio,
                Position = model.Position,
                ImageURL = imageName,

            };
            if (imageName != "Error")
            {
                TestimonialsRepository.Update(model.Id, obj);

            }

        }


        public IActionResult Delete(MasterFullTestimonialsViewModel model)
        {
            TestimonialsRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            TestimonialsRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }



    }
}
