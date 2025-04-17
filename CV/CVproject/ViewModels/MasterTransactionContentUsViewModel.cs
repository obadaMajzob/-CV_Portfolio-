using System.ComponentModel.DataAnnotations;

namespace CVproject.ViewModels
{
    public class MasterTransactionContentUsViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Subject { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Message { get; set; }
    }

    public class MasterFullTransactionContentUsViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Subject { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Message { get; set; }
        public List<MasterTransactionContentUsViewModel> MasterTransactionContentUsViewModelss { get; set; }

    }

    /////////////////////////////////////////

    public class TransactionContactUsReplyViewModel
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
