using Microsoft.EntityFrameworkCore;
using NetMacoratti.DBContent;
using NetMacoratti.Repository;
using NetMacoratti.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//inje��o de dependencia
builder.Services.AddDbContext<AppDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//intancia a inst�ncia do banco de dados 

builder.Services.AddTransient<ILanche, LancheRepository>();
builder.Services.AddTransient<ICategoria, CategoriaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
