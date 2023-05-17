using BlazingPizza.BusinessObjects.ValueObjects;
using BlazingPizza.Frontend.IoC;
using BlazingPizza.MAUIClient.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BlazingPizza.MAUIClient;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();

        using var Stream = FileSystem.OpenAppPackageFileAsync(
            "appsettings.json").Result;
        builder.Configuration.AddJsonStream(Stream);

        string ConfigurationSection;

#if ANDROID
        ConfigurationSection = "android";
#else
    ConfigurationSection = "others";
#endif
        EndpointsOptions options =
            builder.Configuration.GetSection(
                $"BlazingPizzaEndpoints:{ConfigurationSection}")
            .Get<EndpointsOptions>();

        Action<IHttpClientBuilder> Configurator;
#if ANDROID || IOS
        Configurator = configurator =>
        {
            Services.HttpsClientHandlerService HandlerService =
            new Services.HttpsClientHandlerService();
            configurator.ConfigurePrimaryHttpMessageHandler(() =>
            HandlerService.GetPlatformMessageHandler());
        };
#else
    Configurator = null;
#endif

        builder.Services.AddBlazingPizzaFrontendServices(options, Configurator);

        return builder.Build();
    }
}
