using System.ComponentModel.DataAnnotations;

namespace KilimoHighSchool.Models
{
    public record class Student : BaseEntity
    {
        [MaxLength(20)]
        public required string FirstName { get; set; }
        [MaxLength(20)]

        public required string LastName { get; set; }
        [MaxLength(20)]

        public required string AdmissionNumber { get; set; }

        public required Int32 Age { get; set; }
        // Foreign key for ClassStream
        public int ClassStreamId { get; set; }

        // Navigation property for the related ClassStream
        public ClassStream ClassStream { get; set; }
    }
}
