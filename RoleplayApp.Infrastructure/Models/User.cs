namespace RoleplayApp.Infrastructure.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public string? Phone_number { get; set; }
        public string? Country_code { get; set; }
        public Profile? Profile { get; set; } 
        public ICollection<WallComments>? WallComments { get; set; }

    }
}
