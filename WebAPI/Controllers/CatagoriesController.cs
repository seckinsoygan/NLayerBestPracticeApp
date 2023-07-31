using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Shared;

namespace WebAPI.Controllers
{

	public class CatagoriesController : CustomBaseController
	{
		private readonly ICategoryService _service;

		public CatagoriesController(ICategoryService service)
		{
			_service = service;
		}

		[HttpGet("[action]/{categoryId}")]
		public async Task<IActionResult> GetSingleCategoryWithProducts(int id)
		{
			return CreateActionResult(await _service.GetSingleCategoryByIdWithProducts(id));
		}




	}
}
