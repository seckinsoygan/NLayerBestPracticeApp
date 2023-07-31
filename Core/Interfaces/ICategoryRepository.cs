using Core.Entities;

namespace Core.Interfaces
{
	public interface ICategoryRepository : IGenericRepository<Category>
	{
		Task<Category> GetSingleCategoryByIdWithProducts(int categoryId);
	}
}
