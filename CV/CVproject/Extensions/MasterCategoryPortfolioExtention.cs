using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterCategoryPortfolioExtention
    {


        public static MasterCategoryPortfolioViewModel ToViewModel(this MasterCategoryPortfolio MasterCategoryPortfolio)
        {

            return new MasterCategoryPortfolioViewModel
            {
                Id = MasterCategoryPortfolio.Id,
                CategoryName = MasterCategoryPortfolio.CategoryName,
                IsActivate = MasterCategoryPortfolio.IsActivate,
            };

        }

        public static MasterCategoryPortfolio ToModel(this MasterCategoryPortfolioViewModel MasterCategoryPortfolio)
        {

            return new MasterCategoryPortfolio
            {
                Id = MasterCategoryPortfolio.Id,
                CategoryName = MasterCategoryPortfolio.CategoryName,
                IsActivate = MasterCategoryPortfolio.IsActivate,

            };

        }
        public static List<MasterCategoryPortfolioViewModel> ToListViewModel(this List<MasterCategoryPortfolio> MasterCategoryPortfolio)
        {

            return MasterCategoryPortfolio.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterCategoryPortfolio> ToListModel(this List<MasterCategoryPortfolioViewModel> MasterCategoryPortfolio)
        {

            return MasterCategoryPortfolio.Select(x => x.ToModel()).ToList();

        }









    }
}
