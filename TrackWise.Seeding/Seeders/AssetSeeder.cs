using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;
using TrackWise.Models.Enums;
using TrackWise.Services.Interfaces;

namespace TrackWise.Seeding.Seeders
{
    public class AssetSeeder : ISeeder
    {
        private readonly IFmpService fmp;
        private readonly ICoinGeckoService coinGecko;
        private readonly IAssetRepository assets;
        private readonly IExchangeRepository exchange;

        public AssetSeeder(IFmpService fmp, ICoinGeckoService coinGecko, IAssetRepository assets, IExchangeRepository exchange)
        {
            this.fmp = fmp;
            this.assets = assets;
            this.coinGecko = coinGecko;
            this.exchange = exchange;
        }

        public async Task<bool> ShouldRunAsync()
        {
            return !await assets.AnyAsync();
        }

        public async Task SeedAsync()
        {
            var stockAndEtf = await fmp.GetSymbolsListAsync();
            var crypto = await coinGecko.GetCryptoListAsync();

            var exchangeNames = stockAndEtf.GroupBy(x => x.Exchange).Select(x => x.Key).Select(x => x is null ? "noName" : x).ToList();
            var exchanges = exchangeNames.Select(x => new Exchange() { Name = x }).ToList();
            var cryptoExch = new Exchange() { Name = "Crypto Market" };
            exchange.Add(cryptoExch);
            if (exchanges.Any())
            {
                exchange.AddRange(exchanges);
            }
            var newAssets = stockAndEtf.Select(x => new Asset()
            {
                Name = x.Name,
                Symbol = x.Symbol,
                ExchangeId = exchanges
        .First(e => e.Name == (x.Exchange ?? "noName"))
        .Id,
                Type = x.Type,
            }).ToList();


            var cryptoParsed = crypto.Select(x => new Asset()
            {
                Id = x.Id,
                Name = x.Name,
                Symbol = x.Symbol,
                Type = x.Type,
                ExchangeId = cryptoExch.Id,
            }).ToList();

            newAssets = newAssets.Concat(cryptoParsed).ToList();

            await assets.AddRangeAsync(newAssets);
        }
    }

}

