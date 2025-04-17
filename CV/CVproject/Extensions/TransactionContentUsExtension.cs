using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{ 
    public static class MasterTransactionContentUsExtension
    {
        public static MasterTransactionContentUsViewModel ToViewModel(this MasterTransactionContentUs TransactionContentUs)
        {

            return new MasterTransactionContentUsViewModel
            {
                Id = TransactionContentUs.Id,
                FullName = TransactionContentUs.FullName,
                Subject = TransactionContentUs.Subject,
                Email = TransactionContentUs.Email,
                Message = TransactionContentUs.Message, 
            };

        }

        public static List<MasterTransactionContentUsViewModel> TolListViewMode(this List<MasterTransactionContentUs> TransactionContentUs)
        {

            return TransactionContentUs.Select(s => s.ToViewModel()).ToList();
        }

        public static MasterTransactionContentUs ToModel(this MasterTransactionContentUsViewModel TransactionContentUsViewModels)
        {

            return new MasterTransactionContentUs
            {
                Id = TransactionContentUsViewModels.Id,
                FullName = TransactionContentUsViewModels.FullName,
                Subject = TransactionContentUsViewModels.Subject,
                Email = TransactionContentUsViewModels.Email,
                Message = TransactionContentUsViewModels.Message,


            };

        }

        public static List<MasterTransactionContentUs> ToListModel(this List<MasterTransactionContentUsViewModel> TransactionContentUsViewModels)
        {

            return TransactionContentUsViewModels.Select(x => x.ToModel()).ToList();

        }
    }
}
