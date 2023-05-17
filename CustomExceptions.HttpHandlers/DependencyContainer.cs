using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace CustomExceptions.HttpHandlers;

public static class DependencyContainer
{
    //es metodo es para cuando los manejadores de excepcion esten en otro ensamblado
    public static IServiceCollection AddHttpExceptionHandlersServices(this IServiceCollection services,
        Assembly exceptionHandlersAssembly)
    {
        services.AddSingleton<IHttpExceptionHandlerHub>
            (provider => new HttpExceptionHandleHub(exceptionHandlersAssembly));
        return services;
    }

    //este medodo es util cuando los manejadores de excepcion esten en el mismo ensamblado:
    public static IServiceCollection AddHttpExceptionHandlersServices(
        this IServiceCollection services) =>
        AddHttpExceptionHandlersServices(services, Assembly.GetExecutingAssembly());


    //para permitir utilizar el middleware creado HttpExceptionHandlerMiddleware
    public static IApplicationBuilder UseHttpExceptionHandlerMiddleware(
           this IApplicationBuilder app,
           IHostEnvironment environment, // para la informacion del ambiente 
           IHttpExceptionHandlerHub hub)
    {
        //se recibe el contexto y el siguiente middleware
        app.Use((context, next) =>
                HttpExceptionHandlerMiddleware.WriteResponse(context,
                environment.IsDevelopment(), hub));

        return app;
    }

    public static IApplicationBuilder UseHttpExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(builder =>
          builder.UseHttpExceptionHandlerMiddleware(
              app.ApplicationServices.GetRequiredService<IHostEnvironment>(),
              //el Environment es una implementacion de webapplication por ello se cambia a obtener el servicio 
              app.ApplicationServices.GetRequiredService<IHttpExceptionHandlerHub>()));
        return app;
    }
}
