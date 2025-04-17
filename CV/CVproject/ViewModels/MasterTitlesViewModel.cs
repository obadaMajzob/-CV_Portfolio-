using CVproject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CVproject.ViewModels
{
    public class MasterTitlesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActivate { get; set; }
        public int KeywordId { get; set; }

        public LookuoKeywords LookupKeywords { get; set; }
        public SelectList Keywords { get; set; }
    }

    public class MasterFullTitlesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActivate { get; set; }
        public int KeywordId { get; set; }

        public List<LookuoKeywords> LookupKeywords { get; set; }
        public SelectList Keywords { get; set; }

        public List<MasterTitlesViewModel> MasterTitlesViewModels { get; set; }
    }

}
