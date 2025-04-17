namespace CVproject.ViewModels
{
    public class MasterEducationViewModel
    {
        public int Id { get; set; }
        public string Major { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsExperience { get; set; }
        public bool IsCurrent { get; set; }

        public bool IsActivate { get; set; }

        public int StartYear { get; set; }
        public int EndYear { get; set; }

    }

    public class MasterFullEducationViewModel
    {
        public int Id { get; set; }
        public string Major { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsExperience { get; set; }
        public bool IsCurrent { get; set; }

        public bool IsActivate { get; set; }

        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public List<MasterEducationViewModel> MasterEducationViewModelss { get; set; }
    }


}
