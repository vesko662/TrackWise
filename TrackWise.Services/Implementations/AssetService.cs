using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Dto.AssetDtos;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class AssetService : IAssetService
    {
        public IEnumerable<AssetDto> GetAssetsByQuery(string query)
        {
           return new List<AssetDto>();
        }
    }
}
