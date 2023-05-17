var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var Endpoints = builder.Configuration.GetSection(EndpointsOptions.SectionKey)
    .Get<EndpointsOptions>();

builder.Services.Configure<EndpointsOptions>(options =>
  options = Endpoints);

builder.Services.AddBlazingPizzaFrontendServices(
    Options.Create(Endpoints), builder.Configuration["geoapifyApiKey"]);


//builder.Services.AddBlazingPizzaFrontendServices(
//    builder.Configuration.GetSection("BlazingPizzaEndpoints")
//    .Get<EndpointsOptions>());

await builder.Build().RunAsync();
