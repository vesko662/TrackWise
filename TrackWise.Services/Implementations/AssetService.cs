using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Dto.AssetDtos;
using TrackWise.Models.Dto.PortfolioDto;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository assetRepository;
        private readonly IMapper mapper;    
        public AssetService(IAssetRepository assetRepository,IMapper mapper)
        {
            this.assetRepository = assetRepository;
            this.mapper = mapper;
        }
        public IEnumerable<AssetDto> GetAssetsByQuery(string query)
        {
            return assetRepository.GetWhere(x => x.Name.Contains(query)).Select(mapper.Map<AssetDto>).ToList(); ;
        }
    }
}
