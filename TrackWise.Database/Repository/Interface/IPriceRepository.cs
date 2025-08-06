using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository.Interface
{
    public interface IPriceRepository: IRepository<Price>
    {
        bool Exists(string assetId, DateTime date);
        decimal GetLatestPrice(string assetId);
        void DeleteByAssetId(string assetId);
    }
}
