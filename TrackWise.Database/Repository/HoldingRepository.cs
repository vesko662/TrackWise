using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository
{
    public class HoldingRepository : Repository<Holding>, IHoldingRepository
    {

        public HoldingRepository(TrackWiseDbContext db) : base(db)
        {
        }
        public IEnumerable<Asset> GetAssetsInPortfolio(string portfolioId)
        {
            return dbSet
                .Where(h => h.PortfolioId == portfolioId)
                .Select(h => h.Asset)
                .Distinct()
                .ToList();
        }

        public Holding GetByPortfolioAndAsset(string portfolioId, string assetId)
        {
            return dbSet
                .FirstOrDefault(h => h.PortfolioId == portfolioId && h.AssetId == assetId);
        }
    }
}
