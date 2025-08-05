using AutoMapper;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Dto.TransactionDtos;
using TrackWise.Models.Entities;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class TransactionService:ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IMapper mapper;
        public TransactionService(ITransactionRepository transactionRepository,IMapper mapper)
        {
            this.mapper= mapper;
            this.transactionRepository = transactionRepository;
        }

        public void AddTransaction(TransactionCreateDto transaction)
        {
            var mappedTransaction = mapper.Map<Transaction>(transaction);
            transactionRepository.Add(mappedTransaction);
            transactionRepository.Save();
        }
    }
}
