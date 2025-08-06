using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository.Interface
{
    public interface IHoldingRepository : IRepository<Holding>
    {
        IEnumerable<Asset> GetAssetsInPortfolio(string portfolioId);
        Holding GetByPortfolioAndAsset(string portfolioId, string assetId);
    }
}
