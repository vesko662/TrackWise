using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Dto.CurrencyDto;

namespace TrackWise.Services.Interfaces
{
    public interface ICurrencyService
    {
        public IEnumerable<CurrencyDto> GetAll();
    }
}
