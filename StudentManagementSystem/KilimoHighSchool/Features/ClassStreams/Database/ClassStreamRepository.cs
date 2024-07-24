using KilimoHighSchool.DataAccess;
using KilimoHighSchool.Features.Students.Database;
using KilimoHighSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace KilimoHighSchool.Features.ClassStreams.Database
{
    public class ClassStreamRepository : BaseGenericRepository<ClassStream>, IClassStreamRepository
    {

        public ClassStreamRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public IQueryable<ClassStream> GetByStreamName(string streamName, CancellationToken cancellationToken)
        {
            return Uow.Context.Set<ClassStream>()
              .AsNoTracking()
              .Where(x => x.Name == streamName);
        }
        public async Task Update(string streamName, Student entity, CancellationToken cancellationToken)
        {
            var existingEntity = GetByStreamName(streamName, cancellationToken);
            if (existingEntity == null)
            {
                throw new Exception("Entity not found");
            }

            Uow.Context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await Uow.Context.SaveChangesAsync(cancellationToken);
        }
    }
}
