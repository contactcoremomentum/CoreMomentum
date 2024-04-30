using System.ComponentModel.DataAnnotations;

namespace CoreMomentum.Services.ClassesAPI.Models.Dto
{
    public class ClassFeedbackDto
    {
        public int Id { get; set; }
        public string Feedback { get; set; }
        public int TeacherId { get; set; }
    }
}
