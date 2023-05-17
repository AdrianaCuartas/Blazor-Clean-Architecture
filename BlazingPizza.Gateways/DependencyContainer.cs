using HttpMessageHandlers;

namespace BlazingPizza.Gateways;
public static class DependencyContainer
{

    // la aplicacion NetMaui con el emulador android tiene problemas con el certicado por ser https. no lo pude validar
    //uan forma de solucionarlo es omitir la comprobacion del certicado: el HttpMessageHandler es el que se encarga de manipular los
    //mensajes, HttpMessageHandler se dispara cada vez que se realice una peticion  para manejar el mensaje

    //El truco es que al HttpClient se le señale que utilice un handler y este le va a decir que el certicado esta correcto:
    // Al servicio llega un delegado que recibe un IHttpClientBuilder : Action<IHttpClientBuilder> 
    // con la direccion del metodo es para ejecutarla y  agregar el HttpHanlder

    public static IServiceCollection AddBlazingPizzaWebApiGateways(
        this IServiceCollection services,
       IOptions<EndpointsOptions> endpointsOptions,
        Action<IHttpClientBuilder> httpClientConfigurator = null)
    {
        //se obtiene el constructor el http:  IHttpClientBuilder
        IHttpClientBuilder Builder =
             services.AddHttpClient<IBlazingPizzaWebApiGateway, //para crear la fabrica de httpclient:
            BlazingPizzaWebApiGateway>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(
                    endpointsOptions.Value.WebApiBaseAddress);
                return new BlazingPizzaWebApiGateway(httpClient, endpointsOptions);
            })
            .AddHttpMessageHandler(() => new ExceptionDelegatingHandler());

        //se invoca al delegado
        httpClientConfigurator?.Invoke(Builder);

        return services;
    }
}



