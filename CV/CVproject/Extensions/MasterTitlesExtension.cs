using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterTitlesExtension
    {
        public static MasterTitlesViewModel ToViewModel(this MasterTitles MasterTitles)
        {

            return new MasterTitlesViewModel
            {
                Id = MasterTitles.Id,
                Title = MasterTitles.Title,
                KeywordId = MasterTitles.KeywordId,
                IsActivate = MasterTitles.IsActivate,
            };

        }

        public static MasterTitles ToModel(this MasterTitlesViewModel MasterTitlesVM)
        {

            return new MasterTitles
            {
                Id = MasterTitlesVM.Id,
                Title = MasterTitlesVM.Title,
                KeywordId = MasterTitlesVM.KeywordId,
                IsActivate = MasterTitlesVM.IsActivate,

            };

        }
        public static List<MasterTitlesViewModel> ToListViewModel(this List<MasterTitles> MasterTitles)
        {

            return MasterTitles.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterTitles> ToListModel(this List<MasterTitlesViewModel> MasterTitlesVM)
        {

            return MasterTitlesVM.Select(x => x.ToModel()).ToList();

        }



    }
}
