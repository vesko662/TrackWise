using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Dto.PortfolioDto;
using TrackWise.Models.Dto.TransactionDtos;

namespace TrackWise.Services.Interfaces
{
    public interface ITransactionService
    {
        public void AddTransaction(TransactionCreateDto transaction);
    }
}
