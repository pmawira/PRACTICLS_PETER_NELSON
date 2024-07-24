using KilimoHighSchool.DataAccess;
using KilimoHighSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace KilimoHighSchool.Features.Students.Database
{
    public class StudentRepository : BaseGenericRepository<Student>, IStudentRepository
    {

        public StudentRepository(IUnitOfWork uow) : base(uow)
        {
        }

        // Get student by their admission number  
        public IQueryable<Student> GetByAdmissionNumber(string admissionNumber, CancellationToken cancellationToken)
        {
            return Uow.Context.Set<Student>()
                 .AsNoTracking()
                 .Where(x => x.AdmissionNumber == admissionNumber);
        }
        public async Task Update(string admissionNumber, Student entity, CancellationToken cancellationToken)
        {
            var existingEntity = GetByAdmissionNumber(admissionNumber, cancellationToken);
            if (existingEntity == null)
            {
                throw new Exception("Entity not found");
            }

            Uow.Context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await Uow.Context.SaveChangesAsync(cancellationToken);
        }
    }
}
