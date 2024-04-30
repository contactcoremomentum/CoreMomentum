namespace CoreMomentum.Services.ClassesAPI.Models
{
    public class ClassWeekdayDto
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int WeekId { get; set; }
        public string Hours { get; set; }

    }
}
