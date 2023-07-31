using Core.Dtos;
using Core.Dtos.ResponseDtos;
using Core.Entities;

namespace Core.Interfaces
{
	public interface IProductService : IService<Product>
	{
		Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();
	}
}
