using CVproject.Extensions;
using CVproject.Models;
using CVproject.Repositories;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace CVproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FullMasterSocialMediaController : Controller
    {
        IRepository<MasterSocialMedia> SocialMediaRepository;

        public FullMasterSocialMediaController(IRepository<MasterSocialMedia> socialMediaRepository)
        {
            SocialMediaRepository=socialMediaRepository;
        }

        public IActionResult Index()
        {
            var data = SocialMediaRepository.View();
            var dataVm = data.ToListViewModel();

            var obj = new MasterFullSocialMediaViewModel
            {
                MasterSocialMediaViewModels=dataVm,
            };
            return View(obj);
        }


        [HttpPost]
        public IActionResult Save(MasterFullSocialMediaViewModel model)
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

        public void Creat(MasterFullSocialMediaViewModel model)
        {
            var obj = new MasterSocialMedia { 
                MasterSocialMediaIcon = model.MasterSocialMediaIcon, 
                MasterSocialMediaLink = model.MasterSocialMediaLink,    
            };
            SocialMediaRepository.Add(obj);
            

        }
        public void Edit(MasterFullSocialMediaViewModel model)
        {
            var obj = new MasterSocialMedia {
                MasterSocialMediaIcon = model.MasterSocialMediaIcon,
                MasterSocialMediaLink = model.MasterSocialMediaLink,
                Id = model.Id
            };
            SocialMediaRepository.Update(model.Id, obj);

        }

        public IActionResult Delete(MasterFullSocialMediaViewModel model)
        {
            SocialMediaRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {
           
                SocialMediaRepository.ChangeStatus(id);

                return RedirectToAction(nameof(Index));
            
        }
    
    }
}
