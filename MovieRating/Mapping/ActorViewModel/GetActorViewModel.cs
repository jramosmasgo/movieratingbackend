using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Mapping.ActorViewModel
{
    public class GetActorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageUrl { get; set; }
        public int Gender { get; set; }
    }
}
