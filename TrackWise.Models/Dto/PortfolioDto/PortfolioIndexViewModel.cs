using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Dto.PortfolioDto
{
    public class PortfolioIndexViewModel
    {
        [ValidateNever]
        public IEnumerable<PortfolioDto> Portfolios { get; set; } 
        public PortfolioCreateDto CreateDto { get; set; } 
    }
}
