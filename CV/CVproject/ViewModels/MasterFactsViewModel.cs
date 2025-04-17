namespace CVproject.ViewModels
{
    public class MasterFactsViewModel
    {
        public int Id { get; set; }
        public string text { get; set; }
        public string Icon { get; set; }
        public int Numper { get; set; }
        public bool IsActivate { get; set; }
    }
    

    public class MasterFullFactsViewModel
    {
        public int Id { get; set; }
        public string text { get; set; }
        public string Icon { get; set; }
        public int Numper { get; set; }
        public bool IsActivate { get; set; }
        public List<MasterFactsViewModel> MasterFactsViewModels { get; set; }
    }


}
