using Microsoft.EntityFrameworkCore;
using Programando.CSharp.WebApplication1.Model;


var builder = WebApplication.CreateBuilder(args);

///////////////////////////////////////
// SERVICIOS o INYECCIÓN DE DEPENDENCIAS 
///////////////////////////////////////

// Add services to the container.
builder.Services.AddControllersWithViews()
	.AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ModelNorthwind>(options => 
	options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind")));

var app = builder.Build();

///////////////////////////////////////
// MIDDLEWARE
///////////////////////////////////////

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
