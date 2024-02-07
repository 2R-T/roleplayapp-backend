using System.ComponentModel.DataAnnotations;

namespace RoleplayApp.API.Request
{
    public class UserRequest
    {
        [Required]
        [MinLength(5)]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        public ProfileRequest Profile { get; set; }
    }
}
