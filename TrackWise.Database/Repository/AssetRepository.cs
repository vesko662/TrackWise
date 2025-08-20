using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository
{
    public class AssetRepository : Repository<Asset>, IAssetRepository
    {
        public AssetRepository(TrackWiseDbContext db) : base(db)
        {
        }

        public async Task AddRangeAsync(IEnumerable<Asset> assets)
        {
           await dbSet.AddRangeAsync(assets);
           await SaveAsync();
        }

        public override IEnumerable<Asset> GetWhere(Expression<Func<Asset, bool>> filter)
        {
            IQueryable<Asset> query = dbSet.Include(x => x.Exchange).Where(filter);
                return query.ToList();
        }

        public async Task<bool> AnyAsync() => await dbSet.AnyAsync();

        public Asset GetAssetById(string assetId)
        {
            return dbSet.FirstOrDefault(x => x.Id == assetId);
        }

    }
}
