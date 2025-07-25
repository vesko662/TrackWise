using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Dto.AssetDtos;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository.Interface
{
    public interface IAssetRepository : IRepository<Asset>
    {
       public Task<bool> AnyAsync();

        public Task AddRangeAsync(IEnumerable<Asset> assets);

        
    }
}
