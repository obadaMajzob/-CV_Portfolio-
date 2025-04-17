using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterClientsExtension
    {


        public static MasterClientsViewModel ToViewModel(this MasterClients MasterClients)
        {

            return new MasterClientsViewModel
            {
                Id = MasterClients.Id,
                ImageURL = MasterClients.ImageURL,

                IsActivate = MasterClients.IsActivate,


            };

        }

        public static MasterClients ToModel(this MasterClientsViewModel MasterClientsVM)
        {

            return new MasterClients
            {
                Id = MasterClientsVM.Id,
                ImageURL = MasterClientsVM.ImageURL,

                IsActivate = MasterClientsVM.IsActivate,


            };

        }
        public static List<MasterClientsViewModel> ToListViewModel(this List<MasterClients> MasterClients)
        {

            return MasterClients.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterClients> ToListModel(this List<MasterClientsViewModel> MasterClientsVM)
        {

            return MasterClientsVM.Select(x => x.ToModel()).ToList();

        }




    }
}
