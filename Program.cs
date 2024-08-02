using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor___WebAssembly;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration.GetValue<string>("apiURL");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://dummyjson.com/c/d433-e088-49bd-8623") });

builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();

await builder.Build().RunAsync();