using MovieRating.Mapping.CategoryViewModel;
using System;

namespace MovieRating.Mapping.MovieViewModel
{
    public class GetMovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Premiere { get; set; }
        public string ImageUrl { get; set; }
        public GetCategoryViewModel Category { get; set; }
    }
}
