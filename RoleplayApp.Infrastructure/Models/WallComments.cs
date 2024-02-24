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

        //Relationships
        public required int Sender_id { get; set; }
        public required int Receiver_id { get; set; }
    }
}
