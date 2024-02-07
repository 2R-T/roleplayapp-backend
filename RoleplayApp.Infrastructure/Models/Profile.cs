using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Infrastructure.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public required string First_name { get; set; }
        public required string Last_name { get; set; }
        public required string Username { get; set; }
        public required DateOnly Birth_date { get; set; }
        public required DateOnly Created_at { get; set; }
        public required string Profile_picture { get; set; }

        //Relationships
        public required int User_id { get; set; }
        public required Biography Biography { get; set; }
        public ICollection<WallComments>? WallComments { get; set; }
      
    }
}
