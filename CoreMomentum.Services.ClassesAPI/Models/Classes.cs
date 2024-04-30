using System.ComponentModel.DataAnnotations;

namespace CoreMomentum.Services.ClassesAPI.Models
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClassesCode { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int CycleId { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}
