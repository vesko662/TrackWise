using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Dto.AssetDtos;
using TrackWise.Models.Enums;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository assetRepository;
        private readonly IMapper mapper;

        public AssetService(IAssetRepository assetRepository, IMapper mapper)
        {
            this.assetRepository = assetRepository;
            this.mapper = mapper;
        }

        public IEnumerable<AssetDto> GetAssetsByQuery(string query, string? type)
        {
            AssetType? parsedType = null;

            if (!string.IsNullOrWhiteSpace(type) &&
                Enum.TryParse<AssetType>(type, true, out var at))
            {
                parsedType = at;
            }

            if (string.IsNullOrWhiteSpace(query))
            {
                return assetRepository
                    .GetWhere(x => parsedType == null || x.Type == parsedType)
                    .Select(mapper.Map<AssetDto>)
                    .ToList();
            }

            var lowerQuery = query.Trim().ToLower();

            var exactMatches = assetRepository
                .GetWhere(x =>
                    (parsedType == null || x.Type == parsedType) &&
                    (x.Name.ToLower() == lowerQuery || x.Symbol.ToLower() == lowerQuery))
                .Select(mapper.Map<AssetDto>);

            var partialMatches = assetRepository
                .GetWhere(x =>
                    (parsedType == null || x.Type == parsedType) &&
                    (x.Name.ToLower().Contains(lowerQuery) || x.Symbol.ToLower().Contains(lowerQuery)) &&
                    !(x.Name.ToLower() == lowerQuery || x.Symbol.ToLower() == lowerQuery))
                .Select(mapper.Map<AssetDto>);

            return exactMatches
                .Concat(partialMatches)
                .DistinctBy(a => a.Id)
                .ToList();
        }


    }
}
