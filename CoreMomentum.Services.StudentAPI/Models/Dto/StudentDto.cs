using System.ComponentModel.DataAnnotations;

namespace CoreMomentum.Services.StudentAPI.Models.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public int HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string email { get; set; }
        public string PassportNumber { get; set; }
        public string PersonalId { get; set; }
    }
}
