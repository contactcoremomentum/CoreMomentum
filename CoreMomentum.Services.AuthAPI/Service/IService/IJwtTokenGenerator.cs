using CoreMomentum.Services.AuthAPI.Models;

namespace CoreMomentum.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
