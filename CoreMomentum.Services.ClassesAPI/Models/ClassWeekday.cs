using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreMomentum.Services.ClassesAPI.Models
{
    public class ClassWeekday
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClassId { get; set; }
        [ForeignKey("Id")]
        [ValidateNever]
        public Classes Classes { get; set; }
        [Required]
        public int WeekId { get; set; }
        [ForeignKey("Id")]
        [ValidateNever]
        public Weekday Weekday { get; set; }

        [Required]
        public string Hours { get; set; }

    }
}
