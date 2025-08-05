using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Dto.AssetDtos;

namespace TrackWise.Services.Interfaces
{
    public interface IAssetService
    {

        public IEnumerable<AssetDto> GetAssetsByQuery(string query,string? type);
    }
}
