
using Common;
using Common.DataStructure;
using Storage.Controllers;
using Storage.src;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

MongoController mongoController = new(app);


app.Run();
