using Microsoft.EntityFrameworkCore;
using MovieRating.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRating.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        entry.Entity.Status = true;
                        break;

                    case EntityState.Modified:
                        entry.Entity.Modified = DateTime.UtcNow;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
            });

            builder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");
            });

            builder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");
            });

            builder.Entity<MovieActor>(entity =>
            {
                entity.ToTable("MovieActor");
            });

            builder.Entity<User>(entity =>
            {
                entity.ToTable("User");
            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
            });
        }
    }
}
