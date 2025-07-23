using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Database.Repository;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Dto.CurrencyDto;
using TrackWise.Models.Dto.PortfolioDto;
using TrackWise.Models.Entities;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository portfolioRep;
        private readonly IMapper mapper;
        public PortfolioService(IPortfolioRepository portfolioRep, IMapper mapper)
        {
            this.portfolioRep = portfolioRep;
            this.mapper = mapper;
        }

        public void AddPortfolio(PortfolioCreateDto portfolio, string userId)
        {
            var mappedPortfolio = mapper.Map<Portfolio>(portfolio);
            mappedPortfolio.UserId = userId;
            portfolioRep.Add(mappedPortfolio);
            portfolioRep.Save();
        }

        public void DeletePortfolio(string id, string userId)
        {
            portfolioRep.Delete(portfolioRep.Get(x => x.Id == id && x.UserId==userId));
            portfolioRep.Save();
        }

        public PortfolioDto GetPortfolio(string id, string userId)
        {
            return mapper.Map<PortfolioDto>(portfolioRep.Get(x => x.Id == id && x.UserId == userId));
        }

        public PortfolioUpdateDto GetPortfolioForEdit(string id, string userId)
        {
            return mapper.Map<PortfolioUpdateDto>(portfolioRep.Get(x => x.Id == id && x.UserId == userId));
        }

        public IEnumerable<PortfolioDto> GetPortfolios(string userId)
        {
            return portfolioRep.GetAll().Where(x=>x.UserId==userId).Select(s => mapper.Map<PortfolioDto>(s)).ToList();
        }

        public void UpdatePortfolio(PortfolioUpdateDto portfolio, string userId)
        {

            var existing = portfolioRep.Get(p => p.Id == portfolio.Id && p.UserId == userId);
          //  if (existing == null)
          //      throw new KeyNotFoundException("Portfolio not found or access denied.");

            mapper.Map(portfolio, existing);
            existing.UserId = userId; 

            portfolioRep.Update(existing);
            portfolioRep.Save();
    }
}
}
