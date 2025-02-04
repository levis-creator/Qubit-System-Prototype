using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.EntityFrameworkCore;
using QubitSys.Components;
using QubitSys.Data;
using QubitSys.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    }).AddBootstrapProviders()
    .AddFontAwesomeIcons();
builder.Services.AddDbContext<DataDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddContracts();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
