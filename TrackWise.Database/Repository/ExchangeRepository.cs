using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository
{
    public class ExchangeRepository : Repository<Exchange>, IExchangeRepository
    {
        public ExchangeRepository(TrackWiseDbContext db) : base(db)
        {
        }

        public void AddRange(IEnumerable<Exchange> exchanges)
        {
           dbSet.AddRange(exchanges);
           Save();
        }
    }
}
