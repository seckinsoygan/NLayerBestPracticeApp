using AutoMapper;
using Core.Dtos;
using Core.Dtos.ResponseDtos;
using Core.Entities;
using Core.Interfaces;
using Core.UnitOfWorks;

namespace Service.Services
{
	public class CategoryService : Service<Category>, ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;
		public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProducts(int categoryId)
		{
			var category = await _categoryRepository.GetSingleCategoryByIdWithProducts(categoryId);
			var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);
			return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
		}
	}
}
