using CVproject.Extensions;
using CVproject.Helpers.Email;
using CVproject.Models;
using CVproject.Repositories;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace CVproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IRepository<MasterSocialMedia> masterSocialMediaRepository;
        IRepository<MasterTitles> masterTitlesRepository;
        IRepository<MasterAbout> masterAboutRepository;
        IRepository<MasterPosition> masterPositionRepository;
        IRepository<MasterServices> masterServicesRepository;
        IRepository<MasterTestimonials> masterTestimonialsRepository;
        IRepository<MasterClients> masterClientsRepository;
        IRepository<MasterFacts> masterFactsRepository;
        IRepository<MasterContact> masterContactRepository;
        IRepository<MasterCertificates> masterCertificatesRepository;
        IRepository<MasterEducation> masterEducationRepository;
        IRepository<MasterSkills> masterSkillsRepository;
        IRepository<MasterCategoryPortfolio> masterCategoryPortfolioRepository;
        IRepository<MasterPortfolio> masterPortfolioRepository;

        IRepository<MasterTransactionContentUs> ContentUsRepository;
        IEmailHelper emailHelper;
        public HomeController(ILogger<HomeController> logger, IRepository<MasterSocialMedia> masterSocialMediaRepository, IRepository<MasterTitles> masterTitlesRepository, IRepository<MasterAbout> masterAboutRepository, IRepository<MasterPosition> masterPositionRepository, IRepository<MasterServices> masterServicesRepository, IRepository<MasterTestimonials> masterTestimonialsRepository, IRepository<MasterClients> masterClientsRepository, IRepository<MasterFacts> masterFactsRepository, IRepository<MasterContact> masterContactRepository, IRepository<MasterCertificates> masterCertificatesRepository, IRepository<MasterEducation> masterEducationRepository, IRepository<MasterSkills> masterSkillsRepository, IRepository<MasterCategoryPortfolio> masterCategoryPortfolioRepository, IRepository<MasterPortfolio> masterPortfolioRepository, IRepository<MasterTransactionContentUs> contentUsRepository, IEmailHelper emailHelper)
        {
            _logger = logger;
            this.masterSocialMediaRepository=masterSocialMediaRepository;
            this.masterTitlesRepository=masterTitlesRepository;
            this.masterAboutRepository=masterAboutRepository;
            this.masterPositionRepository=masterPositionRepository;
            this.masterServicesRepository=masterServicesRepository;
            this.masterTestimonialsRepository=masterTestimonialsRepository;
            this.masterClientsRepository=masterClientsRepository;
            this.masterFactsRepository=masterFactsRepository;
            this.masterContactRepository=masterContactRepository;
            this.masterCertificatesRepository=masterCertificatesRepository;
            this.masterEducationRepository=masterEducationRepository;
            this.masterSkillsRepository=masterSkillsRepository;
            this.masterCategoryPortfolioRepository=masterCategoryPortfolioRepository;
            this.masterPortfolioRepository=masterPortfolioRepository;

            ContentUsRepository=contentUsRepository;
            this.emailHelper=emailHelper;
        }

        public IActionResult Index()
        {
            var obj = new HomeViewModel
            {
                MasterSocialMediaList = GetSocialLink(),
                MasterTitlesList = GetTitleLink(),
                MasterAbout = GetAboutLink(),
                MasterPositionList = GetPositionLink(),
                MasterServiceList = GetServiceLink(),
                MasterTestimonialsList = GetTestimonialsLink(),
                MasterClientsList = GetClientsLink(),
                MasterFactsList = GetFactsLink(),
                MasterContactList = GetContactLink(),
                MasterCertificatesList = GetCertificatesLink(),
                MasterEducationList = GetEducationLink(),
                MasterSkillsList = GetSkillsLink(),
                MasterCategoryPortfolioList = GetCategoryPortfolioLink(),
                MasterPortfolioList = GetPortfolioLink(),
               
            };
            return View(obj);

        }

        private List<MasterSocialMediaViewModel> GetSocialLink() {
            return masterSocialMediaRepository.ViewClient().ToListViewModel();
        }
        private List<MasterTitlesViewModel> GetTitleLink() {
            return masterTitlesRepository.ViewClient().ToListViewModel();
        } 
        private MasterAboutViewModel GetAboutLink() {
            return masterAboutRepository.ViewClient().ToListViewModel().FirstOrDefault();
        }
        private List<MasterPositionViewModel> GetPositionLink()
        {
            return masterPositionRepository.ViewClient().ToListViewModel();
        }
        private List<MasterServicesViewModel> GetServiceLink()
        {
            return masterServicesRepository.ViewClient().ToListViewModel();
        }
        private List<MasterTestimonialsViewModel> GetTestimonialsLink()
        {
            return masterTestimonialsRepository.ViewClient().ToListViewModel();
        }
        private List<MasterClientsViewModel> GetClientsLink()
        {
            return masterClientsRepository.ViewClient().ToListViewModel();
        }
        private List<MasterFactsViewModel> GetFactsLink()
        {
            return masterFactsRepository.ViewClient().ToListViewModel();
        }
        private List<MasterContactViewModel> GetContactLink()
        {
            return masterContactRepository.ViewClient().ToListViewModel();
        }
        private List<MasterCertificatesViewModel> GetCertificatesLink()
        {
            return masterCertificatesRepository.ViewClient().ToListViewModel();
        }
        private List<MasterEducationViewModel> GetEducationLink()
        {
            return masterEducationRepository.ViewClient().ToListViewModel();
        }
        private List<MasterSkillsViewModel> GetSkillsLink()
        {
            return masterSkillsRepository.ViewClient().ToListViewModel();
        }
        
        private List<MasterCategoryPortfolioViewModel> GetCategoryPortfolioLink()
        {
            return masterCategoryPortfolioRepository.ViewClient().ToListViewModel();
        }
        private List<MasterPortfolioViewModel> GetPortfolioLink()
        {
            return masterPortfolioRepository.ViewClient().ToListViewModel();
        }

        // POST: TransactionContentUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUsSave(HomeViewModel collection)
        {
            try
            {
                var FullName = collection.MasterTransactionContentUss.FullName;
                var Subject = collection.MasterTransactionContentUss.Subject;
                var Email = collection.MasterTransactionContentUss.Email;


                StringBuilder sb = new StringBuilder();
                sb.Append($"<h1> Hello  {FullName} {Subject} </h1>");
                sb.Append("<h4> Sent Using Html </h4>");

                ContentUsRepository.Add(collection.MasterTransactionContentUss.ToModel());
                emailHelper.SendEmail(Email, "Message Received", sb.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
