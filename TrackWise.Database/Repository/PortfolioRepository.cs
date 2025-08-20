using Microsoft.EntityFrameworkCore;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository
{
    public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(TrackWiseDbContext db) : base(db)
        {
        }

        public override IEnumerable<Portfolio> GetAll()
        {
            return dbSet.Include(p => p.Currency).ToList();
        }
    }
}
