namespace CoreMomentum.Web.Utility
{
    public class SD
    {
        public static string StudentAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }
        public static string AdminsAPIBase { get; set; }

        public const string RoleAdmin = "ADMIN";
        public const string RoleStudent = "STUDENT";
        public const string RoleTeacher = "TEACHER";
        public const string TokenCookie = "JWTToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
