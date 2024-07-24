using KilimoHighSchool.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace KilimoHighSchool.DataAccess
{
    public interface IUnitOfWork
    {
        KilimoSchoolDbContext Context { get; }
        Task SaveChanges(CancellationToken cancellationToken);


    }
}
