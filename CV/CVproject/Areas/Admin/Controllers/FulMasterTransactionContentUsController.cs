using CVproject.Extensions;
using CVproject.Helpers.Email;
using CVproject.Models;
using CVproject.Repositories;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CVproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FulMasterTransactionContentUsController : Controller
    {
        IRepository<MasterTransactionContentUs> ContentUsRepository;
        IEmailHelper EmailHelper;
        public FulMasterTransactionContentUsController(IRepository<MasterTransactionContentUs> contentUsRepository, IEmailHelper emailHelper)
        {
            ContentUsRepository=contentUsRepository;
            EmailHelper=emailHelper;
        }

        public IActionResult Index()
        {
            var data = ContentUsRepository.View();
            var dataVm = data.TolListViewMode();

            var obj = new MasterFullTransactionContentUsViewModel { 
                MasterTransactionContentUsViewModelss = dataVm,
            };
            return View(obj);
        }


        public IActionResult Delete(MasterFullTransactionContentUsViewModel model)
        {
            ContentUsRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));

        }


        ///////////////** Reply **//////////////

        public IActionResult Reply(int id)
        {
            var data = ContentUsRepository.Find(id);
            var obj = new TransactionContactUsReplyViewModel
            {
                Email = data.Email
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult Reply(int id, TransactionContactUsReplyViewModel model)
        {
            var message = model.Message;
            EmailHelper.SendEmail(model.Email, model.Subject, message);
            return View();
        }







    }
}
