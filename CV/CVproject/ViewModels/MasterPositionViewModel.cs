namespace CVproject.ViewModels
{
    public class MasterPositionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActivate { get; set; }
    }

    public class MasterFullPositionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActivate { get; set; }
        public List<MasterPositionViewModel> MasterPositionViewModelss { get; set; }
    }
}
