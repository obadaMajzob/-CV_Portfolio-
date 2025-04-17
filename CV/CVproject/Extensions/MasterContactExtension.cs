using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterContactExtension
    {

        public static MasterContactViewModel ToViewModel(this MasterContact MasterContact)
        {

            return new MasterContactViewModel
            {
                Id = MasterContact.Id,
                Text = MasterContact.Text,
                Icon = MasterContact.Icon,
                IsActivate = MasterContact.IsActivate,
            };

        }

        public static MasterContact ToModel(this MasterContactViewModel MasterContactVM)
        {

            return new MasterContact
            {
                Id = MasterContactVM.Id,
                Text = MasterContactVM.Text,
                Icon = MasterContactVM.Icon,
                IsActivate = MasterContactVM.IsActivate,

            };

        }
        public static List<MasterContactViewModel> ToListViewModel(this List<MasterContact> MasterContact)
        {

            return MasterContact.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterContact> ToListModel(this List<MasterContactViewModel> MasterContactVM)
        {

            return MasterContactVM.Select(x => x.ToModel()).ToList();

        }




    }
}
