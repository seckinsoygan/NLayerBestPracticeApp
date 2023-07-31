using Core.Entities;
using Core.Interfaces;
using WebAPI.Controllers.Shared;

namespace WebAPI.Controllers
{

	public class CatagoriesController : CustomBaseController
	{
		private readonly IService<Category> _service;

	}
}
