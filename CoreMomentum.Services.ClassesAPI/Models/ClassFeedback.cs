using System.ComponentModel.DataAnnotations;

namespace CoreMomentum.Services.ClassesAPI.Models
{
    public class ClassFeedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Feedback { get; set; }
        [Required]
        public int TeacherId { get; set; }
    }
}
