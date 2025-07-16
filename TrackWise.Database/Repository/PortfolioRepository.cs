using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository
{
    public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
    {
        private TrackWiseDbContext db;
        public PortfolioRepository(TrackWiseDbContext db) : base(db)
        {
            this.db = db;
        }

        public void Save()
        {
           db.SaveChanges();
        }
    }
}
