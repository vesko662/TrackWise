using TrackWise.Models.Dto.AssetDtos;
using TrackWise.Models.Dto.PriceDto;

namespace TrackWise.Services.Interfaces
{
    public interface ICoinGeckoService
    {
        public Task<IEnumerable<AssetSeedDto>> GetCryptoListAsync();

        public Task<IEnumerable<PriceDto>> GetPriceHistory(string id);

    }
}
