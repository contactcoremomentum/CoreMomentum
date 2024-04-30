using System.ComponentModel.DataAnnotations;

namespace CoreMomentum.Services.AdminsAPI.Models
{
    public class AdminsFiles
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AdminsId { get; set; }
        [Required]
        public string AdminsFile { get; set; }
        [Required]
        public string FileType { get; set; }
        [Required]
        public string FileDescription { get; set; }
    }
}
