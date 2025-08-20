using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TrackWise.Models.Dto.PortfolioDto
{
    public class PortfolioIndexViewModel
    {
        [ValidateNever]
        public IEnumerable<PortfolioDto> Portfolios { get; set; } 
        public PortfolioCreateDto CreateDto { get; set; } 
    }
}
