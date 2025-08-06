using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using TrackWise.Models.Dto.ApiResponse;
using TrackWise.Models.Dto.AssetDtos;
using TrackWise.Models.Dto.PriceDto;
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

                var coins = JsonSerializer.Deserialize<IEnumerable<CoinGeckoResponse>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return coins.Select(mapper.Map<AssetSeedDto>).ToList();
            }
        }

        public async Task<IEnumerable<PriceDto>> GetPriceHistory(string id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/coins/{id}/market_chart?vs_currency=usd&days=365"),
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



                var marketChart = JsonSerializer.Deserialize<CoinGeckoMarketChartResponse>(
                   body,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (marketChart?.Prices == null)
                    return Enumerable.Empty<PriceDto>();

                return marketChart.Prices
                   .Where(p => p.Count >= 2)
                      .Select(p =>
                        {
                            var timestamp = p[0].GetDouble();
                            var price = p[1].GetDouble();

                            var date = DateTimeOffset
                                .FromUnixTimeMilliseconds((long)timestamp)
                                .UtcDateTime
                                .Date;

                            return new PriceDto
                            {
                                Date = date,
                                HistoryPrice = (decimal)price
                            };
                        })
                         .ToList();
            }
        }
    }
}
