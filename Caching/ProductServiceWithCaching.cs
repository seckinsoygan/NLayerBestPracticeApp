using AutoMapper;
using Core.Dtos;
using Core.Dtos.ResponseDtos;
using Core.Entities;
using Core.Interfaces;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Service.Exceptions;
using System.Linq.Expressions;

namespace Caching
{
	public class ProductServiceWithCaching : IProductService
	{
		private const string CacheProductKey = "productsCache";
		private readonly IMapper _mapper;
		private readonly IMemoryCache _memoryCache;
		private readonly IProductRepository _repository;
		private readonly IUnitOfWork _unitofWork;

		public ProductServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, IProductRepository repository, IUnitOfWork unitofWork)
		{
			_mapper = mapper;
			_memoryCache = memoryCache;
			_repository = repository;
			_unitofWork = unitofWork;

			if (!_memoryCache.TryGetValue(CacheProductKey, out _))
			{
				_memoryCache.Set(CacheProductKey, _repository.GetProductsWithCategory());
			}
		}

		public async Task<Product> AddAsync(Product entity)
		{
			await _repository.AddAsync(entity);
			await _unitofWork.CommitAsync();
			await CacheAllProductsAsync();
			return entity;
		}

		public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
		{
			await _repository.AddRangeAsync(entities);
			await _unitofWork.CommitAsync();
			await CacheAllProductsAsync();
			return entities;
		}

		public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Product>> GetAllAsync()
		{
			return Task.FromResult(_memoryCache.Get<IEnumerable<Product>>(CacheProductKey));
		}

		public Task<Product> GetByIdAsync(int id)
		{
			var product = _memoryCache.Get<List<Product>>(CacheProductKey).FirstOrDefault(x => x.Id == id);
			if (product == null)
			{
				throw new NotFoundException($"{typeof(Product).Name} does not exist");
			}
			return Task.FromResult(product);

		}

		public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
		{
			var products = _memoryCache.Get<IEnumerable<Product>>(CacheProductKey);

			var productsWithCategoryDto = _mapper.Map<List<ProductWithCategoryDto>>(products);

			return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsWithCategoryDto);
		}

		public async Task RemoveAsync(Product entity)
		{
			_repository.Remove(entity);
			await _unitofWork.CommitAsync();
			await CacheAllProductsAsync();
		}

		public async Task RemoveRangeAsync(IEnumerable<Product> entities)
		{
			_repository.RemoveRange(entities);
			await _unitofWork.CommitAsync();
			await CacheAllProductsAsync();
		}

		public async Task UpdateAsync(Product entity)
		{
			_repository.Update(entity);
			await _unitofWork.CommitAsync();
			await CacheAllProductsAsync();
		}

		public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
		{
			return _memoryCache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
		}
		public async Task CacheAllProductsAsync()
		{
			await _memoryCache.Set(CacheProductKey, _repository.GetAll().ToListAsync());
		}
	}
}
