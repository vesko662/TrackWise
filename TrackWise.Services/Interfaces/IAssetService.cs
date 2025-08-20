using TrackWise.Models.Dto.AssetDtos;

namespace TrackWise.Services.Interfaces
{
    public interface IAssetService
    {

        public IEnumerable<AssetDto> GetAssetsByQuery(string query,string? type);
    }
}
