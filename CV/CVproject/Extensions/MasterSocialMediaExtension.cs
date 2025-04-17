using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterSocialMediaExtension
    {
        public static MasterSocialMediaViewModel ToViewModel(this MasterSocialMedia MasterSocialMedia)
        {

            return new MasterSocialMediaViewModel
            {
                Id = MasterSocialMedia.Id,
                MasterSocialMediaIcon = MasterSocialMedia.MasterSocialMediaIcon,
                MasterSocialMediaLink = MasterSocialMedia.MasterSocialMediaLink,
                IsActivate = MasterSocialMedia.IsActivate,
            };

        }

        public static MasterSocialMedia ToModel(this MasterSocialMediaViewModel MasterSocialMediaVM)
        {

            return new MasterSocialMedia
            {
                Id = MasterSocialMediaVM.Id,
                MasterSocialMediaIcon = MasterSocialMediaVM.MasterSocialMediaIcon,
                MasterSocialMediaLink = MasterSocialMediaVM.MasterSocialMediaLink,
                IsActivate = MasterSocialMediaVM.IsActivate,

            };

        }
        public static List<MasterSocialMediaViewModel> ToListViewModel(this List<MasterSocialMedia> MasterSocialMedia)
        {

            return MasterSocialMedia.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterSocialMedia> ToListModel(this List<MasterSocialMediaViewModel> MasterSocialMediaVM)
        {

            return MasterSocialMediaVM.Select(x => x.ToModel()).ToList();

        }

    }
}
