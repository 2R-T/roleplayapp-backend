using System.ComponentModel.DataAnnotations;

namespace RoleplayApp.API.Request
{
    public class WallCommentsRequest
    {
        [Required]
        public string Comment { get; set; }
        [Required]
        public int Sender_id { get; set; }
        [Required]
        public int Receiver_id { get; set; }
    }
}
