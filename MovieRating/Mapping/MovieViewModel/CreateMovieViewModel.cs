using MovieRating.Mapping.CategoryViewModel;
using System;

namespace MovieRating.Mapping.MovieViewModel
{
    public class CreateMovieViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Premiere { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
