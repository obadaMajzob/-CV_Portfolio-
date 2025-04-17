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
    public class FullMasterClientsController : Controller
    {
        IRepository<MasterClients> ClientsRepository;
        IFileHelper FileHelper;

        public FullMasterClientsController(IRepository<MasterClients> clientsRepository, IFileHelper fileHelper)
        {
            ClientsRepository=clientsRepository;
            FileHelper=fileHelper;
        }

        public IActionResult Index()
        {
            var data = ClientsRepository.View();
            var dataVm = data.ToListViewModel();

            var obj = new MasterFullClientsViewModel {
                MasterClientsViewModels = dataVm,   
            };
            return View(obj);
        }



        [HttpPost]
        public IActionResult Save(MasterFullClientsViewModel model)
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



        public void Creat(MasterFullClientsViewModel model)
        {
            var imageName = FileHelper.SaveImage(model.ImageFile, "", "Images");

            var obj = new MasterClients
            {

                ImageURL = imageName,
            };
            if (imageName != "Error")
            {
                ClientsRepository.Add(obj);
            }

        }


        public void Edit(MasterFullClientsViewModel model)
        {
            var imageName = FileHelper.SaveImage(model.ImageFile, model.ImageURL, "Images");

            var obj = new MasterClients
            {
                Id = model.Id,

                ImageURL = imageName,

            };
            if (imageName != "Error")
            {
                ClientsRepository.Update(model.Id, obj);

            }

        }



        public IActionResult Delete(MasterFullClientsViewModel model)
        {
            ClientsRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            ClientsRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }







    }
}
