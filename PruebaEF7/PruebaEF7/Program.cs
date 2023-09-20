using Db;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers().AddJsonOptions(x => {
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
}) ;

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConcesionarioDbContext>(opciones =>
opciones.UseSqlServer("Server=localhost,38001;Database=Concesionario;Persist Security Info=True;User ID=sa;Password=Jorge21176439;TrustServerCertificate=True;Encrypt=False;MultiSubnetFailover=True")
);

builder.Services.AddScoped<MarcaService>();
builder.Services.AddScoped<VehiculoService>();
builder.Services.AddScoped<PreguntaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
