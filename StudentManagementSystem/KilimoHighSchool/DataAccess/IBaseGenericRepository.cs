using KilimoHighSchool.Models;

namespace KilimoHighSchool.DataAccess
{
    public interface IBaseGenericRepository<T> 
    {
        public Task Add(T entity);
        public void Delete(T entity);
        public IQueryable<T> GetSet();

    }
}
