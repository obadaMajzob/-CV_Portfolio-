using CVproject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CVproject.ViewModels
{
    public class MasterPortfolioViewModel
    {
        public int Id { get; set; }
        public string? ImageOneURL { get; set; }
        public string? ImageTwoURL { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public string Description { get; set; }
        public int MasterCategoryPortfolioId { get; set; }
        public MasterCategoryPortfolio Category { get; set; }
        public bool IsActivate { get; set; }
        public IFormFile? ImageOneFile { get; set; }
        public IFormFile? ImageTwoFile { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public SelectList ListOfCategory { get; set; }
    }


    public class MasterFullPortfolioViewModel
    {
        public int Id { get; set; }
        public string? ImageOneURL { get; set; }
        public string? ImageTwoURL { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public string Description { get; set; }
        public int MasterCategoryPortfolioId { get; set; }
        public MasterCategoryPortfolio? Category { get; set; }
        public bool? IsActivate { get; set; }
        public IFormFile? ImageOneFile { get; set; }
        public IFormFile? ImageTwoFile { get; set; }
        //[Required(ErrorMessage = "The field is required.")]
        public SelectList? ListOfCategory { get; set; }
        public List<MasterPortfolioViewModel>? MasterPortfolioViewModelss { get; set; }
    }


}
