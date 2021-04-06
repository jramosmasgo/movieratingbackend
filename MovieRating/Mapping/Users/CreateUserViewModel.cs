using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Mapping.Users
{
    public class CreateUserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public int RoleId { get; set; }
    }
}
