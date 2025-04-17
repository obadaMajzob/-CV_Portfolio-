using CVproject.Models;
using CVproject.ViewModels;
using System.Drawing;

namespace CVproject.Extensions
{
    public static class MasterServicesExtension
    {


        public static MasterServicesViewModel ToViewModel(this MasterServices MasterServices)
        {

            return new MasterServicesViewModel
            {
                Id = MasterServices.Id,
                Icon = MasterServices.Icon, 
                Title = MasterServices.Title,
                Description = MasterServices.Description,
                IsActivate = MasterServices.IsActivate,
            };

        }

        public static MasterServices ToModel(this MasterServicesViewModel MasterServicesVM)
        {

            return new MasterServices
            {
                Id = MasterServicesVM.Id,
                Icon = MasterServicesVM.Icon,
                Title = MasterServicesVM.Title,
                Description = MasterServicesVM.Description,
                IsActivate = MasterServicesVM.IsActivate,

            };

        }
        public static List<MasterServicesViewModel> ToListViewModel(this List<MasterServices> MasterServices)
        {

            return MasterServices.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterServices> ToListModel(this List<MasterServicesViewModel> MasterServicesVM)
        {

            return MasterServicesVM.Select(x => x.ToModel()).ToList();

        }




    }
}
