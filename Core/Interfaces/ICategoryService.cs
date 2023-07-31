using Core.Entities;

namespace Core.Interfaces
{
	public interface ICategoryService : IService<Category>
	{
		Task<Category> GetSingleCategoryByIdWithProducts(int categoryId);
	}
}
