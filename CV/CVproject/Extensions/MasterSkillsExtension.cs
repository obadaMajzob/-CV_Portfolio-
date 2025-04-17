using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterSkillsExtension
    {

        public static MasterSkillsViewModel ToViewModel(this MasterSkills MasterSkills)
        {

            return new MasterSkillsViewModel
            {
                Id = MasterSkills.Id,
                Title = MasterSkills.Title,
                Type = MasterSkills.Type,
                Percentage = MasterSkills.Percentage,
                IsActivate = MasterSkills.IsActivate,
            };

        }

        public static MasterSkills ToModel(this MasterSkillsViewModel MasterSkillsVM)
        {

            return new MasterSkills
            {
                Id = MasterSkillsVM.Id,
                Title = MasterSkillsVM.Title,
                Type = MasterSkillsVM.Type,
                Percentage=MasterSkillsVM.Percentage,
                IsActivate = MasterSkillsVM.IsActivate,

            };

        }
        public static List<MasterSkillsViewModel> ToListViewModel(this List<MasterSkills> MasterSkills)
        {

            return MasterSkills.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterSkills> ToListModel(this List<MasterSkillsViewModel> MasterSkillsVM)
        {

            return MasterSkillsVM.Select(x => x.ToModel()).ToList();

        }


    }
}
