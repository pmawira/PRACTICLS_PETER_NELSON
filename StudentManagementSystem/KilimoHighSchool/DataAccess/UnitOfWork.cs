using KilimoHighSchool.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace KilimoHighSchool.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public KilimoSchoolDbContext Context { get; }

        public UnitOfWork(KilimoSchoolDbContext context)
        {
            Context = context;
        }  

        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }
    }

}
