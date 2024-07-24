namespace KilimoHighSchool.Models
{
    public record BaseEntity
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
