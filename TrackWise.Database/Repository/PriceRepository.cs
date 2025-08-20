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
            var price = dbSet
          .Where(p => p.AssetId == assetId)
          .OrderByDescending(p => p.Date)
          .Select(p => (decimal?)p.HistoryPrice) 
          .FirstOrDefault();

            return price ?? 0m;
        }
    }
}
