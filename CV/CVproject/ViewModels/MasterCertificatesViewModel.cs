namespace CVproject.ViewModels
{
    public class MasterCertificatesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MembershipNumper { get; set; }
        public DateTime issueDate { get; set; }
        public string ImageURL { get; set; }

        public bool IsActivate { get; set; }

        public IFormFile ImageFile { get; set; }
    }


    public class MasterFullCertificatesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MembershipNumper { get; set; }
        public DateTime issueDate { get; set; }
        public string ImageURL { get; set; }

        public bool IsActivate { get; set; }

        public IFormFile ImageFile { get; set; }
        public List<MasterCertificatesViewModel> MasterCertificatesViewModelss { get; set; }
    }
}
