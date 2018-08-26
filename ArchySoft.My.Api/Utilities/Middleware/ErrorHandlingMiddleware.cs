using ArchySoft.My.Api.Models;
using ArchySoft.My.Logic.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Events;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ArchySoft.My.Api.Utilities.Middleware
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _loger;

		public ErrorHandlingMiddleware(RequestDelegate next, ILogger loger)
		{
			_next = next;
			_loger = loger;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				if (!(ex is BusinessException))
				{
					_loger.Write(LogEventLevel.Error, ex.Message, ex);
				}
				await HandleExceptionAsync(context, ex);
			}
		}

		protected virtual Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			ApiResponse response = new ApiResponse(ApiStatus.Exception);

			if (exception is BusinessException businessException)
			{
				response.Description = businessException.Message;
			}

			string model = JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.OK;

			return context.Response.WriteAsync(model);
		}
	}
}
