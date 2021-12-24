using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TicTacToe.Shared.Exceptions;

namespace TicTacToe.Api.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //code placed before the _next call happen on the way into the pipeline
                await _next(context);
                //code placed after the _next call, happen on the way out of the pipeline
            }
            catch (Exception err)
            {
                // Get the response object so we can edit it
                var response = context.Response;
                response.ContentType = "application/json";
                string errorMessage;

                switch (err)
                {
                    case IllegalMove e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorMessage = e.Message;
                        break;
                    case NotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        errorMessage = e.Message;
                        break;
                    case DbUpdateException: // Handles DbUpdateConcurrencyExceptions as well
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorMessage = "We're sorry, we were unable to complete your request, please try again later";
                        break;
                    case PostgresException: // Handles database connection exceptions
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorMessage = "We're sorry, we were unable to complete your request, please try again later";
                        break;
                    default: // Some unknown error. We want to prevent generic 500 errors from being returned.
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorMessage = "We're sorry, you're request could not be completed";
                        break;
                }

                // Return the response
                var result = JsonSerializer.Serialize(new { message = errorMessage });
                await response.WriteAsync(result);
            }
        }
    }
}
