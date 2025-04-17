namespace CVproject.ViewModels
{
    public class MasterServicesViewModel
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActivate { get; set; }

    }
    public class MasterFullServicesViewModel
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActivate { get; set; }

        public List<MasterServicesViewModel> MasterServicesViewModels { get; set; }

    }
}
