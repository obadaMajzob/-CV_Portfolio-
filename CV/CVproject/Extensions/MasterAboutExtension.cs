using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterAboutExtension
    {


        public static MasterAboutViewModel ToViewModel(this MasterAbout MasterAbout)
        {

            return new MasterAboutViewModel
            {
                Id = MasterAbout.Id,
                Name = MasterAbout.Name,
                Address = MasterAbout.Address,
                Position = MasterAbout.Position,
                Residence = MasterAbout.Residence,
                Email = MasterAbout.Email,
                DateOfBirth = MasterAbout.DateOfBirth,
                CVURL = MasterAbout.CVURL,
                ImageURL = MasterAbout.ImageURL,
                Description = MasterAbout.Description,
                Phone = MasterAbout.Phone,
                IsActivate = MasterAbout.IsActivate,
                Age = DateTime.Now.Year - MasterAbout.DateOfBirth.Year,
                CopyrightDate = DateTime.Now.Year,

            };

        }

        public static MasterAbout ToModel(this MasterAboutViewModel MasterAboutVM)
        {

            return new MasterAbout
            {
                Id = MasterAboutVM.Id,
              
                Name = MasterAboutVM.Name,
                Address = MasterAboutVM.Address,
                Position = MasterAboutVM.Position,
                Residence = MasterAboutVM.Residence,
                Email = MasterAboutVM.Email,
                DateOfBirth = MasterAboutVM.DateOfBirth,
                CVURL = MasterAboutVM.CVURL,
                ImageURL = MasterAboutVM.ImageURL,
                Description = MasterAboutVM.Description,
                Phone = MasterAboutVM.Phone,
                IsActivate = MasterAboutVM.IsActivate,


            };

        }
        public static List<MasterAboutViewModel> ToListViewModel(this List<MasterAbout> MasterAbout)
        {

            return MasterAbout.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterAbout> ToListModel(this List<MasterAboutViewModel> MasterAboutVM)
        {

            return MasterAboutVM.Select(x => x.ToModel()).ToList();

        }




    }
}
