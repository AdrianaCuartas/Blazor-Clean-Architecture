
namespace BlazingPizza.WinFormsClient;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        RegisterServices();
    }

    void RegisterServices()
    {
        IServiceCollection Services = new ServiceCollection();
        Services.AddWindowsFormsBlazorWebView();

        IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var Endpoints = Configuration.GetSection(
            EndpointsOptions.SectionKey)
            .Get<EndpointsOptions>();

        Services.Configure<EndpointsOptions>(options =>
         options = Endpoints);

        Services.AddBlazingPizzaFrontendServices(
           Options.Create(Endpoints)
           , Configuration["geoapifyApiKey"]);

        //Services.AddBlazingPizzaFrontendServices(
        //    Configuration.GetSection("BlazingPizzaEndpoints")
        //    .Get<EndpointsOptions>());

        blazorWebView1.HostPage = "wwwroot\\index.html";
        blazorWebView1.Services = Services.BuildServiceProvider();

        //no navega: porque el found esta viendo directamente al index y no esta viendo al 
        //router
        //blazorWebView1.RootComponents.Add<Razor.Views.Pages.Index>("#app");

        //opcion 1: mover app.razor hacia la biblioteca de clases base y desde ahi consumirlo
        //opcion 2:es crear el app.rzor ala proyecto winforms
        blazorWebView1.RootComponents.Add<App>(
                     "#app");
    }
}
