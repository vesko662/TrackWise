using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<bool> AnyAsync() => await dbSet.AnyAsync();
    }
}
