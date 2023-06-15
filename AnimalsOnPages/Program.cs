using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Repositories;
using AnimalsOnPages.Resources;
using AnimalsOnPages.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAnimalsService, AnimalsService>();
builder.Services.AddScoped<IAnimalsRepository, AnimalsRepository>();
builder.Services.AddScoped<IZoosService, ZoosService>();
builder.Services.AddScoped<IZoosRepository, ZoosRepository>();
builder.Services.AddScoped<IAddressesService, AddressesService>();
builder.Services.AddScoped<IAddressesRepository, AddressesRepository>();

builder.Services.AddRazorPages()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(Resource));
    });


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCulturesConfig = builder.Configuration.GetSection("SupportedCultures").Get<List<string>>();
    var supportedCultures = supportedCulturesConfig.Select(c => new CultureInfo(c)).ToList();

    options.DefaultRequestCulture = new RequestCulture(supportedCulturesConfig[0]);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var databaseConnectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AnimalsDdContext>(opts =>
opts.UseSqlServer(databaseConnectionString));

var app = builder.Build();

await DataBaseInitializer.InitializeDatabaseAsync(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseRequestLocalization();

app.Run();
