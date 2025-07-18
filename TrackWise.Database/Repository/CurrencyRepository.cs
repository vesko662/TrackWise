using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        private TrackWiseDbContext db;
        public CurrencyRepository(TrackWiseDbContext db) : base(db)
        {
            this.db = db;
        }

    }
}
