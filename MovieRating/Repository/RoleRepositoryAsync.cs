using Microsoft.EntityFrameworkCore;
using MovieRating.Context;
using MovieRating.Entities;
using MovieRating.Repository.IRepository;

namespace MovieRating.Repository
{
    public class RoleRepositoryAsync : GenericRepositoryAsync<Role> , IRoleRepositoryAsync
    {
        private readonly DbSet<Role> _role;

        public RoleRepositoryAsync(ApplicationDbContext context):base(context)
        {
            _role = context.Set<Role>();
        }
    }
}
