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
    public class PortfolioService :IPortfolioService
    {
        private readonly IPortfolioRepository portfolioRep;
        private readonly IMapper mapper;
        public PortfolioService(IPortfolioRepository portfolioRep, IMapper mapper)
        {
            this.portfolioRep = portfolioRep;
            this.mapper = mapper;
        }

        public void AddPortfolio(PortfolioCreateDto portfolio)
        {
            var mappedPortfolio = mapper.Map<Portfolio>(portfolio);

            portfolioRep.Add(mappedPortfolio);
            portfolioRep.Save();
        }

        public IEnumerable<PortfolioDto> GetPortfolios()
        {
            return portfolioRep.GetAll().Select(s => mapper.Map<PortfolioDto>(s)).ToList(); 
        } 
    }
}
