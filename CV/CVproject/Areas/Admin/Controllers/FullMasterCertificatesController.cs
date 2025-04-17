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
    public class FullMasterCertificatesController : Controller
    {
        IRepository<MasterCertificates> CertificatesRepository;
        IFileHelper FileHelper;

        public FullMasterCertificatesController(IRepository<MasterCertificates> certificatesRepository, IFileHelper fileHelper)
        {
            CertificatesRepository=certificatesRepository;
            FileHelper=fileHelper;
        }

        public IActionResult Index()
        {
            var data = CertificatesRepository.View();
            var datapVm = data.ToListViewModel();

            var obj = new MasterFullCertificatesViewModel
            {
                MasterCertificatesViewModelss = datapVm,
            };

            return View(obj);
        }



        [HttpPost]
        public IActionResult Save(MasterFullCertificatesViewModel model)
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




        public void Creat(MasterFullCertificatesViewModel model)
        {
            var imageName = FileHelper.SaveImage(model.ImageFile, "", "Images");
           
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
            var obj = new MasterCertificates
            {
                Title = model.Title,
                issueDate = model.issueDate,
                MembershipNumper = model.MembershipNumper,  
                ImageURL = imageName,
                

            };
            if (imageName != "Error" )
            {
                CertificatesRepository.Add(obj);

            }


        }
        public void Edit(MasterFullCertificatesViewModel model)
        {
            var imageName = FileHelper.SaveImage(model.ImageFile, model.ImageURL, "Images");
            
            var obj = new MasterCertificates
            {
                Id = model.Id,
                Title = model.Title,
                issueDate = model.issueDate,
                MembershipNumper = model.MembershipNumper,
                ImageURL = imageName,


            };
            if (imageName != "Error" )
            {
                CertificatesRepository.Update(model.Id, obj);

            }


        }

        public IActionResult Delete(MasterFullCertificatesViewModel model)
        {
            CertificatesRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            CertificatesRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }





    }
}
