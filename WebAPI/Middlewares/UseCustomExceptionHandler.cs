using Core.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Diagnostics;
using Service.Exceptions;
using System.Text.Json;

namespace WebAPI.Middlewares
{
	public static class UseCustomExceptionHandler
	{
		public static void UserCustomException(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(config =>
			{
				config.Run(async context =>
				{
					context.Response.ContentType = "application/json";

					var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

					var StatusCode = exceptionFeature.Error switch
					{
						ClientSideException => 400,
						_ => 500
					};
					context.Response.StatusCode = StatusCode;

					var response = CustomResponseDto<NoContentDto>.Fail(StatusCode, exceptionFeature.Error.Message);

					await context.Response.WriteAsync(JsonSerializer.Serialize(response));
				});
			});
		}
	}
}
