using System.ComponentModel.DataAnnotations;

namespace CoreMomentum.Services.ClassesAPI.Models
{
    public class Weekday
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
