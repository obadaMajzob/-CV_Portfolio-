namespace CVproject.ViewModels
{
    public class MasterTestimonialsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string bio { get; set; }
        public string Position { get; set; }
        public string ImageURL { get; set; }

        public bool IsActivate { get; set; }

        public IFormFile ImageFile { get; set; }
    }


    public class MasterFullTestimonialsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string bio { get; set; }
        public string Position { get; set; }
        public string ImageURL { get; set; }

        public bool IsActivate { get; set; }

        public IFormFile ImageFile { get; set; }
        public List<MasterTestimonialsViewModel> MasterTestimonialsViewModels { get; set; }
    }


}
