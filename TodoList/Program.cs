using Infractructure;
using UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ITodoItemRepository<Entities.ToDoItem>,InMemoryTodoItemRepository>();
builder.Services.AddTransient<TodoListManager>();

var connectionString = builder.Configuration.GetConnectionString("DX_TESTEntities");
builder.Services.AddScoped(provider => new DX_TESTEntities(connectionString));

// Register the repository
builder.Services.AddScoped<ITodoItemRepository<Entities.ToDoItem>, MSSQLTodoItemRepository>();

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
