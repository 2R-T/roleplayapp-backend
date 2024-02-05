using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Infrastructure.Models
{
    public class WallComments
    {
        public int Id { get; set; }
        public required string Comment { get; set; }
        public required DateTime Created_at { get; set; }
        public required int User_id { get; set; }
        public required User User { get; set; } 
        public required int Profile_id { get; set; }
        public required Profile Profile { get; set; }
    }
}
