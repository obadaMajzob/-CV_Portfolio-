namespace CVproject.ViewModels
{
    public class MasterAboutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Residence { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? CVURL { get; set; }
        public string? ImageURL { get; set; }
        public int CopyrightDate { get; set; }
        public bool IsActivate { get; set; }

        public IFormFile CVFile { get; set; }
        public IFormFile ImageFile { get; set; }

        public int Age { get; set; }

    }




    public class MasterFullAboutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Residence { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? CVURL { get; set; }
        public string? ImageURL { get; set; }

        public bool IsActivate { get; set; }

        public IFormFile CVFile { get; set; }
        public IFormFile ImageFile { get; set; }

        public int Age { get; set; }

        public List<MasterAboutViewModel> MasterAboutViewModelss { get; set; }  

    }
}
