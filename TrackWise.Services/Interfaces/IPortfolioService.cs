using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Dto.PortfolioDto;
using TrackWise.Models.Entities;

namespace TrackWise.Services.Interfaces
{
    public interface IPortfolioService
    {
       public IEnumerable<PortfolioDto> GetPortfolios(string userId);

        public PortfolioDto GetPortfolio(string id, string userId);

        public PortfolioUpdateDto GetPortfolioForEdit(string id, string userId);

        public void UpdatePortfolio(PortfolioUpdateDto portfolio, string userId);
        public void AddPortfolio(PortfolioCreateDto portfolio, string userId);

        public void DeletePortfolio(string id, string userId);
    }
}
