using CVproject.Extensions;
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
    public class FullMasterTitlesController : Controller
    {
        IRepository<MasterTitles> TitleRepository;

        IRepository<LookuoKeywords> KeywordRepository;

        public FullMasterTitlesController(IRepository<MasterTitles> titleRepository, IRepository<LookuoKeywords> keywordRepository)
        {
            TitleRepository=titleRepository;
            KeywordRepository=keywordRepository;
        }



        public IActionResult Index()
        {
            var data = TitleRepository.View();
            var datapVm = data.ToListViewModel();

            var datax = KeywordRepository.View().Where(x=>!x.IsReserved).ToList();
            var dataLookup = KeywordRepository.View().ToList();

            foreach (var item in datapVm)
            {
                item.LookupKeywords = KeywordRepository.Find(item.KeywordId);
            }

            var obj = new MasterFullTitlesViewModel
            {
                MasterTitlesViewModels = datapVm,
                Keywords = new SelectList(datax, "Id", "Keyword"),
                LookupKeywords= dataLookup
            };

            return View(obj);
        }
        [HttpPost]
        public IActionResult Save(MasterFullTitlesViewModel model)
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

        public void Creat(MasterFullTitlesViewModel model)
        {
            var oldKeyWords = KeywordRepository.Find(model.KeywordId);
            oldKeyWords.IsReserved = true;
            KeywordRepository.Update(model.KeywordId, oldKeyWords);


            var obj = new MasterTitles
            {
                Title = model.Title,
                KeywordId = model.KeywordId,

            };
          
            TitleRepository.Add(obj);

        }
        public void Edit(MasterFullTitlesViewModel model)
        {
            var oldKeyWords = KeywordRepository.Find(model.KeywordId);
            oldKeyWords.IsReserved = true;
            KeywordRepository.Update(model.KeywordId, oldKeyWords);


            var obj = new MasterTitles
            {
                Id = model.Id,
                Title = model.Title,
                KeywordId = model.KeywordId,

            };
            TitleRepository.Update(model.Id, obj);

        }

        public IActionResult Delete(MasterFullTitlesViewModel model)
        {
            var oldKeyWords = KeywordRepository.Find(model.KeywordId);
            oldKeyWords.IsReserved = false;
            KeywordRepository.Update(model.KeywordId, oldKeyWords);

            TitleRepository.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }



  
        public IActionResult ChangeStatus(int id, IFormCollection collection)
        {

            TitleRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));

        }



    }
}
