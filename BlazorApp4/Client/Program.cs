global using Microsoft.AspNetCore.Components.Authorization;
using BlazorApp4.Client;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using BlazorApp4.Client.Services.UserService;
using BlazorApp4.Client.Services.CakeService;
using BlazorApp4.Client.Services.RecipeService;
using Microsoft.Extensions.Options;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7197/") });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICakeService, CakeService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
