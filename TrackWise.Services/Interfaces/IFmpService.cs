using TrackWise.Models.Dto.AssetDtos;
using TrackWise.Models.Dto.PriceDto;

namespace TrackWise.Services.Interfaces
{
    public interface IFmpService
    {
        public Task<IEnumerable<AssetSeedDto>> GetSymbolsListAsync();

        public Task<IEnumerable<PriceDto>> GetPriceHistory(string symbol);
    }
}
