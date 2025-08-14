using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;

namespace TrackWise.Database.Repository
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(TrackWiseDbContext db) : base(db)
        {
            
        }

        public override IEnumerable<Transaction> GetWhere(Expression<Func<Transaction, bool>> filter)
        {
            IQueryable<Transaction> query = dbSet.Where(filter).Include(x=>x.Asset);
            return query.ToList();
        }
    }
}
