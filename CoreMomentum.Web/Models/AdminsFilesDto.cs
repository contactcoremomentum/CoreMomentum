using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CoreMomentum.Web.Models
{
    public class AdminsFilesDto
    {
        public int Id { get; set; }
        [ValidateNever]
        public string AdminsId { get; set; }
        [ValidateNever]
        public string AdminsFile { get; set; }
        [ValidateNever]
        public string FileType { get; set; }
        public string FileDescription { get; set; }

    }
}
