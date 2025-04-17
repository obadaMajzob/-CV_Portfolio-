using CVproject.Extensions;
using CVproject.Helpers.File;
using CVproject.Models;
using CVproject.Repositories;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Policy;

namespace CVproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FullMasterAboutController : Controller
    {


        IRepository<MasterAbout> AboutRepository;
        IFileHelper FileHelper;
        public FullMasterAboutController(IRepository<MasterAbout> aboutRepository, IFileHelper fileHelper)
        {
            AboutRepository=aboutRepository;
            FileHelper=fileHelper;
        }

        public IActionResult Index()
        {
            var data = AboutRepository.View();
            var datapVm = data.ToListViewModel();

            var obj = new MasterFullAboutViewModel
            {
                MasterAboutViewModelss = datapVm,
            };

            return View(obj);
        }



        [HttpPost]
        public IActionResult Save(MasterFullAboutViewModel model)
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

        public void Creat(MasterFullAboutViewModel model)
        {
            var imageName = FileHelper.SaveImage(model.ImageFile ,"","Images");
            var FileName = FileHelper.SavePDF(model.CVFile ,"", "PDF");
            //try
            //{

            //}
            //catch (Exception)
            //{

            //    throw;        
            //}
            //if (ModelState.IsValid)
            //{

            //}
            var obj = new MasterAbout
            {
                Name = model.Name,
                Position = model.Position,
                Description = model.Description,
                Residence = model.Residence,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                Email = model.Email,
                Phone = model.Phone,    
                ImageURL = imageName,
                CVURL = FileName,

            };
            if (imageName != "Error" && FileName!= "Error")
            {
                AboutRepository.Add(obj);   

            }


        }

        public void Edit(MasterFullAboutViewModel model)
        {
            var imageName = FileHelper.SaveImage(model.ImageFile, model.ImageURL, "Images");
            var FileName = FileHelper.SavePDF(model.CVFile, model.CVURL, "PDF");
            var obj = new MasterAbout
            {
                Id = model.Id,
                Name = model.Name,
                Position = model.Position,
                Description = model.Description,
                Residence = model.Residence,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                Email = model.Email,
                Phone = model.Phone,
                ImageURL = imageName,
                CVURL = FileName,

            };
            if (imageName != "Error" && FileName!= "Error")
            {
                AboutRepository.Update(model.Id, obj);

            }
            

        }

        public IActionResult Delete(MasterFullAboutViewModel model)
        {
            AboutRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }
   
        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            AboutRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }






    }
}
