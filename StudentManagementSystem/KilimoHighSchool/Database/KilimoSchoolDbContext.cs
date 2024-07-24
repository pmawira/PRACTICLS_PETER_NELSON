using KilimoHighSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace KilimoHighSchool.Database
{
    public class KilimoSchoolDbContext: DbContext
    {
        public KilimoSchoolDbContext(DbContextOptions<KilimoSchoolDbContext> options)
     : base(options)
        {
            // TODO configure logger
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassStream> Streams { get; set; }
    }
}
