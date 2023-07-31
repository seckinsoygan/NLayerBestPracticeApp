using Core.Dtos;
using Core.Dtos.ResponseDtos;
using Core.Entities;

namespace Core.Interfaces
{
	public interface ICategoryService : IService<Category>
	{
		Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProducts(int categoryId);
	}
}
