using System.Linq.Expressions;

namespace Core.Interfaces
{
	public interface IService<T> where T : class
	{
		Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
		IQueryable<T> Where(Expression<Func<T, bool>> expression);
		bool AnyAsync(Expression<Func<T, bool>> expression);
		Task AddRangeAsync(IEnumerable<T> entities);
		Task<T> AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task RemoveAsync(T entity);
	}
}
