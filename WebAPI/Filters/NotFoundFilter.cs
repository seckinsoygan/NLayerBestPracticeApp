﻿using Core.Dtos.ResponseDtos;
using Core.Entities.Shared;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters
{
	public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
	{
		private readonly IService<T> _service;

		public NotFoundFilter(IService<T> service)
		{
			_service = service;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var idValue = context.ActionArguments.Values.FirstOrDefault();
			if (idValue == null)
			{
				await next.Invoke();
				return;
			}

			var id = (int)idValue;
			var anyEntity = _service.AnyAsync(x => x.Id == id);

			if (anyEntity != null)
			{
				await next.Invoke();
				return;
			}
			context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found."));
		}
	}
}
