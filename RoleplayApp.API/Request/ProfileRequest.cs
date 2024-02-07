using RoleplayApp.API.Response;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RoleplayApp.API.Request
{
    public class ProfileRequest
    {
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public DateOnly Birth_date { get; set; }
        [Required]
        public string Profile_picture { get; set; }
        public BiographyRequest Biography { get; set; }
    }
}
