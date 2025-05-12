using AutoService.UI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AutoService.UI.Services;
using AutoService.UI.Services.Implementation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5273") });

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IWorkService, WorkService>();
builder.Services.AddScoped<IWorkHourEstimationService, WorkHourEstimationService>();

await builder.Build().RunAsync();
