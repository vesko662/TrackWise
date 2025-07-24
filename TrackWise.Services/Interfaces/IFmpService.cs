using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Dto.AssetDtos;

namespace TrackWise.Services.Interfaces
{
    public interface IFmpService
    {
        public Task<IEnumerable<AssetSeedDto>> GetSymbolsListAsync();
    }
}
