using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterEducationExtension
    {



        public static MasterEducationViewModel ToViewModel(this MasterEducation MasterEducation)
        {

            return new MasterEducationViewModel
            {
                Id = MasterEducation.Id,
                Major = MasterEducation.Major,
                Description = MasterEducation.Description,  
                Place = MasterEducation.Place,
                StartDate = MasterEducation.StartDate,
                EndDate = MasterEducation.EndDate,
                IsExperience = MasterEducation.IsExperience,
                IsCurrent = MasterEducation.IsCurrent,

                IsActivate = MasterEducation.IsActivate,

                StartYear = MasterEducation.StartDate.Year,
                EndYear =(int)MasterEducation.EndDate?.Year, //int?
             

            };

        }

        public static MasterEducation ToModel(this MasterEducationViewModel MasterEducation)
        {

            return new MasterEducation
            {
                Id = MasterEducation.Id,
                Major = MasterEducation.Major,
                Description = MasterEducation.Description,
                Place = MasterEducation.Place,
                StartDate = MasterEducation.StartDate,
                EndDate = MasterEducation.EndDate,
                IsExperience = MasterEducation.IsExperience,
                IsCurrent = MasterEducation.IsCurrent,
             

            };

        }
        public static List<MasterEducationViewModel> ToListViewModel(this List<MasterEducation> MasterEducation)
        {

            return MasterEducation.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterEducation> ToListModel(this List<MasterEducationViewModel> MasterEducationVM)
        {

            return MasterEducationVM.Select(x => x.ToModel()).ToList();

        }





    }
}
