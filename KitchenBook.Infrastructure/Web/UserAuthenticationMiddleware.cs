using KitchenBook.Domain.UserModel;
using KitchenBook.Infrastructure.Data.UserModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.OperationalInsights.Models;
using Newtonsoft.Json;

namespace KitchenBook.Infrastructure.Web;

public class UserAuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly UserRepository _userRepository;

    public UserAuthenticationMiddleware(RequestDelegate next, UserRepository userRepository)
    {
        _next = next;
        _userRepository = userRepository;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.ToString().StartsWith("/v1/users"))
        {
            await _next(context);
            return;
        }

        string login = context.Request.Cookies["Login"];
        if (login == null)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/problem+json";
            var errorResponse = new ErrorResponse();

            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            return;
        }

        string token = context.Request.Cookies["Token"];
        if (token == null)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/problem+json";
            var errorResponse = new ErrorResponse();

            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            return;
        }

        User user = await _userRepository.GetByLogin(login);

        if (user.Token != token)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/problem+json";
            var errorResponse = new ErrorResponse();

            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            return;
        }

        await _next(context);
    }
}
