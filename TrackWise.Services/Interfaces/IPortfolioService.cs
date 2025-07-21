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

        public PortfolioDto GetPortfolio(Guid id);

        public PortfolioUpdateDto GetPortfolioForEdit(Guid id);

        public void UpdatePortfolio(PortfolioUpdateDto portfolio);
        public void AddPortfolio(PortfolioCreateDto portfolio);

        public void DeletePortfolio(Guid id);
    }
}
