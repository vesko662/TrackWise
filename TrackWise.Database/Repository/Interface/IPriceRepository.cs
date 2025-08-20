using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository.Interface
{
    public interface IPriceRepository: IRepository<Price>
    {
        bool Exists(string assetId, DateTime date);
        decimal GetLatestPrice(string assetId);
        void DeleteByAssetId(string assetId);
    }
}
