using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository.Interface
{
    public interface IAssetRepository : IRepository<Asset>
    {
       public Task<bool> AnyAsync();

        public Task AddRangeAsync(IEnumerable<Asset> assets);

        Asset GetAssetById(string assetId);
    }
}
