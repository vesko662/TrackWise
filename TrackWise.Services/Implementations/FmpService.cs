using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrackWise.Models.Dto.ApiResponse;
using TrackWise.Models.Dto.AssetDtos;
using TrackWise.Models.Dto.PortfolioDto;
using TrackWise.Models.Enums;
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

    }
}
