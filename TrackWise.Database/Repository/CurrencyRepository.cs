using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(TrackWiseDbContext db) : base(db)
        {
        }

    }
}
