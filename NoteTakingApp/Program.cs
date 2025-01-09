using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;  // Make sure this is included
using NoteTakingApp;  // Replace with your project's namespace

var builder = WebApplication.CreateBuilder(args);

// Check if the app is running in WebAssembly (Blazor WASM) or Server-side Blazor
if (builder.Environment.IsDevelopment() || builder.Environment.IsWebAssembly())
{
    // Blazor WebAssembly configuration
    builder.Services.AddMudServices();  // Add MudBlazor services for WebAssembly

    // Add the root component for Blazor WebAssembly
    builder.RootComponents.Add<App>("#app");

    var host = builder.Build();
    await host.RunAsync();  // Run WebAssembly app asynchronously
}
else
{
    // Blazor Server configuration
    builder.Services.AddMudServices();  // Add MudBlazor services for Blazor Server

    builder.Services.AddRazorComponents()
        .AddInteractiveComponents();  // Add server-side Razor components

    var app = builder.Build();

    // Configure HTTP request pipeline for Blazor Server
    app.MapRazorComponents()
        .AddInteractiveComponents();

    app.Run();  // Run Blazor Server app
}

