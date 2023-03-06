using System;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using NZ_Walks.Models.Dto;

namespace NZ_Walks.Exceptions
{
	public static class ExceptionMiddlewareExtension
	{
		public static void ConfigureBuildExceptionHandler(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(error => {
				error.Run(async context => {
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = "application/json";

					var feature = context.Features.Get<IExceptionHandlerFeature>();
					var request = context.Features.Get<IHttpRequestFeature>();

					if (feature != null) {
						await context.Response.WriteAsync(new Error(){
							StatusCode = context.Response.StatusCode,
							Message = feature.Error.Message,
							Path = request.Path
						}.ToString());
					}
				});
			});
		}
	}
}

