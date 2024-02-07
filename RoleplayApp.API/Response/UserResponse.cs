namespace RoleplayApp.API.Response
{
    public class UserResponse
    {
        public required string Email { get; set; } 
        public required string Password { get; set; }
        public ProfileResponse Profile { get; set; }
    }
}
