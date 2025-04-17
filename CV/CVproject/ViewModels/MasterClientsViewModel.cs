namespace CVproject.ViewModels
{
    public class MasterClientsViewModel
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public IFormFile ImageFile { get; set; }
        public bool IsActivate { get; set; }

    }


    public class MasterFullClientsViewModel
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public IFormFile ImageFile { get; set; }
        public bool IsActivate { get; set; }
        public List<MasterClientsViewModel> MasterClientsViewModels { get; set; }

    }

}
