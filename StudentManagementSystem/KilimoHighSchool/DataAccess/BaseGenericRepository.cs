using KilimoHighSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace KilimoHighSchool.DataAccess
{
    public class BaseGenericRepository<T> : IBaseGenericRepository<T> where T : BaseEntity
    {
      
        protected readonly IUnitOfWork Uow;
        public BaseGenericRepository(IUnitOfWork uow)
        {
             Uow = uow;    
        }

        public async Task Add(T entity)
        {
            await Uow.Context.AddAsync(entity);
            await Uow.Context.SaveChangesAsync();
        }
        public void Delete(T entity)
        {
            Uow.Context.Remove(entity);
            Uow.Context.SaveChanges();
        }
        public IQueryable<T> GetSet()
        {
            var res = Uow.Context.Set<T>()
                .AsNoTracking();
            return res;
        }
    }
}
