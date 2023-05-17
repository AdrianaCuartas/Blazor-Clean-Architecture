using CustomExceptions.HttpHandlers;

namespace BlazingPizza.WebApi.Configurations;

internal static class MiddlewaresConfiguration
{
    public static WebApplication ConfigureWebApiMiddlewares(
        this WebApplication app)
    {
        app.UseHttpExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseSpecialsEndpoints();
        app.UseToppingsEndpoints();
        app.UseOrdersEndpoints();
        app.UseUsersEndpoints();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }

    //se paso para el dependency container de CustomExceptions.HttpHandlers
    // static WebApplication UseHttpExceptionHandler(
    // this WebApplication app)
    // {
    // app.UseExceptionHandler(builder =>
    //            app.Environment,
    //            app.Services.GetService<IHttpExceptionHandlerHub>()));
    //    return app;
    //}
}
