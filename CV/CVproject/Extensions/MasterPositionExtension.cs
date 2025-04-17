using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterPositionExtension
    {


        public static MasterPositionViewModel ToViewModel(this MasterPosition MasterPosition)
        {

            return new MasterPositionViewModel
            {
                Id = MasterPosition.Id,
                Name = MasterPosition.Name, 
                IsActivate = MasterPosition.IsActivate,
            };

        }

        public static MasterPosition ToModel(this MasterPositionViewModel MasterPositionVM)
        {

            return new MasterPosition
            {
                Id = MasterPositionVM.Id,
               Name = MasterPositionVM.Name,
                IsActivate = MasterPositionVM.IsActivate,

            };

        }
        public static List<MasterPositionViewModel> ToListViewModel(this List<MasterPosition> MasterPosition)
        {

            return MasterPosition.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterPosition> ToListModel(this List<MasterPositionViewModel> MasterPositionVM)
        {

            return MasterPositionVM.Select(x => x.ToModel()).ToList();

        }



    }
}
