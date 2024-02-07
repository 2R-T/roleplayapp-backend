using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Infrastructure.Models
{
    public class Biography
    {
        public int Id { get; set; }
        public required string Biography_script { get; set; } = "No biography yet";
        public required DateTime Biography_updated_at { get; set; } = DateTime.Now;

        //Relationships
        public required int Profile_id { get; set; }
    }
}
