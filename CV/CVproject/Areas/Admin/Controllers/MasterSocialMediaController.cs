using CVproject.Extensions;
using CVproject.Models;
using CVproject.Repositories;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVproject.Areas.Admin.Controllers
{
    public class MasterSocialMediaController : Controller
    {
        IRepository<MasterSocialMedia> SocialMediaRepository;

        public MasterSocialMediaController(IRepository<MasterSocialMedia> socialMediaRepository)
        {
            SocialMediaRepository=socialMediaRepository;
        }

        // GET: MasterSocialMediaController
        public ActionResult Index()
        {
            var data = SocialMediaRepository.View().ToListViewModel();
            return View(data);
        }

        // GET: MasterSocialMediaController/Details/5
        public ActionResult Details(int id)
        {
            var data = SocialMediaRepository.Find(id).ToViewModel();
            return View(data);
        }

        // GET: MasterSocialMediaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSocialMediaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMediaViewModel collection)
        {
            try
            {
                var data = collection.ToModel();
                SocialMediaRepository.Add(data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = SocialMediaRepository.Find(id).ToViewModel();
            return View(data);
        }

        // POST: MasterSocialMediaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMediaViewModel collection)
        {
            try
            {
                var data = collection.ToModel();
                SocialMediaRepository.Update(id,data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = SocialMediaRepository.Find(id).ToViewModel();
            return View(data);
        }

        // POST: MasterSocialMediaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                SocialMediaRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: MasterSocialMediaController/Delete/5
        public ActionResult ChangeStatus(int id)
        {
            var data = SocialMediaRepository.Find(id).ToViewModel();
            return View(data);
        }

        // POST: MasterSocialMediaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStatus(int id, IFormCollection collection)
        {
            try
            {
                SocialMediaRepository.ChangeStatus(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
