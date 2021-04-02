using Microsoft.EntityFrameworkCore;
using MovieRating.Context;
using MovieRating.Entities;
using MovieRating.Repository.IRepository;

namespace MovieRating.Repository
{
    public class MovieRepositoryAsync : GenericRepositoryAsync<Movie> , IMovieRepositoryAsync 
    {
        private readonly DbSet<Movie> movie;

        public MovieRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            movie = context.Set<Movie>();
        }
    }
}
