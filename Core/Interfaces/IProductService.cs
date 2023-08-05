using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductService : IService<Product>
    {
        Task<List<ProductWithCategoryDto>> GetProductsWithCategory();
    }
}
