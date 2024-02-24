using System.ComponentModel.DataAnnotations;

namespace RoleplayApp.API.Request
{
    public class BiographyRequest
    {
        [Required]
        public string Biography_script { get; set; }
        
    }
}
