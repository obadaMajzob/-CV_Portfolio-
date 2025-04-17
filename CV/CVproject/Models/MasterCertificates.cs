namespace CVproject.Models
{
    public class MasterCertificates : BaseEntity
    {

        public string Title { get; set; }
        public int MembershipNumper { get; set; }
        public DateTime issueDate { get; set; }
        public string? ImageURL { get; set; }


    }
}
