using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Entities
{
    public class MovieActor : BaseEntity
    {
        public Actor Actor { get; set; }
        public int ActorId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
    }
}
