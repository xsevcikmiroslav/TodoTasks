using ToDoTasks.Repositories;
using ToDoTasks.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(mc =>
{
    mc.AddProfile(new ToDoTasks.Automapper.AutomapperConfiguration());
});

builder.Services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

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

app.Run();
