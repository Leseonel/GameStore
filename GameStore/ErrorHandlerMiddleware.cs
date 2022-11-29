using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using System.Text.Json;
using System.Net;
using GameStore.CustomExceptions;

namespace GameStore
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger _logger;
        public ErrorHandlerMiddleware(RequestDelegate request, ILogger<ErrorHandlerMiddleware> logger)
        {
            _request = request;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                ProcessingResponse(error, response);

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
        private void ProcessingResponse(Exception error, HttpResponse response)
        {
            if (error is CustomException)
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            else
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

            _logger.LogError(error.Message);
        }
    }
}
