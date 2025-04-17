namespace CVproject.ViewModels
{
    public class MasterCategoryPortfolioViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public bool IsActivate { get; set; }
    }


    public class MasterFullCategoryPortfolioViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public bool IsActivate { get; set; }

        public List<MasterCategoryPortfolioViewModel> MasterCategoryPortfolioViewModelss { get; set; }
    }


}
