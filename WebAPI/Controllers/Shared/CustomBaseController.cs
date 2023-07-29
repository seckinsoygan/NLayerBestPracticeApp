﻿using Core.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Shared
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomBaseController : ControllerBase
	{
		[NonAction]
		public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
		{
			if (response.StatusCode == 204)
			{
				return new ObjectResult(null)
				{
					StatusCode = response.StatusCode,
				};
			}
			return new ObjectResult(response)
			{
				StatusCode = response.StatusCode,
			};
		}
	}
}
