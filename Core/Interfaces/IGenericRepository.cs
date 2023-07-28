﻿using System.Linq.Expressions;

namespace Core.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetByIdAsync(int id);
		IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
		IQueryable<T> Where(Expression<Func<T, bool>> expression);
		bool AnyAsync(Expression<Func<T, bool>> expression);
		Task AddRangeAsync(IEnumerable<T> entities);
		Task<T> AddAsync(T entity);
		void Update(T entity);
		void Remove(T entity);

	}
}