using System.Linq.Expressions;


namespace TrackWise.Database.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        public  IEnumerable<T> GetAll();
        public T Get(Expression<Func<T,bool>> filter);
        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> filter);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        void AddRange(IEnumerable<T> entities);
        public void Save();
        public Task SaveAsync();
    }
}
