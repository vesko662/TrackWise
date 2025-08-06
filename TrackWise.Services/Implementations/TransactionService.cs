using AutoMapper;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Dto.TransactionDtos;
using TrackWise.Models.Entities;
using TrackWise.Models.Enums;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class TransactionService:ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IHoldingRepository holdingRepository;
        private readonly IPriceService priceService;
        private readonly IMapper mapper;

        public TransactionService(
            ITransactionRepository transactionRepository,
            IHoldingRepository holdingRepository,
            IPriceService priceService,
            IMapper mapper)
        {
            this.transactionRepository = transactionRepository;
            this.holdingRepository = holdingRepository;
            this.priceService = priceService;
            this.mapper = mapper;
        }


        public void AddTransaction(TransactionCreateDto transaction)
        {
            var mappedTransaction = mapper.Map<Transaction>(transaction);
            transactionRepository.Add(mappedTransaction);
            transactionRepository.Save();

            var holding = holdingRepository.GetByPortfolioAndAsset(transaction.PortfolioId, transaction.AssetId);

            if (transaction.Type == TransactionType.Buy)
            {
                if (holding == null)
                {
                    holding = new Holding
                    {
                        PortfolioId = transaction.PortfolioId,
                        AssetId = transaction.AssetId,
                        Quantity = transaction.Quantity,
                        AvgBuyPrice = transaction.Price
                    };
                    holdingRepository.Add(holding);
                }
                else
                {
                    var totalCost = (holding.Quantity * holding.AvgBuyPrice) + (transaction.Quantity * transaction.Price);
                    holding.Quantity += transaction.Quantity;
                    holding.AvgBuyPrice = totalCost / holding.Quantity;

                    holdingRepository.Update(holding);
                }
            }
            else if (transaction.Type == TransactionType.Sell)
            {
                if (holding != null)
                {
                    holding.Quantity -= transaction.Quantity;
                    if (holding.Quantity <= 0)
                    {
                        holdingRepository.Delete(holding);
                    }
                    else
                    {
                        holdingRepository.Update(holding);
                    }
                }
            }

            holdingRepository.Save();

            var transactionDate = transaction.Created.Date;
            var today = DateTime.UtcNow.Date;

            if (transactionDate < today)
            {
                if (!priceService.CheckDate(transaction.AssetId, transactionDate))
                {
                    priceService.AddPriceHistory(transaction.AssetId);
                }
            }
        }

    }
}
