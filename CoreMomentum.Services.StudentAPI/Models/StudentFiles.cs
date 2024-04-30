using System.ComponentModel.DataAnnotations;

namespace CoreMomentum.Services.StudentAPI.Models
{
    public class StudentFiles
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        public string StudentFile { get; set; }
        [Required]
        public string FileDescription { get; set; }
    }
}
