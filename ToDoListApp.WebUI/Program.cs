using Microsoft.EntityFrameworkCore;
using ToDoListApp.BusinessLayer.Abstract;
using ToDoListApp.BusinessLayer.Concrete;
using ToDoListApp.DataAccessLayer.Context;
using ToDoListApp.DataAccessLayer.Repositories.ToDoRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IToDoService, ToDoManager>();
builder.Services.AddScoped<IToDoDal, ToDoRepository>();

builder.Services.AddDbContext<ToDoContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("TodoContext")));

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
    pattern: "{controller=ToDo}/{action=Index}/{id?}");

app.Run();
