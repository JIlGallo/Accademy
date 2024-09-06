using Microsoft.EntityFrameworkCore;
using ProgettoContatti.DAL;
using ProgettoContatti.Data;
using ProgettoContatti.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBlazorBootstrap();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<DataProvider>();


var connectionString = builder.Configuration.GetConnectionString("ctx_rubrica") ?? throw new InvalidOperationException("Connection string 'ctx_rubrica' not found.");
builder.Services.AddDbContextFactory<RubricaContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.EnableSensitiveDataLogging();
});

var app = builder.Build();


// voglio lanciare l'EnsureSeeded, ma prima devo ottenere certi oggetti
// Ottengo il gestore dei servizi
var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
var ctx = serviceScope.ServiceProvider.GetService<RubricaContext>();

// Lancio l'EnsureSeeded
if (ctx != null)
    await ctx.EnsureSeedData();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


