using Common;
using Common.DataStructure;
using Order.SRC;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.



//Background order Processing
OrderManager orderManager = new(1000);
orderManager.StartAsync(cancellationToken:default);

app.Run();