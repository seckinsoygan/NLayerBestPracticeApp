using AutoMapper;
using Core.Dtos;
using Core.Dtos.ResponseDtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Shared;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
	public class ProductsController : CustomBaseController
	{
		private readonly IMapper _mapper;
		private readonly IProductService _productService;
		public ProductsController(IMapper mapper, IProductService productService)
		{
			_mapper = mapper;
			_productService = productService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var products = await _productService.GetAllAsync();
			var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
			return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
		}
		[ServiceFilter(typeof(NotFoundFilter<Product>))]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var product = await _productService.GetByIdAsync(id);
			var productDto = _mapper.Map<ProductDto>(product);
			return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
		}
		[HttpPost()]
		public async Task<IActionResult> Add(ProductDto productDto)
		{
			var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
			var productsDto = _mapper.Map<ProductDto>(product);
			return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productDto));
		}
		[HttpPut()]
		public async Task<IActionResult> Update(ProductDto productDto)
		{
			await _productService.UpdateAsync(_mapper.Map<Product>(productDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Success(201));
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var product = await _productService.GetByIdAsync(id);
			await _productService.RemoveAsync(product);
			return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
		}
		[HttpGet("[action]")]
		public async Task<IActionResult> GetProductsWithCategory()
		{
			return CreateActionResult(await _productService.GetProductsWithCategory());
		}
	}
}
