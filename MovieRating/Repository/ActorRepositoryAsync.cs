using Microsoft.EntityFrameworkCore;
using MovieRating.Context;
using MovieRating.Entities;
using MovieRating.Repository.IRepository;

namespace MovieRating.Repository
{
    public class ActorRepositoryAsync : GenericRepositoryAsync<Actor> , IActorRepositoryAsync
    {
        private readonly DbSet<Actor> _actor;

        public ActorRepositoryAsync(ApplicationDbContext context) : base(context) 
        {
            _actor = context.Set<Actor>();
        }
    }
}
