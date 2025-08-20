using TrackWise.Models.Dto.PortfolioDto;

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
