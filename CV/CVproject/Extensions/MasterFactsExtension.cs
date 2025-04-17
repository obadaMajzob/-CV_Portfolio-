using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterFactsExtension
    {



        public static MasterFactsViewModel ToViewModel(this MasterFacts MasterFacts)
        {

            return new MasterFactsViewModel
            {
                Id = MasterFacts.Id,
                text = MasterFacts.text,
                Icon = MasterFacts.Icon,
                Numper = MasterFacts.Numper,

                IsActivate = MasterFacts.IsActivate,
            };

        }

        public static MasterFacts ToModel(this MasterFactsViewModel MasterFactsVM)
        {

            return new MasterFacts
            {
                Id = MasterFactsVM.Id,
                text = MasterFactsVM.text,
                Icon = MasterFactsVM.Icon,
                Numper = MasterFactsVM.Numper,
                IsActivate = MasterFactsVM.IsActivate,

            };

        }
        public static List<MasterFactsViewModel> ToListViewModel(this List<MasterFacts> MasterFacts)
        {

            return MasterFacts.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterFacts> ToListModel(this List<MasterFactsViewModel> MasterFactsVM)
        {

            return MasterFactsVM.Select(x => x.ToModel()).ToList();

        }




    }
}
