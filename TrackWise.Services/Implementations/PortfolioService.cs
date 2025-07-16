using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class PortfolioService :IPortfolioService
    {
        private readonly IPortfolioRepository portfolioRep;

        public PortfolioService(IPortfolioRepository portfolioRep)
        {
            this.portfolioRep = portfolioRep;
        }

        public void AddPortfolio(Portfolio portfolio)
        {
            portfolioRep.Add(portfolio);
        }

        public IEnumerable<Portfolio> GetPortfolios()
        {
            return portfolioRep.GetAll();
        } 
    }
}
