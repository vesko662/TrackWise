using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using TrackWise.Models.Dto.ApiResponse;
using TrackWise.Models.Dto.AssetDtos;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class CoinGeckoService : ICoinGeckoService
    {
        private readonly HttpClient httpClient;
        private readonly IMapper mapper;
        private readonly string baseUrl;
        private readonly string apiKey;

        public CoinGeckoService(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
        {
            this.httpClient = httpClient;
            baseUrl = configuration["CoinGeckoApi:BaseUrl"];
            apiKey = configuration["CoinGeckoApi:ApiKey"];
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AssetSeedDto>> GetCryptoListAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/coins/list"),
                Headers =
                {
                    { "accept", "application/json" },
                    { "x-cg-demo-api-key", apiKey },
                },
            };
            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var coins =  JsonSerializer.Deserialize<IEnumerable<CoinGeckoResponse>>(body,  new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return coins.Select(mapper.Map<AssetSeedDto>).ToList();
            }
        }
    }
}
