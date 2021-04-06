using Microsoft.EntityFrameworkCore;
using MovieRating.Context;
using MovieRating.Entities;
using MovieRating.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieRating.Repository
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : BaseEntity 
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<T> AddAync(T entity)
        {
            await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _entity.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsyncFilters(Expression<Func<T, bool>> filters)
        {
            return await _entity.Where(filters).ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return await _entity.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entity.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = _entity.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
