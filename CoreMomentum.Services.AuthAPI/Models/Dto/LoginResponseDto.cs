namespace CoreMomentum.Services.AuthAPI.Models.Dto
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
        public string Result { get; set; } = "";
    }
}
