namespace CVproject.Models
{
    public class MasterPortfolio : BaseEntity
    {

        public string? ImageOneURL { get; set; }
        public string? ImageTwoURL { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int MasterCategoryPortfolioId { get; set; }
        public MasterCategoryPortfolio Category  { get; set; }

    }
}
