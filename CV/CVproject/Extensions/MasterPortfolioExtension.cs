using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterPortfolioExtension
    {



        public static MasterPortfolioViewModel ToViewModel(this MasterPortfolio MasterPortfolio)
        {

            return new MasterPortfolioViewModel
            {
                Id = MasterPortfolio.Id,
                Icon = MasterPortfolio.Icon,
                Description = MasterPortfolio.Description,  
                ImageOneURL = MasterPortfolio.ImageOneURL,
                ImageTwoURL = MasterPortfolio.ImageTwoURL,  
                MasterCategoryPortfolioId = MasterPortfolio.MasterCategoryPortfolioId,
                IsActivate = MasterPortfolio.IsActivate,


            };

        }

        public static MasterPortfolio ToModel(this MasterPortfolioViewModel MasterPortfolio)
        {

            return new MasterPortfolio
            {
                Id = MasterPortfolio.Id,
                Icon = MasterPortfolio.Icon,
                Description = MasterPortfolio.Description,
                ImageOneURL = MasterPortfolio.ImageOneURL,
                ImageTwoURL = MasterPortfolio.ImageTwoURL,
                MasterCategoryPortfolioId = MasterPortfolio.MasterCategoryPortfolioId,
                IsActivate = MasterPortfolio.IsActivate,


            };

        }
        public static List<MasterPortfolioViewModel> ToListViewModel(this List<MasterPortfolio> MasterPortfolio)
        {

            return MasterPortfolio.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterPortfolio> ToListModel(this List<MasterPortfolioViewModel> MasterPortfolio)
        {

            return MasterPortfolio.Select(x => x.ToModel()).ToList();

        }





    }
}
