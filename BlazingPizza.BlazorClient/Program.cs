using Membership.Blazor.IoC;
using Membership.Blazor.WebApiGateway;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//una forma 1: se realiza el configure en el program
var Endpoints = builder.Configuration.GetSection(EndpointsOptions.SectionKey)
    .Get<EndpointsOptions>();

builder.Services.Configure<EndpointsOptions>(options =>
  options = Endpoints);
//


builder.Services.AddBlazingPizzaFrontendServices(
    Options.Create(Endpoints), builder.Configuration["geoapifyApiKey"]);

//una forma 2: se realiza el configure en el IoC, se envia un delegado al Ioc
builder.Services.AddMembershipBlazorServices(
    userEndpoints => builder.Configuration.GetSection(UserEndpointsOptions.SectionKey)
    .Bind(userEndpoints));


//builder.Services.AddBlazingPizzaFrontendServices(
//    builder.Configuration.GetSection("BlazingPizzaEndpoints")
//    .Get<EndpointsOptions>());

await builder.Build().RunAsync();
