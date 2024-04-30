using System.ComponentModel.DataAnnotations;

namespace CoreMomentum.Services.AdminsAPI.Models
{
    public class AdminsFilesDto
    {
        public int Id { get; set; }
        public string AdminsId { get; set; }
        public string AdminsFile { get; set; }
        public string FileType { get; set; }
        public string FileDescription { get; set; }

    }
}
