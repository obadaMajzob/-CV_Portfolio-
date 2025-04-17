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
    public class FullMasterContactController : Controller
    {
        IRepository<MasterContact> ContactRepository;

        public FullMasterContactController(IRepository<MasterContact> contactRepository)
        {
            ContactRepository=contactRepository;
        }

        public IActionResult Index()
        {
            var data = ContactRepository.View();
            var dataVm = data.ToListViewModel();

            var obj = new MasterFullContactViewModel
            {
                MasterContactViewModels=dataVm,
            };
            return View(obj);
        }


        [HttpPost]
        public IActionResult Save(MasterFullContactViewModel model)
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

        public void Creat(MasterFullContactViewModel model)
        {
            var obj = new MasterContact
            {
                Text = model.Text,
                Icon = model.Icon,
            };
             ContactRepository.Add(obj);


        }
        public void Edit(MasterFullContactViewModel model)
        {
            var obj = new MasterContact
            {
                Id = model.Id,
                Text = model.Text,
                Icon = model.Icon,
            };
            ContactRepository.Update(model.Id, obj);

        }

        public IActionResult Delete(MasterFullContactViewModel model)
        {
            ContactRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            ContactRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }



















    }
}
