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
       public IEnumerable<PortfolioDto> GetPortfolios();

        public PortfolioDto GetPortfolio(string id);

        public PortfolioUpdateDto GetPortfolioForEdit(string id);

        public void UpdatePortfolio(PortfolioUpdateDto portfolio);
        public void AddPortfolio(PortfolioCreateDto portfolio);

        public void DeletePortfolio(string id);
    }
}
