using System.ComponentModel.DataAnnotations;

namespace CoreMomentum.Services.ClassesAPI.Models.Dto
{
    public class ClassesDto
    {
        public int Id { get; set; }
        public string ClassesCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Photolink { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public int HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int CycleId { get; set; }
        public int StudentId { get; set; }
    }
}
