using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using TrackWise.Models.Dto.ApiResponse;
using TrackWise.Models.Dto.AssetDtos;
using TrackWise.Models.Dto.PriceDto;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class FmpService : IFmpService
    {
        private readonly HttpClient httpClient;
        private readonly string baseUrl;
        private readonly string apiKey;
        private readonly IMapper mapper;

        public FmpService(HttpClient httpClient, IConfiguration configuration,IMapper mapper)
        {
            this.httpClient = httpClient;
            baseUrl = configuration["FmpApi:BaseUrl"];
            apiKey = configuration["FmpApi:ApiKey"]; 
            this.mapper = mapper;
        }




        public async Task<IEnumerable<AssetSeedDto>> GetSymbolsListAsync()
        {
            var url = $"{baseUrl}/stock/list?apikey={apiKey}";
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var assets = await JsonSerializer.DeserializeAsync<List<FmpSymbolResponse>>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return assets
                .Where(x => x.Type == "stock" || x.Type == "etf")
                .Select(mapper.Map<AssetSeedDto>)
                .ToList();
        }

        public async Task<IEnumerable<PriceDto>> GetPriceHistory(string symbol)
        {
            var url = $"{baseUrl}/historical-price-full/{symbol}?apikey={apiKey}";
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var priceHistory = await JsonSerializer.DeserializeAsync<FmpHistoricalPriceResponse>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return priceHistory.Historical
                .Select(mapper.Map<PriceDto>)
                .ToList();
        }

    }
}
