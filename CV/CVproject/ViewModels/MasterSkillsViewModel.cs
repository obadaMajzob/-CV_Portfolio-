namespace CVproject.ViewModels
{
    public class MasterSkillsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public int Percentage { get; set; }

        public bool IsActivate { get; set; }
    }


    public class MasterFullSkillsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public int Percentage { get; set; }

        public bool IsActivate { get; set; }
        public List<MasterSkillsViewModel> MasterSkillsViewModelss { get; set; }
    }


}
