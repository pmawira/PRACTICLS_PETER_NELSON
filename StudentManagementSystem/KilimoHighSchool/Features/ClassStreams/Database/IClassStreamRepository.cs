using KilimoHighSchool.DataAccess;
using KilimoHighSchool.Models;

namespace KilimoHighSchool.Features.ClassStreams.Database
{
    public interface IClassStreamRepository: IBaseGenericRepository<ClassStream>
    {
        public IQueryable<ClassStream> GetByStreamName(string streamName, CancellationToken cancellationToken);
        Task Update(string streamName, Student entity, CancellationToken cancellationToken);
    }
}
