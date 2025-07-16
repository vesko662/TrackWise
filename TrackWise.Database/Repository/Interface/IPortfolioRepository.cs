using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository.Interface
{
    public interface IPortfolioRepository :IRepository<Portfolio>
    {
        void Save();
    }
}
