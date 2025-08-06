using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository
{
    public class PriceRepository : Repository<Price>, IPriceRepository
    {
        public PriceRepository(TrackWiseDbContext db) : base(db)
        {
        }

        public void DeleteByAssetId(string assetId)
        {
            var pricesToRemove = dbSet.Where(p => p.AssetId == assetId).ToList();
            if (pricesToRemove.Any())
            {
                dbSet.RemoveRange(pricesToRemove);
            }
        }

        public bool Exists(string assetId, DateTime date)
        {
            return dbSet.Any(p =>
                 p.AssetId == assetId &&
                 p.Date.Date == date.Date);
        }

        public decimal GetLatestPrice(string assetId)
        {
            return dbSet
                .Where(p => p.AssetId == assetId)
                .OrderByDescending(p => p.Date)
                .Select(p => p.HistoryPrice)
                .DefaultIfEmpty(0m)
                .First();
        }
    }
}
