using Microsoft.AspNetCore.Identity;

namespace CoreMomentum.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
