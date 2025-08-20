using TrackWise.Models.Dto.TransactionDtos;

namespace TrackWise.Services.Interfaces
{
    public interface ITransactionService
    {
        public void AddTransaction(TransactionCreateDto transaction);

        public void DeleteTransaction(string portfolioId, string transactionId);
    }
}
