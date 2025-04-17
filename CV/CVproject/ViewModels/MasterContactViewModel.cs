namespace CVproject.ViewModels
{
    public class MasterContactViewModel
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public bool IsActivate { get; set; }

    }

    

    public class MasterFullContactViewModel
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public bool IsActivate { get; set; }

        public List<MasterContactViewModel> MasterContactViewModels { get; set; }

    }



}
