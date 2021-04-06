using MovieRating.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieRating.Repository.IRepository
{
    public interface IGenericRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T,object>>[] includes);
        Task<IEnumerable<T>> GetAllAsyncFilters(Expression<Func<T, bool>> filters);
        Task<T> AddAync(T entity);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter);
    }
}
