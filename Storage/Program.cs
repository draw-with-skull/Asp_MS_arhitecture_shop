using Storage.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

ProductController mongoController = new(app);
UserController userController = new(app);


app.Run();
