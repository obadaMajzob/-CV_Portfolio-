using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterCertificatesExtension
    {


        public static MasterCertificatesViewModel ToViewModel(this MasterCertificates MasterCertificates)
        {

            return new MasterCertificatesViewModel
            {
                Id = MasterCertificates.Id,
                Title = MasterCertificates.Title,    
                MembershipNumper = MasterCertificates.MembershipNumper, 
                issueDate = MasterCertificates.issueDate,
                ImageURL = MasterCertificates.ImageURL,
               
                IsActivate = MasterCertificates.IsActivate,
              

            };

        }

        public static MasterCertificates ToModel(this MasterCertificatesViewModel MasterCertificatesVM)
        {

            return new MasterCertificates
            {
                Id = MasterCertificatesVM.Id,

                Title = MasterCertificatesVM.Title,
                MembershipNumper = MasterCertificatesVM.MembershipNumper,    
                issueDate = MasterCertificatesVM.issueDate, 
                ImageURL =MasterCertificatesVM.ImageURL,
              
                IsActivate = MasterCertificatesVM.IsActivate,


            };

        }
        public static List<MasterCertificatesViewModel> ToListViewModel(this List<MasterCertificates> MasterCertificates)
        {

            return MasterCertificates.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterCertificates> ToListModel(this List<MasterCertificatesViewModel> MasterCertificatesVM)
        {

            return MasterCertificatesVM.Select(x => x.ToModel()).ToList();

        }



    }
}
