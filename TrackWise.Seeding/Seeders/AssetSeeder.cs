using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;
using TrackWise.Services.Interfaces;

namespace TrackWise.Seeding.Seeders
{
    public class AssetSeeder : ISeeder
    {
        private readonly IFmpService fmp;
        private readonly ICoinGeckoService coinGecko;
        private readonly IAssetRepository assets;

        public AssetSeeder(IFmpService fmp,ICoinGeckoService coinGecko, IAssetRepository assets)
        {
            this.fmp = fmp;
            this.assets = assets;
            this.coinGecko = coinGecko;
        }

        public async Task<bool> ShouldRunAsync()
        {
            return !await assets.AnyAsync();
        }

        public async Task SeedAsync()
        {
            var symbols = await fmp.GetSymbolsListAsync();
            var crypto = await coinGecko.GetCryptoListAsync();

            //var entities = raw.Select(x => new Asset
            //{
            //    Symbol = x.Symbol,
            //    Name = x.Name,
            //    Exchange = x.ExchangeShortName,
            //    CurrentPrice = decimal.Parse(x.Price)
            //}).ToList();

            //await assets.AddRangeAsync(entities);
            //await assets.SaveChangesAsync();
        }
    }

    }

