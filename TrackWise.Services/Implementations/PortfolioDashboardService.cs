using System;
using System.Collections.Generic;
using System.Linq;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Dto.PortfolioDashboard;
using TrackWise.Models.Entities;
using TrackWise.Models.Enums;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class PortfolioDashboardService : IPortfolioDashboardService
    {
        private readonly IHoldingRepository holdingRepository;
        private readonly IPriceRepository priceRepository;
        private readonly IPriceService priceService;
        private readonly ITransactionRepository transactionRepository;

        public PortfolioDashboardService(
            IHoldingRepository holdingRepository,
            IPriceRepository priceRepository,
            IPriceService priceService,
            ITransactionRepository transactionRepository)
        {
            this.holdingRepository = holdingRepository;
            this.priceRepository = priceRepository;
            this.priceService = priceService;
            this.transactionRepository = transactionRepository;
        }

        public PortfolioDashboardViewModel BuildData(string portfolioId)
        {
            var tx = transactionRepository.GetWhere(t => t.PortfolioId == portfolioId)
                                          .OrderBy(t => t.Created)
                                          .ToList();

            if (!tx.Any())
            {
                return new PortfolioDashboardViewModel
                {
                    PortfolioId = portfolioId,
                    TotalValue = 0m,
                    AnnualReturn = 0m,
                    AnnualProfit = 0m,
                    ChartLabels = new List<string>(),
                    ChartValues = new List<decimal>()
                };
            }

            var start = tx.First().Created.Date;
            var end = DateTime.UtcNow.Date;
            var yesterday = end.AddDays(-1);

            var holdings = holdingRepository.GetWhere(h => h.PortfolioId == portfolioId).ToList();

            var assetIds = holdings.Select(h => h.AssetId)
                                   .Concat(tx.Select(t => t.AssetId))
                                   .Distinct()
                                   .ToList();

            foreach (var assetId in assetIds)
            {
                bool hasPriceYesterday = priceRepository
                    .GetWhere(p => p.AssetId == assetId &&
                                   p.Date >= yesterday && p.Date < yesterday.AddDays(1))
                    .Any();

                if (!hasPriceYesterday)
                {
                    priceService.AddPriceHistory(assetId);
                }
            }

            var (labels, values) = BuildChartFromTransactions(tx, start, end);

            decimal totalValue = 0m;
            foreach (var h in holdings)
            {
                var last = priceRepository.GetWhere(p => p.AssetId == h.AssetId)
                                          .OrderByDescending(p => p.Date)
                                          .Select(p => (decimal?)p.HistoryPrice)
                                          .FirstOrDefault() ?? 0m;

                totalValue += h.Quantity * last;
            }

            var costBasis = holdings.Sum(h => h.Quantity * h.AvgBuyPrice);
            var profit = totalValue - costBasis;

            var days = Math.Max(1, (end - start).TotalDays);

            var invested = tx.Sum(t =>
                (t.Type == TransactionType.Buy ? 1m : -1m) * (t.Quantity * t.Price)
            );

            decimal periodReturn = 0m;
            if (invested > 0m && totalValue > 0m)
            {
                periodReturn = (totalValue - invested) / invested;  
            }

            decimal annualReturn = periodReturn;
            if (days >= 365 && periodReturn > -0.9999m)
            {
                annualReturn = (decimal)Math.Pow(1.0 + (double)periodReturn, 365.0 / days) - 1m;
            }


            return new PortfolioDashboardViewModel
            {
                PortfolioId = portfolioId,
                TotalValue = totalValue,
                AnnualProfit = profit,
                AnnualReturn = annualReturn,
                ChartLabels = labels,
                ChartValues = values
            };
        }

        private (List<string> labels, List<decimal> values) BuildChartFromTransactions(
            List<Transaction> transactions,
            DateTime start,
            DateTime end)
        {
            var assetIds = transactions.Select(t => t.AssetId).Distinct().ToList();

            var priceCache = new Dictionary<string, Dictionary<DateTime, decimal>>();
            foreach (var assetId in assetIds)
            {
                var prices = priceRepository.GetWhere(p => p.AssetId == assetId && p.Date <= end)
                                            .OrderBy(p => p.Date)
                                            .ToList();

                var map = prices
                    .GroupBy(p => p.Date.Date)
                    .ToDictionary(g => g.Key, g => g.Last().HistoryPrice);

                priceCache[assetId] = map;
            }

            var dailyDeltas = new Dictionary<DateTime, Dictionary<string, decimal>>();
            foreach (var t in transactions)
            {
                var d = t.Created.Date;
                if (!dailyDeltas.TryGetValue(d, out var perAsset))
                {
                    perAsset = new Dictionary<string, decimal>();
                    dailyDeltas[d] = perAsset;
                }

                var sign = t.Type == TransactionType.Buy ? 1m : -1m;
                perAsset[t.AssetId] = perAsset.TryGetValue(t.AssetId, out var cur)
                    ? cur + sign * t.Quantity
                    : sign * t.Quantity;
            }

            var qtyByAsset = assetIds.ToDictionary(id => id, _ => 0m);
            var lastPriceByAsset = assetIds.ToDictionary(id => id, _ => 0m);

            var labels = new List<string>();
            var values = new List<decimal>();

            for (var d = start.Date; d <= end.Date; d = d.AddDays(1))
            {
                if (dailyDeltas.TryGetValue(d, out var perAssetDelta))
                {
                    foreach (var kv in perAssetDelta)
                    {
                        qtyByAsset[kv.Key] += kv.Value;
                    }
                }

                decimal dayValue = 0m;

                foreach (var assetId in assetIds)
                {
                    if (priceCache[assetId].TryGetValue(d, out var px))
                        lastPriceByAsset[assetId] = px;

                    var price = lastPriceByAsset[assetId];
                    var qty = qtyByAsset[assetId];

                    if (qty != 0m && price > 0m)
                        dayValue += qty * price;
                }

                labels.Add(d.ToString("yyyy-MM-dd"));
                values.Add(dayValue);
            }

            var firstIdx = values.FindIndex(v => v > 0m);
            if (firstIdx > 0)
            {
                labels = labels.Skip(firstIdx).ToList();
                values = values.Skip(firstIdx).ToList();
            }

            return (labels, values);
        }
    }
}
