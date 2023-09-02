using AgifyApi.ServiceContracts;
using AgifyApi.ServiceImplementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IAgeService, AgeService>();

var app = builder.Build();


app.UseRouting();
app.MapControllers();


app.Run();