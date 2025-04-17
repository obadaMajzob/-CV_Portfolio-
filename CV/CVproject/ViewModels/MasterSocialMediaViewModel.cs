namespace CVproject.ViewModels
{
    public class MasterSocialMediaViewModel
    {
        public int Id { get; set; }
        public string MasterSocialMediaIcon { get; set; }
        public string MasterSocialMediaLink { get; set; }
        public bool IsActivate { get; set; }
    }

    public class MasterFullSocialMediaViewModel
    {
        public int Id { get; set; }
        public string MasterSocialMediaIcon { get; set; }
        public string MasterSocialMediaLink { get; set; }
        public bool IsActivate { get; set; }
        public List<MasterSocialMediaViewModel> MasterSocialMediaViewModels { get; set; }   
    }
}
