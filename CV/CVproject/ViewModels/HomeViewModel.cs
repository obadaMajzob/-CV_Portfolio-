using CVproject.Models;

namespace CVproject.ViewModels
{
    public class HomeViewModel
    {
        public List<MasterSocialMediaViewModel> MasterSocialMediaList { get; set;}
        public List<MasterTitlesViewModel> MasterTitlesList { get; set;}
        public MasterAboutViewModel MasterAbout { get; set;}
        public List<MasterPositionViewModel> MasterPositionList { get; set; }
        public List<MasterServicesViewModel> MasterServiceList { get; set; }
        public List<MasterTestimonialsViewModel> MasterTestimonialsList { get; set; }
        public List<MasterClientsViewModel> MasterClientsList { get; set; }
        public List<MasterFactsViewModel> MasterFactsList { get; set; }
        public List<MasterContactViewModel> MasterContactList { get; set; }
        public List<MasterCertificatesViewModel> MasterCertificatesList { get; set; }
        public List<MasterEducationViewModel> MasterEducationList { get; set; }
        public List<MasterSkillsViewModel> MasterSkillsList { get; set; }
        public List<MasterCategoryPortfolioViewModel> MasterCategoryPortfolioList { get; set; }
        public List<MasterPortfolioViewModel> MasterPortfolioList { get; set; }
        public MasterTransactionContentUsViewModel MasterTransactionContentUss { get; set; }
    }
}
