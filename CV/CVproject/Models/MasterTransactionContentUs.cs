namespace CVproject.Models
{
    public class MasterTransactionContentUs : BaseEntity
    {
        public string FullName { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
