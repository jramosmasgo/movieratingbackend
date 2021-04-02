using Microsoft.EntityFrameworkCore;
using MovieRating.Context;
using MovieRating.Entities;
using MovieRating.Repository.IRepository;

namespace MovieRating.Repository
{
    public class CategoryRepositoryAsync : GenericRepositoryAsync<Category> , ICategoryRepositoryAsync
    {
        private readonly DbSet<Category> _category;

        public CategoryRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            _category = context.Set<Category>();
        }
    }
}
