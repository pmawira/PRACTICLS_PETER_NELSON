using KilimoHighSchool.DataAccess;
using KilimoHighSchool.Models;

namespace KilimoHighSchool.Features.Students.Database
{
    public interface IStudentRepository: IBaseGenericRepository<Student>
    {
        public IQueryable<Student> GetByAdmissionNumber(string admissionNumber, CancellationToken cancellationToken);
        Task Update(string admissionNumber, Student entity, CancellationToken cancellationToken);
    }
}
