// PL.Core/Interfaces/IRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace test_lbs.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllAsQueryable();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task<T> CreateAsync(T entity);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);
        Task UpdateAsync(T entity);
        Task<T> UpdatedAsync(T entity);
        Task UpdateAllAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);

        Task AddWithoutSaveAsync(T entity);
        void UpdateWithoutSave(T entity);
        void DeleteWithoutSave(T entity);
        Task SaveChangesAsync();

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetQueryable();

        DbContext Context { get; }
    }
}