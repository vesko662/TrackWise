using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository.Interface
{
    public interface IExchangeRepository:IRepository<Exchange>
    {
        public void AddRange(IEnumerable<Exchange> exchanges);

    }
}
