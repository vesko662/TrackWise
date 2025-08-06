using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;
using TrackWise.Models.Enums;
using TrackWise.Models.Dto.PriceDto;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class PriceService : IPriceService
    {
        private readonly IPriceRepository priceRepository;
        private readonly IHoldingRepository holdingRepository;
        private readonly IAssetRepository assetRepository;
        private readonly ICoinGeckoService coinGeckoService;
        private readonly IFmpService fmpService;

        public PriceService(
            IPriceRepository priceRepository,
            IHoldingRepository holdingRepository,
            IAssetRepository assetRepository,
            ICoinGeckoService coinGeckoService,
            IFmpService fmpService)
        {
            this.priceRepository = priceRepository;
            this.holdingRepository = holdingRepository;
            this.assetRepository = assetRepository;
            this.coinGeckoService = coinGeckoService;
            this.fmpService = fmpService;
        }

        public bool CheckDate(string assetId, DateTime date)
        {
            return priceRepository.Exists(assetId, date.Date);
        }

        public void AddTodayPrice(string assetId, decimal price)
        {
            if (!CheckDate(assetId, DateTime.UtcNow.Date))
            {
                var entity = new Price
                {
                    AssetId = assetId,
                    Date = DateTime.UtcNow.Date,
                    HistoryPrice = price
                };
                priceRepository.Add(entity);
                priceRepository.Save();
            }
        }

        public void AddPriceHistory(string assetId)
        {
            var asset = assetRepository.GetAssetById(assetId);
            if (asset == null)
                return;

            List<PriceDto> prices;

            if (asset.Type == AssetType.Stock || asset.Type == AssetType.ETF)
            {
                prices = fmpService.GetPriceHistory(asset.Symbol).Result.ToList();
            }
            else if (asset.Type == AssetType.Crypto)
            {
                prices = coinGeckoService.GetPriceHistory(asset.Id).Result.ToList();
            }
            else
            {
                return;
            }

            var existingDates = priceRepository
                .GetWhere(p => p.AssetId == assetId)
                .Select(p => p.Date)
                .ToHashSet();

            var newPrices = prices
                .Where(p => !existingDates.Contains(p.Date))
                .Select(p => new Price
                {
                    AssetId = assetId,
                    Date = p.Date,
                    HistoryPrice = p.HistoryPrice
                })
                .ToList();

            if (newPrices.Any())
            {
                priceRepository.AddRange(newPrices);
                priceRepository.Save();
            }
        }


        public decimal GetLatestPrice(string assetId) => priceRepository.GetLatestPrice(assetId);

        public void UpdatePricesForPortfolio(string portfolioId)
        {
            
        }
    }
}
