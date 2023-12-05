using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GOTCharacterApp;
using GOTCharacterApp.Services;
using GOTCharacterApp.Models;
using System;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app"); // No using directive needed if App.razor is in the root namespace
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://game-of-thrones1.p.rapidapi.com/") // Adjust as necessary
});
builder.Services.AddScoped(sp =>
{
    var client = new HttpClient { BaseAddress = new Uri("https://game-of-thrones1.p.rapidapi.com") };
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "a9ce5172f3mshd6274a44109040dp1d5c77jsnc66eb10bf81a");
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "game-of-thrones1.p.rapidapi.com");
    return client;
});

builder.Services.AddScoped<GOTService>();

await builder.Build().RunAsync();

