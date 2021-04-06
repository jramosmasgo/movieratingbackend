using Microsoft.EntityFrameworkCore;
using MovieRating.Context;
using MovieRating.Entities;
using MovieRating.Repository.IRepository;

namespace MovieRating.Repository
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User> , IUserRepositoryAsync
    {
        private readonly DbSet<User> _user;

        public UserRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            _user = context.Set<User>();
        }
    }
}
