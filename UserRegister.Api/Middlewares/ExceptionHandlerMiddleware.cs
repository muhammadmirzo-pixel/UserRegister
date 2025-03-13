using UserRegister.Api.Models;
using UserRegister.Service.Exceptions;

namespace UserRegister.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate requestDelegate;

    public ExceptionHandlerMiddleware(RequestDelegate requestDelegate)
    {
        this.requestDelegate = requestDelegate;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await this.requestDelegate(context);
        }
        catch (CustomException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = ex.StatusCode,
                Message = ex.Message
            });
        }
        catch(Exception ex)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = 500,
                Message = ex.Message
            });
        }
    }
}
