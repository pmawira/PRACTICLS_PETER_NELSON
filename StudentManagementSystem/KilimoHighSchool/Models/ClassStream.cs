using System.ComponentModel.DataAnnotations;

namespace KilimoHighSchool.Models
{
    public record ClassStream: BaseEntity
    {
        [MaxLength(20)]

        public required string Name { get; set; }
        public int NumberOfStudents { get; set; }
        [MaxLength(100)]

        public string? Description { get; set; }
        // Navigation property for the related Student
        public Student Student { get; set; }
    }
}
