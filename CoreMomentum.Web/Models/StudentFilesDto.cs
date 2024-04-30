using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CoreMomentum.Web.Models
{
    public class StudentFilesDto
    {
        [Key]
        public int Id { get; set; }
        [ValidateNever]
        public string StudentId { get; set; }
        [ValidateNever]
        public string StudentFile { get; set; }
        [Required]
        public string FileDescription { get; set; }

    }
}
