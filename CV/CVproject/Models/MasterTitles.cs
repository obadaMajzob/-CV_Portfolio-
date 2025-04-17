namespace CVproject.Models
{
    public class MasterTitles : BaseEntity
    {

        public string Title { get; set; }
        public int KeywordId { get; set; }
        public LookuoKeywords Keyword { get; set; }

    }
}
