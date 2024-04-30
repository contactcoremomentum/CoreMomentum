using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CoreMomentum.Web.Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        [ValidateNever]
        [Display(Name = "Student Code")]
        public string StudentCode { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Birth Date is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Birth Date [Day-Month-Year][e.g. 29-11-1982]")]
        public DateOnly BirthDate { get; set; }
        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }
        [Display(Name = "House Number")]
        public int HouseNumber { get; set; }
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }
        [Display(Name = "Personal ID")]
        public string PersonalId { get; set; }
    }
}
