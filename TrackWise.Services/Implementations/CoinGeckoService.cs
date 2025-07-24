using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public CoinGeckoService (HttpClient httpClient, IConfiguration configuration,IMapper mapper)
        {
            this.httpClient = httpClient;
            baseUrl = configuration["FmpApi:BaseUrl"];
            apiKey = configuration["FmpApi:ApiKey"]; 
            this.mapper = mapper;
        }

        public Task<IEnumerable<AssetDto>> GetCryptoListAsync()
        {
            return (Task<IEnumerable<AssetDto>>)Task.CompletedTask;
        }
    }
}
