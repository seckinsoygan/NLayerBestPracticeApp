using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.UnitOfWorks;

namespace Service.Services
{
	public class ProductService : Service<Product>, IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;
		public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
		{
			_mapper = mapper;
			_productRepository = productRepository;
		}

		public async Task<List<ProductWithCategoryDto>> GetProductsWithCategory()
		{
			var products = await _productRepository.GetProductsWithCategory();
			var productDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
			return productDto;
		}
	}
}
