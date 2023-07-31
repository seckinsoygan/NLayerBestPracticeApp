using AutoMapper;
using Core.Dtos;
using Core.Dtos.ResponseDtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Shared;

namespace WebAPI.Controllers
{
	public class ProductsController : CustomBaseController
	{
		private readonly IMapper _mapper;
		private readonly IService<Product> _service;
		private readonly IProductService _productService;
		public ProductsController(IMapper mapper, IService<Product> service, IProductService productService)
		{
			_mapper = mapper;
			_service = service;
			_productService = productService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var products = await _service.GetAllAsync();
			var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
			return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var product = await _service.GetByIdAsync(id);
			var productDto = _mapper.Map<ProductDto>(product);
			return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
		}
		[HttpPost()]
		public async Task<IActionResult> Add(ProductDto productDto)
		{
			var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
			var productsDto = _mapper.Map<ProductDto>(product);
			return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productDto));
		}
		[HttpPut()]
		public async Task<IActionResult> Update(ProductDto productDto)
		{
			await _service.UpdateAsync(_mapper.Map<Product>(productDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Success(201));
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var product = await _service.GetByIdAsync(id);
			await _service.RemoveAsync(product);
			return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
		}
		[HttpGet("[action]")]
		public async Task<IActionResult> GetProductsWithCategory()
		{
			return CreateActionResult(await _productService.GetProductsWithCategory());
		}
	}
}
