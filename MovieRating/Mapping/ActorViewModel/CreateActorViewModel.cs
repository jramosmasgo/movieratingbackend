using System;

namespace MovieRating.Mapping.ActorViewModel
{
    public class CreateActorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageUrl { get; set; }
        public int Gender { get; set; }
    }
}
