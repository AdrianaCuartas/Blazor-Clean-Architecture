using BlazingPizza.Backend.BusinessObjects.ValueObjects.Options;
using BlazingPizza.Backend.IoC;
using BlazingPizza.Desktop.IoC;
using BlazingPizza.Frontend.BusinessObjects.ValueObjects.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BlazingPizza.WPFClient;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        RegisterServices();
    }

    void RegisterServices()
    {
        IConfiguration Configuration = new ConfigurationBuilder()
         .AddJsonFile("appsettings.json")
         .Build();

        IServiceCollection Services = new ServiceCollection();
        Services.AddWpfBlazorWebView();

        var Endpoints = Configuration.GetSection(EndpointsOptions.SectionKey)
            .Get<EndpointsOptions>();

        Services.Configure<EndpointsOptions>(
            options => options = Endpoints);


        Services.Configure<SpecialsOptions>(
               options => options.ImagesBaseUrl = (Configuration.GetSection(SpecialsOptions.SectionKey)
            .Get<SpecialsOptions>()).ImagesBaseUrl);

        var connectionstring = Configuration.GetSection(ConnectionStringsOptions.SectionKey)
            .Get<ConnectionStringsOptions>();

        Services.Configure<ConnectionStringsOptions>(options =>
              options.BlazingPizzaDB = connectionstring.BlazingPizzaDB);

        //Services.AddBlazingPizzaDesktopServices(
        //    Options.Create(Endpoints));

        Services.AddBlazingPizzaBackendServices();
        Services.AddBlazingPizzaDesktopServices();

        //Services.AddBlazingPizzaFrontendServices(
        //    Configuration.GetSection("BlazingPizzaEndpoints")
        //    .Get<EndpointsOptions>());


        //Services.AddBlazingPizzaDesktopServices()
        //    .AddBlazingPizzaBackendServices(
        //    Configuration.GetConnectionString("BlazingPizzaDB"),
        //    Configuration["ImagesBaseUrl"]
        //    );

        Resources.Add("Services", Services.BuildServiceProvider());


    }
}

